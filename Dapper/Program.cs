﻿using DapperDem;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            #region Departments
            //var repo = new DapperDepartmentRepository(conn);

            //Console.WriteLine("Type a new Department name");

            //var newDepartment = Console.ReadLine();

            //repo.InsertDepartment(newDepartment);

            //var departments = repo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}
            #endregion
            var productRepository = new DapperProductRepository(conn);

            #region Bonus Update
            //var productToUpdate = productRepository.GetProduct(940);

            //productToUpdate.Name = "UPDATED";
            //productToUpdate.Price = 16.99;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = false;


            //productRepository.UpdateProduct(productToUpdate);
            #endregion
            productRepository.DeleteProduct(940);

            var products = productRepository.GetAllProducts();
           
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}