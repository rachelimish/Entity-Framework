// See https://aka.ms/new-console-template for more information
using SampleOfUsingEF_DBFirst.Models;

Console.WriteLine("Hello, World!");
ShopContext contexts = new ShopContext();

//BooksDetail newBook = new BooksDetail() {Name = "ספר חדש", Id = 108, MaxAge = 80, MinAge= 8, NumberPages = 100, Price = 50};
var Cus = contexts.Customers.Single(b => b.City == "Berlin");
//book.MaxAge = 100;
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