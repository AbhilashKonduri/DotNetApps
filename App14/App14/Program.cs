using System;
using System.Collections.Generic;

class App14
{               
    // Main is called by CLR using Main Thread 
    static void Main() //Main Thread
    {
        ConsoleUI cui = new ConsoleUI(); //Main Thread
        //cui is a referance variable will be created on main thread stack
        // ConsoleUI object will be created on Heap
        cui.Show();

    }
}
