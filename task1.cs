interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Delete(T item);
    T FindById(int id);
    IEnumerable<T> GetAll();
}

interface IEntity
{
    int Id { get; set; }
}

class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

class ProductRepository : IRepository<Product>
{
    private List<Product> products = new List<Product>();
    public void Add(Product item)
    {
        products.Add(item);
    }
    public void Delete(Product item)
    {
        products.Remove(item);
    }
    public Product FindById(int id)
    {
        foreach (var product in products)
        {
            if (product.Id == id)
                return product;
        }
        return null;
    }
    public IEnumerable<Product> GetAll()
    {
        return products;
    }
}

class CustomerRepository : IRepository<Customer>
{
    private List<Customer> customers = new List<Customer>();
    public void Add(Customer item)
    {
        customers.Add(item);
    }
    public void Delete(Customer item)
    {
        customers.Remove(item);
    }
    public Customer FindById(int id)
    {
        foreach (var customer in customers)
        {
            if (customer.Id == id)
                return customer;
        }
        return null;
    }
    public IEnumerable<Customer> GetAll()
    {
        return customers;
    }
}

class Program
{
    static void Main()
    {
        ProductRepository productRepo = new ProductRepository();
        productRepo.Add(new Product { Id = 1, Name = "Laptop", Price = 1200 });
        productRepo.Add(new Product { Id = 2, Name = "Mouse", Price = 25 });

        Console.WriteLine("Продукты:");
        foreach (var p in productRepo.GetAll())
        {
            Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
        }

        int id = 1;
        Product product = productRepo.FindById(id);
        Console.WriteLine($"по id - {id} найден продукт: {product.Name}");

        CustomerRepository customerRepo = new CustomerRepository();
        customerRepo.Add(new Customer { Id = 1, Name = "Ivan", Address = "Moscow" });
        customerRepo.Add(new Customer { Id = 2, Name = "Anna", Address = "SPB" });

        Console.WriteLine("\nКлиенты:");
        foreach (var c in customerRepo.GetAll())
        {
            Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Address: {c.Address}");
        }

        id = 2;
        Customer customer = customerRepo.FindById(id);
        Console.WriteLine($"по id - {id} найден клиент: {customer.Name}");
    }
}
