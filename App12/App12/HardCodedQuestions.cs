using System;
using System.Collections.Generic;


// Implementation Class
//Hiding the Implementation class behind abstraction is called "Encapsulation"
class HardCodedQuestions : QuestionsDataAccessLayer
{
    //There are no instance data members

    // Implementing Method of abstraction to perform specific Work
    public override List<Question> GetQuestions(/* HardCodedQuestions this = referance of calling object */)
    {
        List<Question> questions = new List<Question>();
        //questions is a referance variable created on stack
        // new calls the CLR to create object of list<> on heap
        // questions hold the referance of object

        questions.Add(new Question() { Statement ="AAA" , Option1 = "A1" , Option2 ="A2" , Option3 = "A3", Option4 = "A4" , CorrectAnswer = 1, Marks = 5 }); 
        
        // no need of constructor we can initialize like this
        // "new" with the help of CLR constructs the object and returns referance of the object, that we are passing Add() of List<>
        // Add stores that in the array that list holds
        questions.Add(new Question() { Statement = "BBB", Option1 = "B1", Option2 = "B2", Option3 = "B3", Option4 = "B4", CorrectAnswer = 2, Marks = 5 });
        questions.Add(new Question() { Statement = "CCC", Option1 = "C1", Option2 = "C2", Option3 = "C3", Option4 = "C4", CorrectAnswer = 4, Marks = 5 });

        return questions; // list object referance
        // question referance is on heap and is long lived
        // this referance will be passed to other variable so which wil be refering the objects so there will be no memory leak

    }//questions referance variable will die
}