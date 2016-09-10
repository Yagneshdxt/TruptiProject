using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClientInterface.Models;
using System.Threading.Tasks;
using ClientInterface.MappingConfig;
using CoreEntities;
using System.Linq.Expressions;

namespace ClientInterface.Controllers
{
    public class AccountController : ApiController
    {
        private UnitOfWork _UOW;

        public AccountController()
        {
            _UOW = new UnitOfWork();
        }

        public AccountController(UnitOfWork unitOfWork)
        {
            _UOW = unitOfWork;
        }

        [HttpPost, ActionName("RegisterUser")]
        public async Task<IHttpActionResult> RegisterUser(StudentsViewModel StudentModel)
        {
            StudentModel.StudentId = 0;
            if (!IsModelValid(StudentModel))
            {
                return BadRequest(ModelState);
            }
            AutoMapperConfig.MapStudenToVM();
            Student stud = AutoMapper.Mapper.Map<Student>(StudentModel);
            Student InsertedStu = _UOW.StudentRepository.Insert(stud);
            _UOW.Save();
            StudentModel = AutoMapper.Mapper.Map<StudentsViewModel>(InsertedStu);
            return Ok<StudentsViewModel>(StudentModel);
        }

        [HttpGet, ActionName("getInactiveStudent")]
        public async Task<IHttpActionResult> getInActiveStudents()
        {
            IEnumerable<Student> stu = _UOW.StudentRepository.Get(q => q.IsApproved == false && q.IsAdmin == false);
            return Ok<IEnumerable<Student>>(stu);
        }

        [HttpGet, ActionName("getActiveStudent")]
        public async Task<IHttpActionResult> getActiveStudents()
        {
            IEnumerable<Student> stu = _UOW.StudentRepository.Get(q => q.IsApproved == true && q.IsAdmin == false);
            return Ok<IEnumerable<Student>>(stu);
        }

        [HttpPost, ActionName("ActivateUser")]
        public IHttpActionResult ActivateUser(long StudentId)
        {
            Student stu = _UOW.StudentRepository.GetByID(StudentId);
            if (stu == null || stu.StudentId <= 0)
            {
                return BadRequest("Student with given Id Cannot be found");
            }

            stu.IsApproved = true;
            _UOW.StudentRepository.Update(stu);
            _UOW.Save();
            return Ok();
        }

        [HttpPost, ActionName("ActivateUser")]
        public IHttpActionResult InActivateUser(long StudentId)
        {
            Student stu = _UOW.StudentRepository.GetByID(StudentId);
            if (stu == null || stu.StudentId <= 0)
            {
                return BadRequest("Student with given Id Cannot be found");
            }

            stu.IsApproved = false;
            _UOW.StudentRepository.Update(stu);
            _UOW.Save();
            return Ok();
        }

        [HttpPost, HttpGet, ActionName("LoginStudent")]
        private IHttpActionResult LoginStudent(string Password, string UserName = "", string EnrollmentNo = "", string LoginName = "", string EmailId = "")
        {
            if ((String.IsNullOrEmpty(UserName) & String.IsNullOrEmpty(EnrollmentNo) & String.IsNullOrEmpty(LoginName) & String.IsNullOrEmpty(EmailId)) || String.IsNullOrEmpty(Password))
            {
                return BadRequest();
            }
            Expression<Func<Student, bool>> filterCondition = a => true;
            ParameterExpression stud = Expression.Parameter(typeof(Student), "stud");
            Expression ExpreFullName, ExpreEnrollmentNo, ExpreLoginName, ExpreEmailId, ExprePassword;
            if (!String.IsNullOrEmpty(UserName))
            {
                /*var prefix = filterCondition.Compile();
                filterCondition = a => prefix(a) && a.FullName == UserName;*/

                Expression<Func<Student, bool>> abc = a => a.FullName == UserName;
                filterCondition = Expression.Lambda<Func<Student, bool>>(Expression.AndAlso(filterCondition.Body, abc.Body), filterCondition.Parameters);
                //ExpreFullName = Expression.Equal(Expression.Property(stud, "FullName"), Expression.Constant(UserName));

            }
            if (!String.IsNullOrEmpty(EnrollmentNo))
            {
                /*var prefix = filterCondition.Compile();
                filterCondition = a => prefix(a) && a.EnrollmentNo == EnrollmentNo;*/

                Expression<Func<Student, bool>> abc = a => a.EnrollmentNo == EnrollmentNo;
                filterCondition = Expression.Lambda<Func<Student, bool>>(Expression.AndAlso(filterCondition.Body, abc.Body), filterCondition.Parameters);
                //ExpreEnrollmentNo = Expression.Equal(Expression.Property(stud, "EnrollmentNo"), Expression.Constant(EnrollmentNo));
            }
            if (!String.IsNullOrEmpty(LoginName))
            {
                /*var prefix = filterCondition.Compile();
                filterCondition = a => prefix(a) && a.LoginName == LoginName;*/

                Expression<Func<Student, bool>> abc = a=> a.LoginName == LoginName;
                filterCondition = Expression.Lambda<Func<Student, bool>>(Expression.AndAlso(filterCondition.Body, abc.Body), filterCondition.Parameters);
                //ExpreLoginName = Expression.Equal(Expression.Property(stud, "LoginName"), Expression.Constant(LoginName));
            }
            if (!String.IsNullOrEmpty(EmailId))
            {
                /*var prefix = filterCondition.Compile();
                filterCondition = a => prefix(a) && a.EmailId == EmailId;*/

                Expression<Func<Student, bool>> abc = a=> a.EmailId == EmailId;
                filterCondition = Expression.Lambda<Func<Student, bool>>(Expression.AndAlso(filterCondition.Body, abc.Body), filterCondition.Parameters);
                //ExpreEmailId = Expression.Equal(Expression.Property(stud, "EmailId"), Expression.Constant(EmailId));
            }
            /*var userIdPrefix = filterCondition.Compile();
            filterCondition = a => (userIdPrefix(a)) && a.LoginPassword == Password && a.IsApproved == true;*/

            Expression<Func<Student, bool>> abcd = a => a.LoginPassword == Password && a.IsApproved == true;
            filterCondition = Expression.Lambda<Func<Student, bool>>(Expression.AndAlso(filterCondition.Body, abcd.Body), filterCondition.Parameters);

            //ExprePassword = Expression.Equal(Expression.Property(stud, "LoginPassword"), Expression.Constant(Password));
            


            Student stu = _UOW.StudentRepository.Get(filter: filterCondition).FirstOrDefault();
            if (stu == null && stu.StudentId <= 0)
            {
                return BadRequest("failed");
            }
            return Ok<Student>(stu);
        }

