using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Provider
{
    public interface IProceedToBuyProvider
    {
        public IEnumerable<Cart> Add(Cart entity);
        public bool Add(Wishlist entity);
    }
}
