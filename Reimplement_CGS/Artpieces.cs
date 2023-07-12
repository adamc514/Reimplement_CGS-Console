using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Reimplement_CGS
{
    class Artpieces : CollectionBase
    {
        public void add(Artpiece piece)
        {
            List.Add(piece);
        }
        public Artpiece this[int index]
        {
            get { return (Artpiece)List[index]; }
            set { List[index] = value; }
        }
    }
}
