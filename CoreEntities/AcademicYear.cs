using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class AcademicYear
    {
        public long AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public string IsCurrentYear { get; set; }
    }
}
