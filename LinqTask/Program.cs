using LinqTask.Data;
using LinqTask.Models;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
         ApplicationDbContext _context = new ApplicationDbContext();
           // Retrieve all categories from the production.categories table.
            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine($"categoryId : {category.CategoryId} , categoryName : {category.CategoryName}");
            }
            //Retrieve the first product from the production.products table.

            var firstProduct = _context.Products.FirstOrDefault();
            Console.WriteLine($"ProductName :{firstProduct.ProductName} ,ProductId : {firstProduct.ProductId}");
            //Retrieve a specific product from the production.products table by ID
            var specificProduct = _context.Products.Find(4);
            Console.WriteLine($"ProductName :{specificProduct.ProductName} ,ProductId : {specificProduct.ProductId}");
            //Retrieve all products from the production.products table with a certain model year
            var products = _context.Products.Where(p => p.ModelYear == 2016).ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"ProductName :{product.ProductName} ,ProductId : {product.ProductId}");
            }
            //Retrieve a specific customer from the sales.customers table by ID.
            var specificCustomer = _context.Products.Find(4);
            Console.WriteLine($"ProductName :{specificCustomer.ProductName} ,ProductId : {specificCustomer.ProductId}");
            //Retrieve a list of product names and their corresponding brand names
            var productBrandList = _context.Products
            .Select(p => new
            {
                p.ProductName,
                p.Brand.BrandName
            })
           .ToList();
            foreach (var item in productBrandList)
            {
                Console.WriteLine($"productName: {item.ProductName}, BrandName: {item.BrandName}");
            }

            //Count the number of products in a specific category
            var productCount = _context.Products.Count(p => p.CategoryId == 2);
            Console.WriteLine($"Number of products in category {2}: {productCount}");
            //Calculate the total list price of all products in a specific category
            var totalPrice = _context.Products
           .Where(p => p.CategoryId == 1).Sum(p => p.ListPrice);
            Console.WriteLine($"Total list price for category {1}: {totalPrice}");
            //Calculate the average list price of products
            var averagePrice = _context.Products.Average(p => p.ListPrice);
            Console.WriteLine($"Average list price: {averagePrice}");
            //Retrieve orders that are completed
            var completedOrders = _context.Orders.Where(o => o.OrderStatus == 4).ToList();
            foreach( var order in completedOrders ) {
            {
                    Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");
            }


        }
    }
}
