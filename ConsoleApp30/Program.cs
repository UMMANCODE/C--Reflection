using System.Reflection;
using ConsoleApp30;
#region Task 1
uint productCount;
do {
    Console.Write("Enter the product count: ");
} while (!uint.TryParse(Console.ReadLine(), out productCount));

Product[] products = new Product[productCount];

for (int i = 0; i < productCount; i++) {
    Console.WriteLine($"Product {i + 1}:");
    Console.Write("Name: ");
    string? name = Console.ReadLine();
    Console.Write("Price: ");
    double price;
    while (!double.TryParse(Console.ReadLine(), out price) || price < 0) {
        Console.WriteLine("Invalid price!");
        Console.Write("Price: ");
    }
    Console.Write("Type: ");
    Product.ProductType type;
    while (!Enum.TryParse(Console.ReadLine(), true, out type) || !Enum.IsDefined(typeof(Product.ProductType), type)) {
        Console.WriteLine("Invalid type!");
        Console.Write("Type: ");
    }
    products[i] = new Product(name, price, type);
}

foreach (Product product in products) {
    Console.WriteLine(product);
}
#endregion

#region Task 2
ProductList productList = new();
Product specialProduct = new("Cola", 12, Product.ProductType.Drink);
Console.WriteLine("BEFORE: ");
Console.WriteLine(productList[1]);
productList[1] = specialProduct;
Console.WriteLine("AFTER: ");
Console.WriteLine(productList[1]);
#endregion

#region Task 3
Human[] humans = {
    new Student(),
    new Employee(1000),
    new Employee(800),
    new Employee(2000),
    new()
};

static double GetTotalSalary(Human[]? humans) {
    double totalSalary = 0;
    if (humans != null) {
        foreach (Human item in humans) {
            if (item is Employee || item.GetType().IsSubclassOf(typeof(Employee))) {
                if (item is Employee employee) {
                    Type type = employee.GetType();
                    FieldInfo fieldInfo = type.GetField("_salary", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (fieldInfo != null) {
                        totalSalary += (double)fieldInfo.GetValue(employee);
                    }
                }
            }
        }
    }
    return totalSalary;
}

Console.WriteLine($"Total salary: {GetTotalSalary(humans):0.00}");


#endregion