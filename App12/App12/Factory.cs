using System;
using System.Collections.Generic;
using System.Configuration; //namespace

//Simple Factory - class with static method with type casting the return to abstract class type

class Factory
{
    //There are no data members
    public static QuestionsDataAccessLayer GetQuestionsDataAccessLayer() // no this as it is static - static since no data members.
                                                                        // we need not have a referance to access data. the calss name is enough as it is of static type
    {
        string value = ConfigurationManager.AppSettings["DAL"];

        string[] items = value.Split(';');
        
        //items[0] = Application
        //items[1] = value

        return Activator.CreateInstance(items[0] , items[1]).Unwrap() as QuestionsDataAccessLayer;



        //return new FileQuestions(); //Instantiating Implimentation Class
                                         // means Creating object of the Implementation Class
                                         //Type casting the HardCodedQuestions to QuestionDataAccessLayer
    }
}
