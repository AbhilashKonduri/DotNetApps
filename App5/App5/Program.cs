class App5
{
    static void Main()
    {
        while (true)
        {
            try
            {
                System.Console.Write("Enter a Number : ");
                int number = System.Convert.ToInt32(System.Console.ReadLine());

                for (int i = 0; i <= 10; i++)
                {
                    int result = number * i;
                    System.Console.WriteLine($" {number} X {i} = {result}");
                }

                System.Console.WriteLine("Do you want to continue ?");
                string choice = System.Console.ReadLine();
                if (choice == "y")
                    continue;
                else
                    break;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
