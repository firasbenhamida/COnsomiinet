using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Consomi.Data;
using  Consomi.Data.Infrastructure;
using  Consomi.Domain.Entities;
using System.Data.SqlClient;


namespace Consomi.Service
{
    public class CartLineService : Service<CartLine>, ICartLineService
    {
        static ConsomiContext ctxt = new ConsomiContext();
        static IDataBaseFactory dbFactory = new DataBaseFactory(ctxt);
        static IUnitOfWork uow = new UnitOfWork(dbFactory);

        public CartLineService() : base(uow)
        {

        }





    }
}