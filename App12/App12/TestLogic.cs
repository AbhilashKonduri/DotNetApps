using System;
using System.Collections.Generic;

//Implementation Class
class TestLogic
{
    //Instance Data Member or Instance field
    List<Question> questions;
    int index = 0;


    public TestLogic(/* TestLogic this = referance of newly created object */) 
    {
        //   HardCodedQuestions hq = new HardCodedQuestions(); //Tight Coupling

        // Our code is based on abstraction and not on Implementation
        //Hence this code is extensible  - when new implementations come
        // this code is not required to be changed.

        QuestionsDataAccessLayer dal = Factory.GetQuestionsDataAccessLayer(); 
        
        //dal is a reference variable
        this.questions =  dal.GetQuestions();
        //Using reference variable of Abstraction type to call the function
        //Run time polymorphism
        //late binding


    } // dal will die
      //// hq referance variable and object will die

    public Question GetNextQuestion()
    {
        if (this.index < this.questions.Count)
        {
            return this.questions[this.index++];
        }
        else
        {
            return null;
        }

    }

}
