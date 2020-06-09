using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Consomi.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Consomi.Domain.Entities;
using Consomi.Service;

namespace Consomi.Web.Controllers.API
{
    public class LivController : ApiController
    {
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext UsersContext = new ApplicationDbContext();
        IProductService serviceProduct;
        Livraison livraison;
        ApplicationUser user;
        ILivraisonService serviceLivraison;
        ILivreurService serviceLivreur;
        Livreur livreur;

        public LivController()
        {
            livreur = new Livreur();
            livraison = new Livraison();
            serviceLivreur = new LivreurService();
            serviceLivraison = new LivraisonService();
            serviceProduct = new ProductService();
        }

        [System.Web.Http.Route("liv")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult FindLiv()
        {

            List<Livreur> liv = serviceLivreur.GetLivreurAll();

            
            return Json(liv);
           
        }

        [System.Web.Http.Route("dliv")]
        public void dLiv(int id)
        {

            serviceLivreur.DeleteL(id);


           

        }

        [System.Web.Http.Route("Get")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllProductWebService()
        {
            List<Product> productList = serviceProduct.GetAllProduct();
            return Ok(productList);
        }
    }
}