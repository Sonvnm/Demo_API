using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            SilverJewelries = new HashSet<SilverJewelry>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string FromCountry { get; set; }

        public virtual ICollection<SilverJewelry> SilverJewelries { get; set; }
    }
}
