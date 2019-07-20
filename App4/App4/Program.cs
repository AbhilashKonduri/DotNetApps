class App4
{
    static void Main()
    {
        double Sum = 0;
        for (int i = 0; i < 5; i++)
        {
            System.Console.Write("Enter the Number : ");

            double number = System.Convert.ToDouble(System.Console.ReadLine());

            Sum += number;
        }

        System.Console.WriteLine("Sum = " + Sum);

    }
}