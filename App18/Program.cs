using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<String, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("a1", "a1");
        dictionary.Add("b1", "b1");
        dictionary.Add("c1", "c1");

        while (true)
        {
            Console.Write("Enter the word : ");
            string word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine(dictionary[word]);
            }
            else
            {
                Console.WriteLine("I donot know the word");
            }
        }
       

    }
}

