﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SilverJewelry
    {
        public string SilverJewelryId { get; set; }
        public string SilverJewelryName { get; set; }
        public string SilverJewelryDescription { get; set; }
        public decimal? MetalWeight { get; set; }
        public decimal? Price { get; set; }
        public int? ProductionYear { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
