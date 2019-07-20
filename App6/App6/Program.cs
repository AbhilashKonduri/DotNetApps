class App6
{
    static void Main()
    {
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length;)
        {
            try
            {
                System.Console.Write("Enter a Number");
                numbers[i] = System.Convert.ToInt32 (System.Console.ReadLine());
                i++;
            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        // The biggest numbers of Array

        int biggest = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[0])
            {
                biggest = numbers[i];
            }
        }
        System.Console.WriteLine($"Biggest = {biggest}");

        // The smallest numbers of Array


        int smallest = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < numbers[0])
            {
                smallest = numbers[i];
            }
        }
        System.Console.WriteLine($"Smallest = {smallest}");

        // The sum of numbers of Array

        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i]; 
        }
        System.Console.WriteLine($"Sum = {sum}");

        // Sort the Array in ascending order
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; i++)
                {
                    
                }


        }


        // Sort the Array in decending order

    }
}