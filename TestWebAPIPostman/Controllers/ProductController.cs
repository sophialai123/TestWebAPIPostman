using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPIPostman.Models;

namespace TestWebAPIPostman.Controllers
{
    public class ProductController : ApiController
    {

        //create entities after create model 
        Models.Entities db = new Entities();

        //create post request
        public string Post (Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return "Product added";
        }

        //get all records
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        //get single product
        public Product Get(int id)
        {
            //find the product id
           Product product= db.Products.Find(id);
            return product;
        }


        //update the record
        public string Put (int id, Product product)
        {
            //find product first
            var updatedProduct = db.Products.Find(id);

            //updated product equal to the pameter product
            updatedProduct.Name = product.Name;
            updatedProduct.Quantity = product.Quantity;
            updatedProduct.Price = product.Price;
            updatedProduct.Active = product.Active;

            //modify the data
            db.Entry(updatedProduct).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Prodcut Updated";
        }

        //delete the record
        public string Delete (int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return "deleted";

        }

    }
}
