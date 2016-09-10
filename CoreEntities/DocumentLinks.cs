using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class DocumentLinks
    {
        public long DocumentLinksId { get; set; }
        public long BranchId { get; set; }
        public Branch branch { get; set; }
        public long AcademicYearId { get; set; }
        public AcademicYear academicYear { get; set; }
        public long DocumentTypeId { get; set; }
        public DocumentType documentType { get; set; }
        public string DocumentPath { get; set; }
    }
}
