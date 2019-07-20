using System;
using System.Collections.Generic

class Question
{
    string _statement, _option1, _option2, _option3, _option4;
    int _correctanswer, _marks;

    //properies
    public string Statement
    {
        get
        {
            return _statement;
        }
    }
    public string Option1
    {
        get
        {
            return _option1;
        }
    }
    public string Option2
    {
        get
        {
            return _option2;
        }
    }
    public string Option3
    {
        get
        {
            return _option3;
        }
    }
    public string Option4
    {
        get
        {
            return _option4;
        }
    }
    public int CorrectAnswer
    {
        get
        {
            return _correctanswer;
        }
    }
    public int Marks
    {
        get
        {
            return _marks;
        }
    }

    public Question( /*this */string statement, string option1, string option2, string option3, string option4, int correctanswer, int marks)
    {
        this._statement = statement;
        this._option1 = option1;
        this._option2 = option2;
        this._option3 = option3;
        this._option4 = option4;
        this._correctanswer = correctanswer;
        this._marks = marks;
    }
}

class DataAccessLayer
{
    public Question[] GetQuestions()
    {
        Question[] questions = new Question[5];
        questions[0] = new Question("11111", "A", "B", "C", "D", 1, 10);
        questions[1] = new Question("22222", "A", "B", "C", "D", 1, 10);
        questions[2] = new Question("33333", "A", "B", "C", "D", 1, 10);
        questions[3] = new Question("44444", "A", "B", "C", "D", 1, 10);
        questions[4] = new Question("55555", "A", "B", "C", "D", 1, 10);

        return questions;
    }
}

class Results
{

}

class BusinessLogicLayer
{
    int index = 0;
    Question[] questions = new Question[5];
    int _usermarks = 0;
    int _totalmarks = 0;


    public BusinessLogicLayer()
    {
        DataAccessLayer dal = new DataAccessLayer();
        questions = dal.GetQuestions();
        for (int i = 0; i < questions.Length; i++)
        {
            _totalmarks += questions[i].Marks;
        }
    }
    public Question GetNextQuestion()
    {
        if (index == questions.Length)
        {
            return null;
        }
        else
        {
            return questions[index++];
        }
    }

    public void Checkresponse(int option)
    {
        if (option == questions[index - 1].CorrectAnswer)
        {
            _usermarks += questions[index - 1].Marks;
        }
        else
        {

        }
    }
}

class PresentationLayer
{
    public void Start()
    {
        BusinessLogicLayer bll = new BusinessLogicLayer();
        while (true)
        {
            Question question = bll.GetNextQuestion();
            if (question == null)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Question: {question.Statement}");
                Console.WriteLine($"1: {question.Option1}");
                Console.WriteLine($"2: {question.Option2}");
                Console.WriteLine($"3: {question.Option3}");
                Console.WriteLine($"4: {question.Option4}");
                Console.WriteLine($"Marks: {question.Marks}");

                Console.WriteLine("Please enter your response: ");
                int option = Convert.ToInt32(Console.ReadLine());

                bll.Checkresponse(option);

            }

        }
    }


}

class Application
{
    static void Main()
    {
        PresentationLayer Pl = new PresentationLayer();

        Pl.Start();
    }
}