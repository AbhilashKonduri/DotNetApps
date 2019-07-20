using System;
using System.Threading;
using System.Threading.Tasks;

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
    // event- for registration and unregistration of EventHandler in Thread-Safe manner
    // event - it is written to meta data section so that Visual Studio can show lightning bolt sign in intellisense

    public event MultiplicationResult ResultEvent; // by default null
    // untill some object register event handler with it

    public utility()
    {
        Task.Run(() =>
        {
            this.MultiplicationTable(5); //Secondary Thread
        }
        );
    }
    public async void MultiplicationTable(int number) //ST
    {
        for (int i = 0; true; i++) //ST
        {
            int result = number * i; //ST
                                     //Should make a callback with all the data that is required by caller.

            ResultEvent?.Invoke(number, i, result); // notification. ? is to check if resultevent is null if it is not null
            // then we will call back

            await Task.Delay(1000); //5 seconds delay
        } //ST
    } //ST
} //ST


//Caller Devoloper 2
class Program
{
    static void Reciever1 (int number, int i , int result)
    {
        Console.WriteLine($"Reciever 1 : {result}");
    }
    static void Reciever2(int number, int i, int result)
    {
        Console.WriteLine($"Reciever 2 : {result}");
    }

    // Main Thread
    static void Main()
    {
        utility u = new utility(); //MT


        Console.Write("Hit Enter to register the reciever 1......"); //MT
        Console.ReadLine(); //Blocking Call
        u.ResultEvent += Reciever1; // C# Compiler will generate : new MultiplicationResult (Reciever 1)

        Console.Write("Hit Enter to register the reciever 2......"); //MT
        Console.ReadLine(); //Blocking Call
        u.ResultEvent += Reciever2; // C# Compiler will generate : new MultiplicationResult (Reciever 2)

        Console.Write("Hit Enter to un-register the reciever 1......"); //MT
        Console.ReadLine(); //Blocking Call
        u.ResultEvent -= Reciever1;

        Console.Write("Hit Enter to un-register the reciever 2......"); //MT
        Console.ReadLine(); //Blocking Call
        u.ResultEvent -= Reciever2;

        Console.WriteLine("Hit enter to end the main");
        Console.ReadLine(); //Blocking Call

    }
}

