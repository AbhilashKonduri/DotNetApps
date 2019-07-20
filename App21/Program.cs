using System;
using System.Collections.Generic;
using System.Linq; //Language integrated Query


namespace App21
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = { 10, 21, 30, 41, 50 };

            Console.WriteLine("Sum = " + numbers.Sum());

            Console.WriteLine("Sum = " + (from number in numbers where number%2 !=0 select number).Sum());

            Console.WriteLine("Sum = " + (from number in numbers where number % 2 == 0 select number).Sum());

            Book[] books =
            {
                new Book() {Title ="T1",Author ="A1", Price =1000 },
                new Book() {Title ="T2",Author ="A1", Price =4000 },
                new Book() {Title ="T3",Author ="A2", Price =2000 },
                new Book() {Title ="T4",Author ="A1", Price =3000 },

            };

            Console.WriteLine("Enter the Author Name : ");
            string author = Console.ReadLine();

            Book[] booksbyauthorA1 = (from book in books where book.Author == author select book).ToArray();
            foreach (var book in booksbyauthorA1)
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("Sum of the prices = " +(from Book in booksbyauthorA1 select Book.Price).Sum());
        }
    }
    
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

    }

}
