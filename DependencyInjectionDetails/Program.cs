using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger1 = new FileLogger();
            ProductManager manager1 = new ProductManager(logger1);
            manager1.Add();

            ILogger logger2 = new DatabaseLogger();
            manager1 = new ProductManager(logger2);
            manager1.Add();

            CustomerManger customerManager = new CustomerManger();
            customerManager.Add(new DatabaseLogger());

            CategoryManager categoryManager = new CategoryManager() 
            { 
                Logger=new FileLogger()
            };
            categoryManager.Add();
            
            Console.ReadLine();
        }
    }
    interface ILogger
    {
        void Log();
    }
    class FileLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }
    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }
    class ProductManager
    {
        private readonly ILogger _logger;
        
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Product added");
        }
    }
    class CustomerManger
    {
        public void Add(ILogger logger)
        {
            logger.Log();
            Console.WriteLine("Customer added");
        }
    }
    class CategoryManager
    {
        public ILogger Logger { get; set; }

        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Category added");
        }
    }
}
