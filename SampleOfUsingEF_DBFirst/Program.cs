// See https://aka.ms/new-console-template for more information
using SampleOfUsingEF_DBFirst.Models;

Console.WriteLine("Hello, World!");
ShopContext contexts = new ShopContext();

Customer newBook = new Customer() { Id = 1000, FirstName = "רחל", LastName = "מישקובסקי", City= "רכסים", Country = "ישראל", Phone = "0548554002"};
var Cus = contexts.Customers.Single(b => b.City == "Berlin");
//contexts.Remove(Cus);
contexts.Add(newBook);
ChangeSpecificFeild(Cus, "City", "חיפה");
contexts.SaveChanges();


void ChangeSpecificFeild(Customer CusToUpdate, string columnName, string newValue)
{
    Type type = CusToUpdate.GetType();
    var property = type.GetProperty(columnName);
    if (property.PropertyType == typeof(int?))
    {
        int valueAsInt;
        if (int.TryParse(newValue, out valueAsInt))
        {
            property.SetValue(CusToUpdate, valueAsInt, null);
        }
        else
        {
            property.SetValue(CusToUpdate, newValue, null);
        }
    }
}