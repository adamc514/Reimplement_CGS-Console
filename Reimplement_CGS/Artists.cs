using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Reimplement_CGS
{
    class Artists : CollectionBase
    {
        public void add(Artist art)
        {
            List.Add(art);
        }

        public Artist this[int index]
        {
            get { return (Artist)List[index]; }
            set { List[index] = value; }
        }
    }
}
