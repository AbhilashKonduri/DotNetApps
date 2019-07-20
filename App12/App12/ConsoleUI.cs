using System;
using System.Collections.Generic;

class ConsoleUI
{
    // NO instance Data Members

    public void Start(/*ConsoleUI this = referance of calling object */)
    {
        TestLogic logic = new TestLogic();
        while(true)
        {
            Question question = logic.GetNextQuestion();

            if (question == null)
            {
                break;
            }

            Console.WriteLine($"Statement : {question.Statement}");
            Console.WriteLine($"Option1 : {question.Option1}");
            Console.WriteLine($"Option2 : {question.Option2}");
            Console.WriteLine($"Option3 : {question.Option3}");
            Console.WriteLine($"Option4 : {question.Option4}");
        }
    }
}
