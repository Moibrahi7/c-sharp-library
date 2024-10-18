using System.Collections.Generic;

namespace library;

public class Program
{

    public static void Main(string[] args){
    string author = "John Book";
    MediaItem item = new Book("Biogrophy of John book", author, 3890);
    Console.WriteLine(item.Title);
    Console.WriteLine("Who is checking out " + item.Title + "?");
    string user = (string) Console.ReadLine();

    item.checkOut(user);

    }

}
