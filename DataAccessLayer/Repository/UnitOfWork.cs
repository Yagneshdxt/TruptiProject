using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork
    {
        private DbContextClass context = new DbContextClass();
        private GenericRepository<Student> _StudentRepository;
        private GenericRepository<Branch> _BranchRepository;
        private GenericRepository<AcademicYear> _AcademicYearRepository;
        private GenericRepository<DocumentLinks> _DocumentLinkRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this._StudentRepository == null)
                {
                    this._StudentRepository = new GenericRepository<Student>(context);
                }
                return _StudentRepository;
            }
        }


        public GenericRepository<Branch> BranchRepository
        {
            get
            {

                if (this._BranchRepository == null)
                {
                    this._BranchRepository = new GenericRepository<Branch>(context);
                }
                return _BranchRepository;
            }
        }

        public GenericRepository<DocumentLinks> DocumentLinkRepository
        {
            get
            {

                if (this._DocumentLinkRepository == null)
                {
                    this._DocumentLinkRepository = new GenericRepository<DocumentLinks>(context);
                }
                return _DocumentLinkRepository;
            }
        }

        public GenericRepository<AcademicYear> AcademicYearRepository
        {
            get
            {

                if (this._AcademicYearRepository == null)
                {
                    this._AcademicYearRepository = new GenericRepository<AcademicYear>(context);
                }
                return _AcademicYearRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
