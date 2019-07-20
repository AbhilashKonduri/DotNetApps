using System;

public class Question //referance type
{
    private string _statement; //instance field

    public string Statement //fully Implemented Property
    {
        get { return _statement; }
        set
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                _statement = value;
            }
            else
            {
                throw new Exception("Statement cannot be Empty");
            }
        }
    }

    private string _option1; // instance field

    public string Option1 //fully Implemented Property
    {
        get { return _option1; }
        set
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                _option1 = value;
            }
            else
            {
                throw new Exception("Option1 cannot be Empty");
            }
        }
    }
    private string _option2; // instance field
    public string Option2 //fully Implemented Property
    {
        get { return _option2; }
        set
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                _option2 = value;
            }
            else
            {
                throw new Exception("Option2 cannot be Empty");
            }
        }
    }

    private string _option3; // instance field
    public string Option3 //fully Implemented Property
    {
        get { return _option3; }
        set
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                _option3 = value;
            }
            else
            {
                throw new Exception("Option3 cannot be Empty");
            }
        }
    }

    private string _option4; // instance field
    public string Option4 //fully Implemented Property
    {
        get { return _option4; }
        set
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                _option4 = value;
            }
            else
            {
                throw new Exception("Option4 cannot be Empty");
            }
        }
    }

    private int _marks; // instance field

    public int Marks //fully Implemented Property
    {
        get { return _marks; }
        set
        {
            if (value > 0)
            {
                _marks = value;
            }
            else
            {
                throw new Exception("Marks must be Greater than zero");
            }
        }
    }

    private int _correctanswer; // instance field

    public int CorrectAnswer //fully Implemented Property
    {
        get { return _correctanswer; }
        set
        {
            if (value >= 1 && value <= 4)
            {
                _correctanswer = value;
            }
            else
            {
                throw new Exception("Value must be between 1 and 4");
            }
        }
    }

}
