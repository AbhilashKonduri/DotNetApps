using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagon.DataStructure
{
    public class MyStack
    {
        static void Main(string[] args)
        {

        }
        private int[] items;
        public int Size { get; private set; }
        public int Top { get; private set; }

        public MyStack(int size)
        {
            Size = size;
            Top = 0;
            items = new int[size];
        }

        public void Push(int item)
        {
            items[Top] = item;
            Top++;
        }

        public int Pop()
        {
            Top--;
            return items[Top];
        }
    }

}


