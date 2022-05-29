using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderProcessAPI.Models;
using OrderProcessAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderProcessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDBContext db;
        private readonly IMapper mapper;
        private readonly ApiResponse res;
        private readonly IMemoryCache memCache;
        const string cacheKey = "productL";

        public TestController(ApplicationDBContext db, IMapper mapper, ApiResponse res, IMemoryCache memCache)
        {
            this.db = db;
            this.mapper = mapper;
            this.res = res;
            this.memCache = memCache;
        }
        [HttpGet]
        public ApiResponse Get(string category)
        {
            List<ProductViewModel> response = new();

            if (!memCache.TryGetValue(cacheKey, out List<Product> productL))
            {
                productL = db.Product.ToList();
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                memCache.Set(cacheKey, productL, cacheExpOptions);
            }

            if (category == null)
            {
                foreach (var i in productL)
                {
                    response.Add(mapper.Map<ProductViewModel>(i));
                }

                res.Data = response;
                res.Status = true;
                return res;
            }
            else
            {
                foreach (var i in db.Product.Where(x => x.Category.Equals(category)).ToList())
                {
                    response.Add(mapper.Map<ProductViewModel>(i));
                }
                res.Data = response;
                res.Status = true;
                return res;
            }
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] CreateOrderRequest value)
        {
            //value DEĞİŞKENİNDEN GEREKLİ DEĞERLER ÇEKİLİP AŞAĞIDAKİ KOD İLE SAVE İŞLEMİ GERÇEKLEŞECEKTİR
            //db.Order.Add();
            //db.OrderDetail.Add()

        }

    }
}
