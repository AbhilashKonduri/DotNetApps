using System;
using System.IO;

// Access modifiers that can be applied to a class are public and internal
internal class ConsoleUI
{
    // Access modifiers that can be applied to the members of the class are
    // internal, private,public,protected

    //Instance data Member or instance Fields
    private BooksLogic bl = new BooksLogic();

    internal ConsoleUI()
    {
        this.bl = new BooksLogic();
    }

    private Int32 DisplayMenu(/* ConsleUI this = reference of ConsoleUI object */)  //Main Thread
    
        // This DisplayMenu doesnt use the data member so this doesnot need "this" so it can be made static.
    {
        while (true) //Main Thread
        {
            Console.Clear();
            Console.WriteLine("1. Add Book"); //Main Thread
            Console.WriteLine("2. List Book"); //Main Thread
            Console.WriteLine("3. Save Book"); //Main Thread

            try
            {
                Console.Write("Select an Option : "); //Main Thread
                int option = Convert.ToInt32(Console.ReadLine()); //Main Thread

                if (option <1 || option >3)
                {
                    Console.WriteLine("Option Must be 1,2 or 3 ");
                }
                else
                {
                    return option;
                }
            }
            catch (FormatException ex) //Main Thread
            {
                Console.WriteLine(ex.Message); //Main Thread
            }
            catch (OverflowException ex) //Main Thread
            {
                Console.WriteLine(ex.Message); //Main Thread
            }
            Console.WriteLine("Hit Enter to Continue");
            Console.ReadLine();
        }
    }

    private void ListBook(/* ConsleUI this = reference of ConsoleUI object */)
    {
        Console.Clear();
        Console.WriteLine($"Title\t\tAuthor\t\tPrice");

        foreach (Book book in this.bl.Books)
        {
            Console.WriteLine($"{book.Title}\t\t{book.Author}\t\t{book.Price}");
        }

        Console.WriteLine("Hit Enter to Continue");
        Console.ReadLine();
    }
    private void AddBook(/* ConsleUI this = reference of ConsoleUI object */)
    {
        Console.Clear();

        while (true)
        {
            Console.Write(" Enter the Title: "); //Main Thread
            string title = Console.ReadLine(); //Main Thread

            Console.Write(" Enter the Author: "); //Main Thread
            string author = Console.ReadLine(); //Main Thread

            Console.Write(" Enter the Price: "); //Main Thread
            double price = Convert.ToInt64(Console.ReadLine()); //Main Thread

            //Store the in the book object and store the refernece of Book object in list<>
            this.bl.AddBook(title, author, price); //Main Thread

            // value of bl which is reference of books logic object will be passed to AddBook Method

            Console.WriteLine("Do you want to add more books? "); //Main Thread
            string choice = Console.ReadLine(); //Main Thread

            if (choice =="n") //Main Thread
            {
                break; //Main Thread
            }
        }

    }

    private void SaveBooks()
    {
        this.bl.SaveBooks();
    }

    internal void Start(/* ConsleUI this = reference of ConsoleUI object */) //Main Thread
    {
        try
        {
            this.bl.LoadBooks();
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine("No Books Available ");
            Console.WriteLine(ex.Message);
        }

        while (true) //Main Thread
        {
            int option = this.DisplayMenu(); //Main Thread

            //value of this which is referance of cui object is passed to displayMenu method

            if (option == 1)
            {
                this.AddBook();//Main Thread

                //value of this which is referance of cui object is passed to AddBook method

            }

            if (option == 2) //Main Thread
            {
                this.ListBook(); //Main Thread
            }

            if (option == 3) //Main Thread
            {
                this.SaveBooks(); //Main Thread
                // value of thsi which is reference of consoleUI object is passsed to SaveBooks
            }

        } //Main Thread
    }


}