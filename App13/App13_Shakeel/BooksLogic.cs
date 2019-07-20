using System;
using System.IO;
using System.Collections.Generic;

class BooksLogic
{
    private List<Book> books = new List<Book>();

    //Instance Data Member
    // books is a reference variable that holds referance of the list object
    DataAccessLayer dal = new DataAccessLayer(); // thsi is actually done in constructor

    /// <summary>
    /// This Function calls into DAL
    /// </summary>
    /// <exception cref="FileNotFoundException"/>
    public void LoadBooks()
    {
        this.books = dal.ReadBooksToFile();
    }
    public List<Book> Books
    {
        get
        {
            return books;
            // returning reference of the books object
        }
    }
    internal void AddBook(/* Bookslogic this = reference of books logic object */ string title, string author, double price) // Main Thread
    {
        this.books.Add(new Book() { Title = title, Author = author, Price = price });
        // reference of book goes inside list
    }

    internal void SaveBooks()
    {
        dal.WriteBooksToFile(this.books);
    }
}

