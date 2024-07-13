// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Numerics;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Basic Robes",
        Price = 10M,
        Sold = false,
        ProductTypeId = 0,
        DateStocked = new DateTime(2024, 07, 01)
    },
    new Product()
    {
        Name = "Portkey",
        Price = 5M,
        Sold = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 06, 01)
    },
    new Product()
    {
        Name = "Elder Wand",
        Price = 15M,
        Sold = false,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 05, 01)
    },
    new Product()
    {
        Name = "Deluminator",
        Price = 8M,
        Sold = false,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 04, 01)
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 2M,
        Sold = false,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 03, 01)
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "Apparel",
        Id = 0
    },

    new ProductType()
    {
       Name = "Potions",
       Id = 1
    },

     new ProductType()
    {
       Name = "Enchanted Objects",
       Id = 2
    },

      new ProductType()
    {
       Name = "Wands",
       Id = 3
    }
};

string greeting = @$"Welcome to Reductio & Absurdum
Your one-stop shop for all your wizarding needs!";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an Option:
0. Exit
1. View All Products
2. Add a Product
3. Delete a Product
4. Update a Product
5. Search for a Prouduct by Product Type");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ViewAllProducts();
    }
    else if (choice == "2")
    {
        AddProduct();
    }
    else if (choice == "3")
    {
        DeleteProduct();
    }
    else if (choice == "4")
    {
        UpdateProduct();
    }
    else if (choice == "5")
    {
        SearchByTypeId();
    }
    else
    {
        Console.WriteLine("Please select an option");
    }
}


void ViewAllProducts()
{
    Console.WriteLine("Products:");
    foreach (Product product in products)
    {
        {
            Console.WriteLine($"{product.Name}   Price: ${product.Price}   In Stock: {product.Sold}   Type ID: {product.ProductTypeId}   DaysOnShelf: {product.DaysOnShelf}");
        }
    }
}

void AddProduct()
{
    Console.WriteLine("Please input the product name");
    string productName = Console.ReadLine();
    Console.WriteLine("Please input the price");
    decimal productPrice = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Please input the product type. Input 0 for apparel, 1 for potions, 2 for enchanted objects, or 3 for wands");
    int prouductType = Int32.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = productName,
        Price = productPrice,
        Sold = false,
        ProductTypeId = prouductType
    };

    products.Add(newProduct);
    Console.WriteLine($"{newProduct.Name} has been added for sale for {newProduct.Price} dollars");
}

void DeleteProduct()
{
    string choice = null;

    while (choice != "0")
    {
        try
        {
            Console.WriteLine("0. Goodbye");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");
            }
            choice = Console.ReadLine();
            products.RemoveAt(Int32.Parse(choice) - 1);
        }
        catch
        {
            break;
        }
    }
}

void UpdateProduct()
{
        Console.WriteLine("Please select product to update:");

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name}");
        }

        Product chosenProduct = null;

        while (chosenProduct == null)
        {
            Console.WriteLine("Please enter a product number: ");
            try
            {
                int response = int.Parse(Console.ReadLine().Trim());

                chosenProduct = products[response - 1];
            }
            catch (FormatException)
            {
                Console.WriteLine("Please type only integers!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Do better!");
            }
        }

        Console.WriteLine(@$"You chose:
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars, and {(chosenProduct.Sold ? "is in stock" : "is out of stock")}");

        Console.WriteLine(@"Please choose a detail to edit:
        0. Name
        1. Price
        2. Availability
        3. Product Type ID");

        int index = products.IndexOf(chosenProduct);

        int choice = int.Parse(Console.ReadLine());
        if (choice == 0)
        {
            Console.WriteLine("Please enter the new name");
            string newName = Console.ReadLine();
            products[index].Name = newName;
        }
        else if (choice == 1)
        {
            Console.WriteLine("Please enter the new price");
            decimal newPrice = Convert.ToDecimal(Console.ReadLine());
            products[index].Price = newPrice;

        }
        else if (choice == 2)
        {
            Console.WriteLine(@"Please select an option:
        0. Sold
        1. Available");

            int newChoice = int.Parse(Console.ReadLine());

            if (newChoice == 0)
            {
                products[index].Sold = false;
            }
            else if (newChoice == 1)
            {
                products[index].Sold = true;
            }

        }
        else if (choice == 3)
        {
            Console.WriteLine(@"Please enter new Product Type ID: 
                Input 0 for apparel, 
                1 for potions, 
                2 for enchanted objects,
                or 3 for wands");

            int newId = int.Parse(Console.ReadLine());
            products[index].ProductTypeId = newId;
        } 
}

void SearchByTypeId()
{
    List<Product> availableProducts = products.Where(p => !p.Sold).ToList();

    int choice;
    Console.WriteLine("Search by product type. Input 0 for apparel, 1 for potions, 2 for enchanted objects, or 3 for wands");
    choice = Int16.Parse(Console.ReadLine());
    List<Product> searchedProduct = availableProducts.Where(product => product.ProductTypeId == choice).ToList();
    foreach (Product product in searchedProduct)
    {
        Console.WriteLine(product.Name);
    }
}