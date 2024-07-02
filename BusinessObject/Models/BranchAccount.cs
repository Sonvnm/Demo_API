using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BranchAccount
    {
        public int AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int? Role { get; set; }
    }
}
