using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientInterface.Models
{
    public class BranchViewModel
    {
        public BranchViewModel()
        {
            IsActive = true;
        }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
    }
}