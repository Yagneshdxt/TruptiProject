using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientInterface.Models
{
    public class DocumentViewModel
    {
        public long DocumentLinksId { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public long BranchId { get; set; }
        [Required(ErrorMessage = "Academic Year is required")]
        public long AcademicYearId { get; set; }
        [Required(ErrorMessage = "Document Type is required")]
        public long DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public HttpPostedFileBase WebDocumentUploaded { get; set; }
        public Byte[] documentInByte { get; set; }
        public string documentExtension { get; set; }
    }
}