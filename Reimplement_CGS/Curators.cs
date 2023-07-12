using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Reimplement_CGS
{
    class Curators : CollectionBase
    {
        //int i;
        // public void myMethod (int i)
        //Curator cur2;

        public void add(Curator cur) {
            List.Add(cur);
        }

        public Curator this[int index] {
            get { return (Curator) List[index]; }
            set { List[index] = value; }
        }
    }
}
