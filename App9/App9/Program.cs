//Not useful right Now

class DynamicallyGrowingArray
{
    //Instance data Member or Instance Field (It will become part of an object of the class)
    private double[] numbers = new double[0];

    public int Length
    {
        get  //int get_length()  --- it is a property
        {
            return numbers.Length;
        }
    }


    //indexed property (indexer)
    public double this[int index]
    {
        get  //int get_length() -- method
        {
            return numbers[index];
        }
    }

    //Instance Methods - Loaded once in memory
    public void Add(/* DynamicallyGrowingArray this */ double number)
    {
        // create an array of bigger size
        double[] bigger = new double[numbers.Length + 1];

        // copy elements from previous array to new bigger array
        for (int i = 0; i < this.numbers.Length; i++)
        {
            bigger[i] = numbers[i];
        }

        numbers = bigger; // copy the value from bigger to number (address)

        // store the value of latest number of array 

        numbers[numbers.Length - 1] = number;
    } // bigger referance variable gets killed
}


//Implement Stack DataStructure - Multi Instance Design
class Stack<T> //Generic Type
{
    //Instance Data Members or Instance fields
    T[] items = new T[10];
    int top = 0;

    //Instance Methods #5000
    public void Push(/* stack this */ T item)
    {
        items[top] = item; // this.items [this.top] = item
        top++; //this.top++
    }

    //#6000
    public T Pop(/*stack this*/)
    {
        top--; // this.top--
        return items[top]; // return this.items[this.top]
    }

    public void clear(/* stack this*/)
    {
        top = 0; // this ->top
    }
}

class App9
{
    static void Main()
    {
        Stack<int> s1 = new Stack<int>();
        // S1 is a referance variable that can hold referance of the object
        // new is a call to the CLR to create an object
        // new returns referance of object after it has been created
        // this referance is stored in S1
        //S1 is created on stack and object is stored in heap
        // S1 is short lived
        //Object is long lived

        Stack<double> s2 = new Stack<double>();
        //S2 is a referance variable created on stack

        Stack<char> s3 = new Stack<char>();
        //S2 is a referance variable created on stack

        s1.Push(100); // stack.push(s1,100) ; // jmp 5000 (s1, 100) //Early Binding -> COMPILER associates the address of the function before execution. If this happens at run time it is late binding or run time binding
        s2.Push(200); // stack.push(s2,200) ; // jmp 5000 (s2, 200) //Early Binding -> COMPILER associates the address of the function before execution. If this happens at run time it is late binding or run time binding
        s1.Pop(); // pop(s1)
    }
}

