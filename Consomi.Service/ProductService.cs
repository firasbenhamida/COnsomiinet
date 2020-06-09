using Consomi.Data;
using Consomi.Data.Infrastructure;
using Consomi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consomi.Service
{
   public class ProductService : Service<Product> , IProductService
    {
        static ConsomiContext ctxt = new ConsomiContext();
        static IDataBaseFactory dbFactory = new DataBaseFactory(ctxt);
        static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public ProductService() : base(uow)
        {

        }

        
    }
}
