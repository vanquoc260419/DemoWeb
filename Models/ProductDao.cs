namespace WebDemo14112023.Models
{
    public class ProductDao
    {
        private static ProductDao instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDao();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Id = 1,Name="Laptop Acer", Description="Laptop", Price=1200300.500M},
                new Product { Id = 2,Name="Laptop Dell", Description="Laptop", Price=1500400.500M},
                new Product { Id = 3,Name="Bàn phím Acer", Description="Bàn phím", Price=12300.500M},
                new Product { Id = 4,Name="Bàn phím Logitech", Description="Bàn phím", Price=20500.500M},
            };
            return products;
        }
    }
}
