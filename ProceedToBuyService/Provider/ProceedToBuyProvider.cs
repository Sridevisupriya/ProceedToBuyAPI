using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProceedToBuyService.Models;
using ProceedToBuyService.Repository;

namespace ProceedToBuyService.Provider
{
    public class ProceedToBuyProvider : IProceedToBuyProvider
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyProvider));

        private readonly IProceedToBuyRepository proceedToBuyRepository;
        public ProceedToBuyProvider(IProceedToBuyRepository repo)
        {
            proceedToBuyRepository = repo;
        }
        public bool Add(Wishlist entity)
        {
            try
            {
                _log4net.Info("Add To Wishlist Repository initiated");
                var result = proceedToBuyRepository.addToWishlist(entity);
                if(result ==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                _log4net.Info("Error in calling Wishlist Repository");
                return false;
            }
                

        }
        //  return proceedToBuyRepository.addToCart(entity);

        public IEnumerable<Cart> Add(Cart entity)
        {
           List<Vendor> vlist = new List<Vendor>();
            try
            {
                _log4net.Info("Add To Cart Provider initiated");
              
                try
                {

                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = client.GetAsync("https://localhost:44388/api/Vendor/GetVendorDetails/" + entity.ProductId).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new ArgumentNullException("error in calling Vendor API to get Vendors list");
                    }
                    var result = response.Content.ReadAsStringAsync().Result;
                    vlist = JsonConvert.DeserializeObject<List<Vendor>>(result);
                }
                catch (ArgumentNullException e)
                {
                    _log4net.Error(e.Message);
                    throw e;
                }
                /*
                    Depending on product Id , Vendor api to be called and vendor should be returned
                    if(result!=null)
                    {
                        Cart c=new Cart;
                        c.productId = productId;

                        var result = proceedToBuyRepository.addToCart(entity);
                        if (result == null)
                        {
                            throw new System.ArgumentNullException("Not able to add data to Cart");
                        }
                        else
                        {
                            return result;
                        }
                    }

                */
                return null;
            }
            catch
            {
                _log4net.Info("Error in calling Cart Repository");
                return null;
            }
        }
    }
}
