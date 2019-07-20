using System;
using System.Collections.Generic;


class Point2D :Object //Comman base class is object
{
    private uint _x, _y; // Instance Data Members

    public uint X { get { return _x; } set { _x = value; } }
    public uint Y { get { return _y; } set { _y = value; } }

    public Point2D(/* Point 2D this = ref of Point2D object or Point 3D object */)
    {
        X = Y = 0; //this.X = this.Y =0;
    }

    public Point2D(/* Point 2D this = ref of Point2D object, or Point 3D object */ uint x, uint y)
    {
        X = x; // this.X =x;
        Y = y; // this.Y =y;
    }

    public void Display(/* Point 2D this = ref of Point3D object*/)
    {
        Console.Write(this.X + " " + this.Y);
    }

    public virtual void F2()
    {
        Console.WriteLine("Hai");
    }
}

//Rules of Inheritance;
// 1. All the instance data members of Base class and all the instance data members of derived class become pasrt of derived class object
// 2. All the instance methods of the base class and all the instance methods of the derived class work for the derived class object 
// including constructor
// 3. derived class constructor always calls main class constructor when derived class object is created
// value of this is passed from derived class constructor to base class constructor
// 4. Referance variable of base class type can hold referance of derived class object (Done at abstraction)
// 5. Derived class method can call Base class method in which value of this will be passed
// 6. Base class Method can call Derived class Method provided the base class method is called using derived class object.
// The method that is being called is declared virtual or abstract in the base class and is overriden by derived class. 

//Point3D is a derived class of Point2D ; Derived class is also called Sub calss
//Point3D inherits Point2D
class Point3D :Point2D
{
    private uint _z; // Instance Data Members

    public uint Z { get { return _z; } set { _z = value; } }

    public Point3D(/* Point 3D this = ref of Point2D object */) : base(/* value of point 3D*/)
    {
        Z =0; //this.Z =0;
    }

    public Point3D(/* Point 3D this = ref of Point2D object */ uint x, uint y, uint z) : base(/* value of point 3D*/ x,y) //To Transfer x and y values 
    {
        Z = z; // this.Z =z;
    }
    public void Display(/* Point 2D this = ref of Point3D object*/)
    {
        base.Display();
        Console.Write(this.Z );
    }

    public override void F2() // Override the base class function
    {
        Console.WriteLine("Hello");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Point2D p1 = new Point3D(); // These have _x, _y (8 bytes)
        //P1 is a referance variable
        // new with the help of CLR creates object and object doesnt have name
        // This object created on Heap

        Point2D p2 = new Point2D(); // These have _x, _y (8 bytes)
        // p2 is 8 bytes since it is 64 bit compilation

        Point3D q1 = new Point3D(); // These have _x, _y,_z (12 bytes)
        // q1 is 8 bytes since it is 64 bit compilation

        object o1 = new Point2D();
        object o2 = new Point3D();

        p1.F2();

        Type Point3DType = q1.GetType();
        Type Point2DType = p1.GetType();

    }
}
