using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        private int range; 
        private int cout; 
        private readonly T[] mass; 
        private readonly int restriction;

        public LimitedSizeStack(int limit)
        {
            restriction = limit; 
            mass = new T[limit]; 
            range = cout = 0;
        }

        public void Push(T item)
        {
            if (range - cout >= restriction) 
            {
                cout++; 
            }
            int residue = range % restriction;
            mass[residue] = item; 
            range++;
        }

        public T Pop()
        {
            if (range == cout)
            {
                return default(T);
            } 
            range--; 
            int residue = range % restriction; 
            return mass[residue];
        }

        public int Count
        {
            get
            {
                return range - cout;
            }
        }
    }
}
