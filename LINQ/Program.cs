using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
namespace LINQ
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            NutshellContext dataContext = new NutshellContext("data source=.;initial catalog=Demo;integrated security=True;");


            IQueryable<object> query = dataContext.Customers.Join(dataContext.Purchases, x => x.ID, y => y.ID, (x, y) => new { x.Name, y.Price });
                                        //from c in dataContext.Customers
                                       // join p in dataContext.Purchases on c.ID equals p.CustomerID
                                       // select c.Name + " bought a " + p.Description;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

           

            Console.ReadKey();
        }
    }


    public class NutshellContext : DataContext
    {
        public NutshellContext(string cxString) : base(cxString) { }
        public Table<Customer> Customers { get { return GetTable<Customer>(); } }
        public Table<Purchase> Purchases { get { return GetTable<Purchase>(); } }
    }
    [Table]
    public class Customer
    {
        [Column(IsPrimaryKey = true)]
        public int ID;
        [Column]
        public string Name;
        [Association(OtherKey = "CustomerID")]
        public EntitySet<Purchase> Purchases = new EntitySet<Purchase>();
    }
    [Table]
    public class Purchase
    {
        [Column(IsPrimaryKey = true)]
        public int ID;
        [Column]
        public int? CustomerID;
        [Column]
        public string Description;
        [Column]
        public decimal Price;
        [Column]
        public DateTime Date;
        EntityRef<Customer> custRef;
        [Association(Storage = "custRef", ThisKey = "CustomerID", IsForeignKey = true)]
        public Customer Customer
        {
            get { return custRef.Entity; }
            set { custRef.Entity = value; }
        }
    }
}
