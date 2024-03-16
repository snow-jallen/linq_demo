using SQLite;

namespace LinqDemo.Persistence;

public interface IDataProvider
{
    public IEnumerable<Customer> LoadCustomers();
}

public class SqliteDataProvider : IDataProvider
{
    private string databasePath;
    public SqliteDataProvider(string databasePath)
    {
        this.databasePath = databasePath;
    }

    public IEnumerable<Customer> LoadCustomers()
    {
        using var db = new SQLiteConnection(databasePath);
        return db.Query<Customer>("select * from customers");
    }
}

[Table("customers")]
public class Customer
{
    public int CustomerId{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public string Company{get;set;}
    public string Address{get;set;}
    public string City{get;set;}
    public string State{get;set;}
    public string Phone{get;set;}
    public string Email{get;set;}
}
