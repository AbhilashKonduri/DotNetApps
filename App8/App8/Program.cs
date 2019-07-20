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


class MyClass
{
    static void Main(string[] args) // doesn't have this as object parameter as it is static
    {
        DynamicallyGrowingArray da = new DynamicallyGrowingArray();

        // da is a 'reerance variable' that holds referance of the object
        // new is a call to CLR to create an object

        System.Console.WriteLine("Start entering the values, Type quit to Stop");

        while (true)
        {
            // Take the input from the user through console window
            string input = System.Console.ReadLine();

            // check if user entered quit
            if (input == "quit")
                break;

            // convert the input to a double 
            double number = System.Convert.ToDouble(input);

            da.Add(number); 
        }  

        double sum = 0;
        for (int i = 0; i < da.Length; i++)
        {
            sum += da[i];
        }
        System.Console.WriteLine($"Sum of array elements = {sum}");

    }

}