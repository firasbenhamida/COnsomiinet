using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Consomi.Data;
using Consomi.Domain.Entities;
using Consomi.Service;
using Consomi.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;

namespace Consomi.Web.Controllers
{
    public class LivraisonController : Controller
    {
        private ConsomiContext db = new ConsomiContext();
        private ApplicationDbContext UsersContext = new ApplicationDbContext();

        private ApplicationUserManager userManager;
        private ApplicationUserManager _userManager;
        ICartService serviceCart;
        ICartLineService serviceCartLine;
        ILivraisonService serviceLivraison;
        ILivreurService serviceLivreur;
        Livraison livraison ;
        Livreur l;
        Livreur livreur;
        int id;



        private ApplicationSignInManager _signInManager;
        ApplicationUser user;
        ApplicationUser userr;
        public static class t
        {
   
            public static Livreur T ; // can change because not const
            public static string a;
        }

        public static class T
        {

            public static int t = 0; // can change because not const
        }
        public LivraisonController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            livraison = new Livraison();
            user = new ApplicationUser();
            l = new Livreur();
            livreur = new Livreur();
            serviceLivraison = new LivraisonService();
            serviceLivreur = new LivreurService();
            serviceCart = new CartService();
            serviceCartLine = new CartLineService();





        }
        public LivraisonController()
        {
            t.T = new Livreur();
            livraison = new Livraison();
            user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId<int>());
            l = new Livreur();
            livreur = new Livreur();
            serviceLivraison = new LivraisonService();
            serviceLivreur = new LivreurService();
            serviceCart = new CartService();
            serviceCartLine = new CartLineService();
            //id = user.Id;
            userr = new ApplicationUser();




        }

        public ActionResult distance()
        {
       
            return View();
           
        }

        public int getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            string key = "AIzaSyBG-ZwPJQz6ml5i0hz80mUE39mL-Vd7he8";
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;
            //string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key=AIzaSyBG-ZwPJQz6ml5i0hz80mUE39mL-Vd7he8";

            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
        
        
           
       

        // GET: Livraison
        public ActionResult Index()
        {
            List<Livraison> livrai = serviceLivraison.GetLivraisonByLivreurId(user.Id);
            serviceLivreur.DeleteL(3);
            return View(livrai);
        }

        public void D(int id)
        {

            serviceLivreur.DeleteL(id);


            List<ApplicationUser> liv = UsersContext.Users.ToList();
            foreach (var e in liv)
            {
                if (e.Id==id)
                {
                    userr = e;
                }
            }


            UsersContext.Users.Remove(userr);
            UsersContext.SaveChanges();





    }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public  void R(string e, string a, string m)
        {

            if (true)
            {
                var user = new ApplicationUser { UserName = e, PhoneNumber = a, Email = e };
                var result =  UserManager.Create(user, m);
                if (true)
                {

                    SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");



                    livreur.Mail = e;
                    livreur.activite = 0;
                    livreur.adresse = a;

                    livreur.idU = user.Id;
                    db.Livreur.Add(livreur);
                    db.SaveChanges();


                }
                
            }
        }

        public void A(string e,string a,string m)
        {

           


           
                
            user.Email = e;
            user.PhoneNumber = a;
            user.UserName = e;
            user.PasswordHash = m;
            userManager.Create(user);

            


            /*List<ApplicationUser> liv = UsersContext.Users.ToList();
            foreach (var e in liv)
            {
                if (e.Id == id)
                {
                    user = e;
                }
            }


            UsersContext.Users.Remove(user);
            UsersContext.SaveChanges();
            */

           /* l.adresse = a;
            l.Mail = e;
            l.etat = 1;
            l.activite = 0;
            db.Livreur.Add(l);
            db.SaveChanges();*/

            




        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        // GET: Livraison/Details/5
        public ActionResult Details(int? id)
        {
            ViewData["LA"] = user.PhoneNumber;
            
            ViewData["CA"] = db.Livraison.Find(id).Adresse;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livraison livraison = db.Livraison.Find(id);
            if (livraison == null)
            {
                return HttpNotFound();
            }
            t.T = db.Livreur.Find(livraison.idLivreur);
            t.a = livraison.Adresse;
            
            
            return View(livraison);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "id,idLivreur")]Livraison livraison)
        {
            int x =0;
            List <Livreur> livre = serviceLivreur.GetLivreurAll();
            foreach (var e in livre)
            {
                if (e.idU == user.Id)
                {
                    x = e.etat;
                }
            }
            
            int m = getDistance(user.PhoneNumber,t.a);
            x = x + (m / 1000);
            serviceLivraison.livraisonconfirm(livraison.id,user.Id,x);


            return RedirectToAction("Index");
        }

        // GET: Livraison/Create
        public ActionResult Create()
        {
            int m = 0;
            int M = 1000000000;
            int id = 0;
            List<ApplicationUser> liv = UsersContext.Users.ToList(); 
            foreach (var e in liv)
            {
                if (e.Email == "livreur@hotmail.com" || e.Email == "livreur1@hotmail.com" || e.Email == "livreur2@hotmail.com" || e.Email == "livreur3@hotmail.com" || e.Email == "livreur4@hotmail.com" || e.Email == "livreur5@hotmail.com" || e.Email == "livreur6@hotmail.com")
                {
                    m = getDistance(user.PhoneNumber, e.PhoneNumber);
                    if (m <= M)
                    {
                        M = m;
                        id = e.Id;
                    }
                }
            }
            
            Cart cart = null;
            cart = serviceCart.GetCartByUserId(user.Id);
            livraison.idCommande = M;
            livraison.idLivreur = id;
            livraison.idClient = user.Id;
            livraison.Adresse = user.PhoneNumber;
            livraison.Ville = "0";
            db.Livraison.Add(livraison);
            db.SaveChanges();
            return RedirectToAction("../Product/Carthistory");
        }

        // POST: Livraison/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Adresse,Ville")] Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                Cart cart = null;
                cart = serviceCart.GetCartByUserId(user.Id);
                livraison.idCommande = livraison.id;
                livraison.idLivreur = 1;
                livraison.idClient = user.Id;
                db.Livraison.Add(livraison);
                db.SaveChanges();
                return RedirectToAction("../Product/Carthistory");
            }

            return View(livraison);
        }

        // GET: Livraison/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livraison livraison = db.Livraison.Find(id);
            if (livraison == null)
            {
                return HttpNotFound();
            }
            return View(livraison);
        }

        // POST: Livraison/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idCommande,Adresse,Ville,idLivreur,idClient")] Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livraison).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livraison);
        }

        // GET: Livraison/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livraison livraison = db.Livraison.Find(id);
            if (livraison == null)
            {
                return HttpNotFound();
            }
            return View(livraison);
        }

        // POST: Livraison/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livraison livraison = db.Livraison.Find(id);
            db.Livraison.Remove(livraison);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
