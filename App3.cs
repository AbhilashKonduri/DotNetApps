class App3
{
	//CSC marks the Main() as the entry point. CLR calls it at runtime
	static void Main()
	{
	System.String input1 = System.Console.ReadLine();
	System.String input2 = System.Console.ReadLine();
	
	//System.String Result = input1 + "  " +  input2; // concatination
	
	System.Double Result = System.Convert.ToDouble(input1) + System.Convert.ToDouble(input2);
	
	System.Console.WriteLine(Result);
	}
}