using System;
using System.Collections.Generic;

//Encapsulating the DatabaseQuestions
class DatabaseQuestions : QuestionsDataAccessLayer
{
    public override List<Question> GetQuestions(/* HardCodedQuestions this = referance of calling object */)
    {
        return new List<Question>(); //return referance of List<> object
    }

}

