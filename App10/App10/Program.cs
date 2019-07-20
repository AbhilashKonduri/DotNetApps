using System; // system is name space // Console class
using System.Collections.Generic; // System.Collections.Generic namespace //List<>

// Devolop Computer Based Test Application

//Display one question at a time to user
//A question contains 1 statement, 4 options, 1option as correct and marks
//Display satement, 4 options and marks to the user and ask the user to select
//An option. After user selects an option, display next question and so on.
//When all questions are done show user marks and total marks
// for the wrong questions show correct answers in green and user option in red.

// Business Application - 3 Layer architecture
//1.Data Access layer - prepare the data to fetch the data frpm file or DB
//2. Busines logic layer - Compute on the data from memory
//3. Presentation Logic layer - IO with the user


class Question // new data type - To create Multiple Instances from it
{
    //Instance Fields - Instance Data Members - become part of each instance
    string _statement, _option1, _option2, _option3, _option4;
    int _correctanswer, _marks;

    //property
    public string Statement
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._statement;
        }
    }

    public string Option1
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._option1;
        }
    }

    public string Option2
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._option2;
        }
    }
    public string Option3
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._option3;
        }
    }
    public string Option4
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._option4;
        }
    }
    public int Marks
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._marks;
        }
    }

    public int CorrectAnswer
    {
        get  // if in data members given Correctanswers this may end up having same name for property name and variable name which leads to stack overflow.
            //so put _ before data members and no _ in the property name
        {
            return this._correctanswer;
        }
    }

    // Initialize the instance data members of each instance (object) -constructor
    public Question(/* Questhion this = ref. of instance */ string statement , string option1, string option2, string option3, string option4, int correctanswer, int marks)
    {
        this._statement = statement;
        this._option1 = option1;
        this._option2 = option2;
        this._option3 = option3;
        this._option4 = option4;
        this._correctanswer = correctanswer ;
        this._marks = marks;
    }        

}

// Data Access Layer : This should prepare the data or fetch the data 
class HardQuotedQuestions // referance type
{
    public Question[] GetQuestions(/* HardQuotedQuestions this = ref of object*/)
    {
        Question[] questions = new Question[3];
        // question is a ref variable that holds referance of array object with length 3
        // the array object has referance variable that refers to actual array
        // the actual array is of 3 question referance variables

        questions[0] = new Question("AAA", "A1", "A2", "A3", "A4", 1, 10);
        //Every object creation is 2 step process
        //1. memory is allocated based on how many instance data members are there
        //2. questions(ref of Question object , "AAA" , , ...)
        //After object is created referanc eis returned and stored in ref variable ie., question[0]

        questions[1] = new Question("AAA", "A1", "A2", "A3", "A4", 2, 7);
        //Every object creation is 2 step process
        //1. memory is allocated based on how many instance data members are there
        //2. questions(ref of Question object , "AAA" , , ...)
        //After object is created referanc eis returned and stored in ref variable ie., question[1]

        questions[2] = new Question("AAA", "A1", "A2", "A3", "A4", 3, 5);
        //Every object creation is 2 step process
        //1. memory is allocated based on how many instance data members are there
        //2. questions(ref of Question object , "AAA" , , ...)
        //After object is created referanc eis returned and stored in ref variable ie., question[2]

        return questions; // return value of questions - referance of array objects
    }
}

class Result
{
    private Question _question;
    private int _wronganswer;

    public Question Question
    {
        get // Question get_Question (this)
        {
            return this._question;
        }

        set // void set_Question (Result this, Question Value)
        {
            _question = value;
        }
    }

    public int Wronganswwer
    {
        get // string get_statement (Question this = ref. of the object)
        {
            return this._wronganswer;
        }
        set // void set_Wrongnumber (Result this, int Value)
        {
            _wronganswer = value;
        }
    }
}

class BusinessLogicLayer
{
    private Question[] questions; //Instance Data Members
    private int index = 0;
    private int _usermarks = 0;
    private List<Result> _results = new List<Result>(); // initially zero size array and then dynamically increases
    private int _totalmarks =0;
    private int _totalquestions = 0;
    private int questionsdone = 0;
    //property

