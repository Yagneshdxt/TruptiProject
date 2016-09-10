using ClientInterface.MappingConfig;
using CoreEntities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClientInterface.Controllers
{
    public class AcademicYearController : ApiController
    {
        private UnitOfWork _UoW;

        public AcademicYearController() {
            _UoW = new UnitOfWork();
        }

        public async Task<IHttpActionResult> getAllAcademicYear() {

            IEnumerable<AcademicYear> AcademicYearList = _UoW.AcademicYearRepository.Get();

            return Ok<IEnumerable<AcademicYear>>(AcademicYearList);
        }

        /*[HttpPost, ActionName("AddBranch")]
        public async Task<IHttpActionResult> AddAcademicYear(BranchViewModel model)
        {
            if (String.IsNullOrEmpty(model.BranchName))
            {
                return BadRequest("Branch Name missing");
            }
            AutoMapperConfig.MapBranchBranchVM();
            Branch brn = AutoMapper.Mapper.Map<Branch>(model);
            _UoW.BranchRepository.Insert(brn);
            _UoW.Save();
            return Ok();
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_UoW != null)
                {
                    _UoW.Dispose();
                }
            }
            base.Dispose(disposing);
        }

    }
}
