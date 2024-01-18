
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Miles Davis Trumpet",
        Price = 859.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "milk and honey",
        Price = 79.50M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Gold Plated French Horn",
        Price = 678.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Time Is A Mother",
        Price = 103.32M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Urbie Green Trombone",
        Price = 1224.56M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "The Hurting Kind [Original]",
        Price = 149.99M,
        ProductTypeId= 1
    }
};


//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Poems",
        Id = 1
    },
    new ProductType()
    {
        Title = "Brass Instruments",
        Id = 2
    }
};

//put your greeting here

string greeting = @"Welcome to Brass And Poem!
Where love of brass instruments and poetry collide!";

Console.WriteLine("\n" + greeting + "\n");
DisplayMenu();

//implement your loop here

void DisplayMenu()
{
    string choice = null;
    while (choice == null)
    {
        Console.WriteLine(@"Please choose an option: 
        1. Display All Products
        2. Delete A Product
        3. Add A New Product
        4. Update Product Properties
        5. Exit");

        choice = Console.ReadLine();

        if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
            Console.WriteLine("\n");
            DisplayMenu();
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("\nThank you for visiting Brass And Poem, have a great day!");
        }
    }
}



void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    string typeMatch(int id)
    {
        ProductType rightType = productTypes.FirstOrDefault(s => s.Id == id);
        return rightType.Title;
    };

    Console.WriteLine("\nProducts: \n");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}: ${products[i].Price} (in {typeMatch(products[i].ProductTypeId)})");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Product chosen = null;
    string response = "";

    DisplayAllProducts(products, productTypes);
    Console.WriteLine("\n Please select which product you would like to delete.");

    while (chosen == null)
    {
        Console.WriteLine("Enter a product number:");
        try
        {
            int answer = int.Parse(Console.ReadLine().Trim());
            chosen = products[answer - 1];
            Console.WriteLine($@"Are you sure you want to delete {chosen.Name}?
            1. Yes
            2. No");

            response = Console.ReadLine();

            if (response == "1")
            {
                products.RemoveAt(answer - 1);
                Console.WriteLine($"\n You have successfully deleted {chosen.Name}!\n");
                DisplayMenu();
            }
            else if (response == "2")
            {
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("You have entered an invalid entry. Please try again.\n");
                DeleteProduct(products, productTypes);
            }
            
        }
        catch
        {
            Console.WriteLine("You have entered an invalid entry. Please try again.\n");
            DeleteProduct(products, productTypes);
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Product newProduct = new Product()
    {
        Name = "",
        Price = 0.0M,
        ProductTypeId = 0
    };

    decimal price = 0.0M;
    string response = "";
    int id = 0;
    bool validNumber = false;

    Console.WriteLine("\nPlease enter the name of your new product.");
    while (response == "")
    {
        response = Console.ReadLine();
        newProduct.Name = response;
    }

    Console.WriteLine($"\nWhat is the price of the {newProduct.Name}?");
    response = Console.ReadLine();
    validNumber = decimal.TryParse(response, out price);
    if (validNumber == true)
    {
        newProduct.Price += price;
    }
    else
    {
        Console.WriteLine("\nSorry, you entered an invalid price, please try again.");
    }

    Console.WriteLine($"\nPlease select which product type the {newProduct.Name} should be in.\n");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
    try
    {
        id = int.Parse(Console.ReadLine().Trim());
        if (id <= productTypes.Count)
        {
            newProduct.ProductTypeId = id;
        }
        else
        {
            Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
            AddProduct(products, productTypes);
        }
    }
    catch
    {
        Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
        DisplayMenu();
    }

    products.Add(newProduct);

    Console.WriteLine($"\nCongratulations, you have successfully added a {newProduct.Name} to the products list!\n");
    DisplayMenu();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Product chosen = null;
    string response = "";
    string name = "";
    decimal price = 0.0M;
    int category = 0;
    bool validNumber = false;

    Console.WriteLine("\nPlease select which product you would like to update.\n");
    DisplayAllProducts(products, productTypes);

    while (response == "")
    {
        Console.WriteLine("\nEnter a product number:\n");
        try
        {
            response = Console.ReadLine().Trim();
            int answer = int.Parse(response);
            chosen = products[answer - 1];
        }
        catch
        {
            Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
            DisplayMenu();
        }
    }

    Console.WriteLine($"\nYou have selected {chosen.Name}.\n");
    Console.WriteLine(@"Please select the information you would like to update:
    1. Name
    2. Price
    3. Category");

    response = Console.ReadLine().Trim();

    if (response == "1")
    {
        Console.WriteLine("\nPlease enter the updated name of the product:\n");
        name = Console.ReadLine().Trim();

        if (name != "")
        {
            chosen.Name = name;
            Console.WriteLine($"\nYou have successfully updated the product name to {name}!\n");
        }
        else
        {
            Console.WriteLine("\nNo updates were made to the product.\n");
        }
    }
    else if (response == "2")
    {
        Console.WriteLine("\nPlease enter the updated price of the product:\n");
        string entry = Console.ReadLine().Trim();

        if (entry != "")
        {
            try
            {
                validNumber = decimal.TryParse(entry, out price);
                if (validNumber == true)
                {
                    chosen.Price = price;
                    Console.WriteLine($"\nYou have successfully updated the product price to ${price}!\n");
                }
            }
            catch
            {
                Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("\nNo updates were made to the product.\n");
        }
    }
    else if (response == "3")
    {
        Console.WriteLine("\nPlease select the updated category for the product:\n");
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }

        Console.WriteLine("Enter a product type number:");

        try
        {
            category = int.Parse(Console.ReadLine().Trim());
            if (category <= productTypes.Count)
            {
                chosen.ProductTypeId = category;
                Console.WriteLine($"\nYou have successfully update the product to product type number {category}!");
            }
            else
            {
                Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
            }
        }
        catch
        {
            Console.WriteLine("\nYou have entered an invalid entry. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("\nYou have entered an invalid entry. Please try again.\n");
    }

    DisplayMenu();
}

// don't move or change this!
public partial class Program { }