    public int TotalQuestions
    {
        get
        {
            return this.questions.Length;
        }
    }

    public int QuestionsDone
    {
        get
        {
            return this.index;
        }
    }


    public int TotalMarks
    {
        get
        {
            return _totalmarks;
        }
    }

    public int Usermarks
    {
        get
        {
            return _usermarks;
        }
    }

    public List<Result> Results
    {
        get
        {
            return _results;
        }
    }
    public BusinessLogicLayer()
    {
        HardQuotedQuestions hcq = new HardQuotedQuestions();
        this.questions = hcq.GetQuestions(); //HardQuotedQuestions.GetQuestions( value of hcq)
        for (int i = 0; i < this.questions.Length; i++)
        {
            _totalmarks += this.questions[i].Marks; 
        }
    }

    public Question GetNextQuestion(/* BusinessLogicLayer this = ref. of object */)
    {
        if (this.index == this.questions.Length)
        {
            return null;
        }
        else
        {
            return this.questions[this.index++]; // returning referance of Question object
        }
    }

    public void CalculateMarks(/* this = ref. of the object */ int option)
    {
        if (option == this.questions[index-1].CorrectAnswer)
        {
            _usermarks += this.questions[index + 1].Marks;
        }
        else
        {
            Result result = new Result();
            result.Question = this.questions[index - 1];
            result.Wronganswwer = option;

            _results.Add(result);
        }
    }
}

//  Presentation Logic layer - IO with the user
// Graphical (Desktop/PC), MAC,Mobile. Web, Console, Voice or Gesture
class ConsoleIO
{
    //Instance Method
    public void Start( /* ConsoleUI this = referance of object */) 
    {
        //1. Get one question and display it in the user
        BusinessLogicLayer bll = new BusinessLogicLayer();

        // bll is a referance variable that holds referance of object
        // the object is created in heap
        //bll is created on stack
        while (true)
        {
            Question question = bll.GetNextQuestion(); // get one question at a time
            if (question == null)
            {
                break;
            }
            else
            {
                System.Console.Clear();
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
                System.Console.WriteLine(question.Statement);
                System.Console.WriteLine($"1: {question.Option1}");
                System.Console.WriteLine($"2: {question.Option2}");
                System.Console.WriteLine($"3: {question.Option3}");
                System.Console.WriteLine($"1: {question.Option1}");
                System.Console.WriteLine($"Marks: {question.Marks}");

                System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                System.Console.Write("Select an Option : ");
                int option = System.Convert.ToInt32(System.Console.ReadLine());

                bll.CalculateMarks(option);
            }
        } // while ends

       
        if (bll.Results.Count >0)
        {
            for (int i = 0; i < bll.Results.Count; i++)
            {
                Console.WriteLine(bll.Results[i].Question.Statement);

                string CorrectOptionText = " ";
                switch(bll.Results[i].Question.CorrectAnswer)
                {
                    case 1:
                        CorrectOptionText = bll.Results[i].Question.Option1;
                        break;
                    case 2:
                        CorrectOptionText = bll.Results[i].Question.Option2;
                        break;
                    case 3:
                        CorrectOptionText = bll.Results[i].Question.Option3;
                        break;
                    case 4:
                        CorrectOptionText = bll.Results[i].Question.Option4;
                        break;
                }

                string WrongOptionText = " ";
                switch (bll.Results[i].Wronganswwer)
                {
                    case 1:
                        WrongOptionText = bll.Results[i].Question.Option1;
                        break;
                    case 2:
                        WrongOptionText = bll.Results[i].Question.Option2;
                        break;
                    case 3:
                        WrongOptionText = bll.Results[i].Question.Option3;
                        break;
                    case 4:
                        WrongOptionText = bll.Results[i].Question.Option4;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"User Option is : {WrongOptionText}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Correct Answer is : {CorrectOptionText}");
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You Obtained {bll.Usermarks} out of {bll.TotalMarks}");

        }

    }

}
class Application
{
    static void Main()
    {
        ConsoleIO cui = new ConsoleIO();
        //cui is a referance variable that holds referance of Console UI object
        // the object is created in heap
        //cui is on stack

        cui.Start(); //ConsoleUI.start(Value of cui = referance of object)
    }
}