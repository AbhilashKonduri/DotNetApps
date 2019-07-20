using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SampleImplementation1 : QuestionsDataAccessLayer
{
    public override List<Question> GetQuestions()
    {
        return new List<Question>()
        {
            new Question() { Statement ="ZZZZ" , Option1 = "Z1",Option2 ="Z2",Option3 ="Z3" ,Option4 ="Z4", CorrectAnswer = 3 ,Marks = 5 }
        };
    }
}