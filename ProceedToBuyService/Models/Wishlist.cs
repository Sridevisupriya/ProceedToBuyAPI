﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyService.Models
{
    public class Wishlist
    {
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAddedToWishlist { get; set; }
    }
}
