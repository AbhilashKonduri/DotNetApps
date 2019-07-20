using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; //Namespace for JSON Serialization and Deserialization

class DataAccessLayer
{
    /// <summary>
    /// Saves Books in JSON format to books.json
    /// </summary>
    /// <param name="books">List of books</param>
    /// <exception cref=""/>
    internal void WriteBooksToFile(List<Book> books)
    {
        //Json Serialization that can give string data format with description 
        // and we can easily write to file
        // JSON Serialization: Converting Object in Ram to string Format

        string jsonstring = JsonConvert.SerializeObject(books);
        StreamWriter sw = new StreamWriter("books.json");
        sw.Write(jsonstring);
        sw.Close();
    }

    /// <summary>
    /// This function reads the data from Books.json
    /// </summary>
    /// <returns> Reference of List of Books object </returns>
    /// <exception cref="FileNotFoundException"/>
    internal List<Book>  ReadBooksToFile()
    {
        //JSON Deserialization can be done by reading data from file.
        //JSON Dserialization: Converting string data to Objects in RAM
        //try
        //{
            StreamReader sr = new StreamReader("books.json"); //Opens file in Read Mode
            string jsonstring = sr.ReadToEnd();
            sr.Close();
            return JsonConvert.DeserializeObject<List<Book>>(jsonstring);
        //}

        //catch(Exception ex)
        //{
        //    throw ex;
        //}

    }
}