        [HttpGet, ActionName("LoginStudentUserName")]
        public IHttpActionResult LoginStudent(string Password, string UserName) {

            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(UserName)) {
                return BadRequest("Password or UserName missing.");
            }

            Student stu = _UOW.StudentRepository.Get(filter: q=> q.FullName == UserName && q.LoginPassword == Password && q.IsApproved == true).FirstOrDefault();
            if (stu == null && stu.StudentId <= 0)
            {
                return BadRequest("failed");
            }
            return Ok<Student>(stu);
        }


        [HttpGet, ActionName("LoginByEmailId")]
        public IHttpActionResult LoginByEmailId(string Password, string EmailId)
        {

            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(EmailId))
            {
                return BadRequest("Password or EmailId missing.");
            }

            Student stu = _UOW.StudentRepository.Get(filter: q => q.EmailId == EmailId && q.LoginPassword == Password && q.IsApproved == true).FirstOrDefault();
            if (stu == null && stu.StudentId <= 0)
            {
                return BadRequest("failed");
            }
            return Ok<Student>(stu);
        }


        [HttpGet, ActionName("LoginByEmailId")]
        public IHttpActionResult LoginByLoginname(string Password, string Loginname)
        {

            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Loginname))
            {
                return BadRequest("Password or LoginName missing.");
            }

            Student stu = _UOW.StudentRepository.Get(filter: q => q.LoginName == Loginname && q.LoginPassword == Password && q.IsApproved == true).FirstOrDefault();
            if (stu == null && stu.StudentId <= 0)
            {
                return BadRequest("failed");
            }
            return Ok<Student>(stu);
        }

        [HttpGet, ActionName("LoginByEmailId")]
        public IHttpActionResult LoginByEnrollmentNo(string Password, string EnrollmentNo)
        {

            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(EnrollmentNo))
            {
                return BadRequest("Password or EnrollmentNo missing.");
            }

            Student stu = _UOW.StudentRepository.Get(filter: q => q.EnrollmentNo == EnrollmentNo && q.LoginPassword == Password && q.IsApproved == true).FirstOrDefault();
            if (stu == null && stu.StudentId <= 0)
            {
                return BadRequest("failed");
            }
            return Ok<Student>(stu);
        }

        private bool IsModelValid(StudentsViewModel studentModel)
        {
            Expression<Func<Student, bool>> filterCondition = null;
            if (studentModel.StudentId > 0)
            {
                filterCondition = (q => (q.EmailId == studentModel.EmailId || q.EnrollmentNo == studentModel.EnrollmentNo) && q.StudentId != studentModel.StudentId);
            }
            if (studentModel.StudentId == 0)
            {
                filterCondition = (q => q.EmailId == studentModel.EmailId || q.EnrollmentNo == studentModel.EnrollmentNo);
            }
            int duplicateCnt = _UOW.StudentRepository.Get(filter: filterCondition).Count();
            if (duplicateCnt > 0)
            {
                ModelState.AddModelError("", "Student with this email Id and enrollmentNo already exists");
            }

            if (!ModelState.IsValid)
            {
                return false;
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_UOW != null)
                {
                    _UOW.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
