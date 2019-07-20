class MyClass
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Start entering the values, Type quit to Stop");

        double[] numbers = new double[0];
        while(true)
        {
            // Take the input from the user through console window
            string input = System.Console.ReadLine();

            // check if user entered quit
            if (input == "quit")
                break;

            // convert the input to a double 
            double number = System.Convert.ToDouble(input);

            // create an array of bigger size
            double[] bigger = new double[numbers.Length + 1];

            // copy elements from previous array to new bigger array
            for (int i = 0; i < numbers.Length; i++)
            {
                bigger[i] = numbers[i];
            }

            numbers = bigger; // copy the value from bigger to number (address)

            // store the value of latest number of array 

            numbers[numbers.Length - 1] = number;

        }  // bigger referance variable gets killed

        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        System.Console.WriteLine($"Sum of array elements = {sum}");

    }
}