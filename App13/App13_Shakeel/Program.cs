using System;

class Program
{
    // Main() is called using main thread by CLR
    static void Main(string[] args)
    {
        ConsoleUI cui = new ConsoleUI(); //Main thread

        // cui is a referance variable holds on main thread stack
        // cui holds referance ConsoleUI object that is created on heap by CLR

        cui.Start(); // Main Thread
        // value of cui which is referance of ConsoleUI object is passed to Start Method
    }
}
