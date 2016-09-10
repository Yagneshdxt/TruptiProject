using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Branch
    {
        public Branch() {
            IsActive = true;
        }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
    }
}
