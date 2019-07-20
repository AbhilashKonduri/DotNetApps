using System;
using System.Collections.Generic;
using System.IO;

//Encapsulating the FileQuestions
class FileQuestions : QuestionsDataAccessLayer
{
    public override List<Question> GetQuestions(/* HardCodedQuestions this = referance of calling object */)
    {
        StreamReader sr = new StreamReader("TextFileQuestions.txt");
        //streamreader() constructor accepts the filename and opens the file
        // in read mode

        //string content = sr.ReadToEnd();
        // Read to end() creates string object fills it with file contents
        // and returns the referance of string object to us which we are
        //storing in the content

        List<Question> questions = new List<Question>();
        //list<> internally maintains dynamically growing array
        // here list object will create array question referance variables
        //Each variable can hold referance of Question Object

        while (true)
        {
            string line = sr.ReadLine(); // Readline() creates string object fills it with one line upto \n
                                         // and returns the referance of string object to us which we are
                                         //storing line. It moves the cursor to the next line in the file contents
            if (line == null)
            {
                break;
            }
            else
            {
                string[] items =line.Split(';');
                //split creates array of string object s
                //with the content in each object that is picked by saperating the content by ;
                // items recieve referance of array objects containing 7 string objects

                Question question = new Question()
                {
                    Statement = items[0],
                    Option1 = items[1],
                    Option2 = items[2],
                    Option3 = items[3],
                    Option4 = items[4],
                    CorrectAnswer = Convert.ToInt32(items[5]),
                    Marks = Convert.ToInt32(items[6]),
                };

                questions.Add(question); // passing referance of question object to Add()
            } // else ends
        } // while ends

        sr.Close(); // closing the file

        return questions; // returning referance of list<> object
    }

}

