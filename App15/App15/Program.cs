using System;

delegate void MultiplicationResult(int number, int i, int result); 
//Signature of function that we want to call back
//MultiplicationResult is a class name
// means C# Compiler creates a class from delegate instructions


/*
 class MultiplicationResult // to create objects and reference variable
 {
    void(*FunctionPointer)(int number, int i, int resut); // to hold refernce of a function
    ReferanceVariabl; // reference of an object to e passes to the callback function
 
    public MultiplicationResult (MultiplicationResult this ,fp, rv = null)
    {
        FunctionPointer = fp;
        ReferenceVariable =rv;
    }
    
    void Invoke( MultiplicationResult this = value of mr,int number, int i, int result)
    {
        if(referancevariable != null)
            this.FunctionPointer (referancevariable value, number, i ,result); // to call instance method
        else
            this.FunctionPointer(number,i,result); // to call static method
    }
 */


//Callee Devoloper 1 (makes callback) - (caller of callback function)
class utility
{
    // mr is a reference variable
    //caller of callback - caller always creates object for the delegate class
    // mr will recieve referance of delegate object
    // the delegate object holds address of function and [ref of object to be passes to function]
    // if function is static ref of object to be pases = null
    public static void multiplicationTable(int number, MultiplicationResult mr)
    {
        for (int i = 0; i < 10; i++)
        {
            int result = number * i;
            //Should make a callback with all the data that is required by caller.

            mr.Invoke(number, i, result); //callback with the help of delegate object
        }
    }
}

class Sample
{
    public int Id { get; set; } //Instance property with Instance data member

    // This gets called 10 times
    public void receiver3 (/* Sample this */ int number, int i, int result)
    {
        Console.WriteLine($"{Id} - {result}");
    }
}

//Caller Devoloper 2
class Program
{
    //doesnt have this
    // will get called 10 times
    static void Receiver1 (int number , int i , int result)
    {
        Console.WriteLine($"{number} X {i} = {result}");
    }

    //doesnt have this
    // will get called 10 times
    static void Receiver2(int number, int i, int result)
    {
        Console.WriteLine($"{result} = {number} X {i} ");
    }
    static void Main()
    {
        // new MultiplicationResult creates object 
        // reciever of callback - callee always creates object
        utility.multiplicationTable(5 , new MultiplicationResult(Program.Receiver1)); //EarlyBound call
        utility.multiplicationTable(6, new MultiplicationResult(Program.Receiver2)); //EarlyBound call

        Sample S1 = new Sample() { Id = 101};
        Sample S2 = new Sample() { Id = 201 };

        utility.multiplicationTable(7, new MultiplicationResult(S1.receiver3)); //Early Bound Call
        utility.multiplicationTable(8, new MultiplicationResult(S2.receiver3)); // Early Bound Call

        utility.multiplicationTable(9, (number, i, result) =>
        {
            Console.WriteLine($"Lambda : {result}"); //Lambdas are used for callbacks
        }
        ); // Early Bound Call

    }
}

