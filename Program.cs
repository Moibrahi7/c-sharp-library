using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using libraryDataLoader;

namespace library;

public static class Program{
        public static Librarian librarian = new Librarian("Rachel", "Rachel@email.com", "12345Books", 1);
        public static Library lib = new Library("1", librarian);

    public static void Main(string[] args){
        
        List<Book> books = new List<Book>();

        // books.Add(new Book("John's Book", "John Book", 34));
        // books.Add(new Book("John's New Book", "John Book", 35));
        books.Add(new Book("John's Newer Book", "John Book", 36));
        books.Add(new Book("John's Newest Book", "John Book", 37));

        foreach(Book b in books){
            lib.AddMediaItem(b);
        }
        bool exit = false;
        string name = "";
        string email = "";
        string password = "";

        Guest guest2 = new Guest("Mohi", "mohamed@gmail.com", "1234", new Guid("d40d72c7-6963-414b-906c-0e2226d24b25"));
        Guest guest1 = new Guest(name, email, password);
        Guest currGuest = guest1;
        lib.addGuest(guest2);
        DataLoader dat = new DataLoader();
        dat.loadData("lib_items/resources/libData.json");
        Console.WriteLine("Welcome to the C# Library!");
        while(!exit){
            
            if (name == ""){
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine().ToString();
                while (name == ""){
                    Console.WriteLine("Please enter a valid name");
                    name = Console.ReadLine();

                }
                guest1.Name = name;
                Console.WriteLine("Please Enter a valid email for " + name + ":");
                email = Console.ReadLine();
                while (email == ""){
                    Console.WriteLine("Please enter a valid email");
                    email = Console.ReadLine();
                }
                guest1.Email = email;
                Console.WriteLine("Please Enter a valid password for " + name + ":");
                password = Console.ReadLine();
                while (password == ""){
                    Console.WriteLine("Please enter a valid password");
                    password = Console.ReadLine();
                }
                guest1.changePassword("", password);
                lib.addGuest(guest1);
            }
            Console.WriteLine("Please make a selection bellow " + currGuest.Name + " to get started");
            Console.WriteLine("1: Change name");
            Console.WriteLine("2: Browse Media items");
            if(currGuest.CheckedOutBooks.Count != 0){
                Console.WriteLine("3: Look at checked out items");
                Console.WriteLine("4: Check out a item");
                Console.WriteLine("5: Return checked out item");
            }
            else{
                Console.WriteLine("3: Check out a item");
            }
            Console.WriteLine("-: Switch Guest");
            Console.WriteLine("0: exit");
            string userIn = Console.ReadLine();
            switch(userIn){
                case "1":
                    name = Console.ReadLine();
                    while (name == ""){
                        Console.WriteLine("Please enter a valid name");
                        name = Console.ReadLine();
                    }
                    currGuest.Name = name;
                    break;
                case "2":
                    foreach(KeyValuePair<Guid, MediaItem> item in lib.MediaItemsById){
                        if (!(item.Value.IsCheckedOut)){
                            Console.WriteLine(item.Value.ToString());
                        }
                    }
                    break;
                case "3":
                    if (currGuest.CheckedOutBooks.Count != 0){
                        Console.WriteLine("Your check out items are");
                        foreach(MediaItem it in currGuest.CheckedOutBooks){
                            Console.WriteLine(it.ToString());
                        }
                    }
                    else{
                        Console.WriteLine("Enter the ID of the book you want to check out: ");
                        string inp = Console.ReadLine();
                        Guid queary = Guid.Parse(inp);
                        lib.checkOutItem(librarian, currGuest, lib.findItem(queary));
                    }
                    break;
                case "4":
                    if (currGuest.CheckedOutBooks.Count != 0){
                        Console.WriteLine("Enter the ID of the book you want to check out: ");
                        string inp = Console.ReadLine();
                        Guid queary = Guid.Parse(inp);
                        lib.checkOutItem(librarian, currGuest, lib.findItem(queary));
                    }
                    else {
                        Console.WriteLine("Invalid Input!");
                    }
                    break;
                case "5":
                    if (currGuest.CheckedOutBooks.Count != 0){
                        Console.WriteLine("Enter the ID of the book you want to return: ");
                        string inpu = Console.ReadLine();
                        Guid quea = Guid.Parse(inpu);
                        lib.returnItem(librarian, currGuest, lib.findItem(quea));
                    }
                    else {
                        Console.WriteLine("Invalid Input!");
                    }
                    break;
                case "-":
                    Console.WriteLine("Input guest id:");
                    string input = Console.ReadLine();
                    Guid que = Guid.Parse(input);
                    Guest temp = lib.findGuest(librarian ,que);
                    Console.WriteLine("Input " + temp.Name + "'s password:");
                    string passIn = Console.ReadLine();
                    if (temp.checkPassword(passIn)){
                        currGuest = temp;
                    }
                    else{
                        Console.WriteLine("The password was incorrect!");
                    }
                    break;
                case "0": 
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
        
            
            }

        }
    }

}
