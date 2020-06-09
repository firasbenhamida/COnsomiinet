using Consomi.Data;
using Consomi.Domain.Entities;
using Consomi.Service;
using Consomi.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Consomi.Web.Controllers.API
{



    [RoutePrefix("CartProduct/Api")]
    public class CartProductApiController : ApiController
    {
        IProductService serviceProduct ;
        ICartLineService serviceCartLine;
        ICartService serviceCart;

        public CartProductApiController()
        {
            serviceProduct = new ProductService();
            serviceCartLine = new CartLineService();
            serviceCart = new CartService();
        }

        [Route("GetAllProduct")]
        public IHttpActionResult GetAllProductWebService()
        {
            List<Product> productList = serviceProduct.GetAllProduct();
            return Ok(productList);
        }

        //[Route("GetCartLinesByCartId/{cartId}")]
        //public IHttpActionResult GetCartLinesByCartIdWebService(int cartId)
        //{
        //    //var WS_CartLineList = new List<ComplexProductObject>();
        //    var cartLineList = MyCartLineService.GetCartLinesByCartId(cartId);
        //    //foreach (var cartLine in cartLineList)
        //    //{
        //    //    ComplexProductObject WS_cartLine = new ComplexProductObject();

        //    //    WS_cartLine.CartLineId = cartLine.Id;

        //    //    //WS_product.ImgBase64 = Convert.ToBase64String(product.Img1);

        //    //    // WS_product.Img1 = product.Img1;
        //    //    WS_CartLineList.Add(WS_cartLine);

        //    //}
        //    //var jsonResult = Json(WS_productList.ToArray(), JsonRequestBehavior.AllowGet);
        //    //jsonResult.MaxJsonLength = int.MaxValue;
        //    return Ok(cartLineList);
        //}


        //[Route("GetNotYetPurchasedCartByParentId/{parentId}")]
        //public IHttpActionResult GetNotYetPurchasedCartByParentIdWebService(int parentId)
        //{

        //    var cart = MyCartService.GetNotYetPurchasedCartByParentId(parentId);
        //    //if(cart == null)
        //    //{
        //    //    return Ok("not found");
        //    //}  
        //    return Ok(cart);
        //}


        [Route("GetProductById/{productId}")]
        public IHttpActionResult GetProductByCartLineIdWebService(int productId)
        {
            var product = serviceProduct.GetById(productId);
            return Ok(product);
        }



        //[Route("GetAllCartByParentId/{parentId}")]
        //public IHttpActionResult GetAllCartByParentIdWebService(int parentId)
        //{
        //    // her i retrieve all parent cart 
        //    var cartList = MyCartService.GetAllCartByParentId(parentId);



        //    //List<CartLine> cartLineList = MyCartLineService.GetCartLinesByCartId(10);
        //    // here i use parent cart.id to retrieve cartLines
        //    //foreach (Cart cart in cartList)
        //    //{
        //    //    List<CartLine> cartLineList = MyCartLineService.GetCartLinesByCartId(cart.Id);


        //    //}

        //    return Ok(cartList);
        //}


        //ConsomiContext db = new ConsomiContext();

        //[Route("AddProductToCart/{userId}/{productId}/{quantityChoosed}")]
        //public IHttpActionResult AddProductToCartWebService(int userId, int productId, int quantityChoosed)
        //{
        //    try
        //    {

        //        Cart testCart = MyCartService.GetCartByParentId(userId);
        //        Product product = MyProductService.GetById(productId);
        //        if (testCart == null)
        //        {
        //            Cart newCart = db.Carts.Create();
        //            newCart.CartStatus = true;
        //            newCart.ParentId = userId;
        //            newCart.PurchaseDate = DateTime.UtcNow;
        //            MyCartService.Add(newCart);
        //            MyCartService.Commit();

        //            CartLine cartLine = db.CartLines.Create();
        //            cartLine.DateAddedToCart = DateTime.UtcNow;
        //            cartLine.CartId = newCart.Id;
        //            cartLine.ProductId = productId;
        //            cartLine.QuantityChoosed = quantityChoosed;
        //            cartLine.TotalCartLinePrice = product.Price * quantityChoosed;
        //            cartLine.ProductPrice = product.Price;
        //            MyCartLineService.Add(cartLine);
        //            MyCartLineService.Commit();

        //            //newCart.TotalCartPrice += (cartLine.ProductPrice * quantityChoosed);
        //            //MyCartService.Commit();

        //        }
        //        else
        //        {

        //            CartLine cartLine = db.CartLines.Create();
        //            cartLine.DateAddedToCart = DateTime.UtcNow;
        //            cartLine.CartId = testCart.Id;
        //            cartLine.ProductId = productId;
        //            cartLine.QuantityChoosed = quantityChoosed;
        //            cartLine.TotalCartLinePrice = product.Price * quantityChoosed;
        //            cartLine.ProductPrice = product.Price;
        //            MyCartLineService.Add(cartLine);


        //            MyCartLineService.Commit();


        //        }
        //    }

        //    catch (IOException e)
        //    {
        //        throw e;

        //    }

        //    return Ok("product added to cart");
        //}

        //[Route("ConfirmPurchase/{parentId}")]
        //public IHttpActionResult ConfirmPurchaseWebService(int parentId)
        //{
        //    Cart myCart = MyCartService.GetCartByParentId(parentId);
        //    ICollection<CartLine> cartLines = MyCartLineService.GetCartLinesByCartId(myCart.Id);
        //    double totalPrice = 0;
        //    foreach (var cartLine in cartLines)
        //    {
        //        totalPrice += (cartLine.ProductPrice * cartLine.QuantityChoosed);
        //    }
        //    myCart.TotalCartPrice = totalPrice;
        //    myCart.CartStatus = false;
        //    //myCart.CartLines = cartLines;
        //    MyCartService.Commit();

        //    return Ok("cart purchased");

        //}

    }
}