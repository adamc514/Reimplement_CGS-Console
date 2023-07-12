using System;
using System.Collections.Generic;
using System.Text;

namespace Reimplement_CGS
{
    class Artist : Person
    {
        string curatorId;
        string artistId;

        //class constructor
        public Artist()
        {
            this.curatorId = "";
            this.artistId = "";
        }
        //overloaded constructor
        public Artist(string CurId,string artistId,string FN,String LN): base(FN,LN)
        {
            this.curatorId = CurId;
            this.artistId = artistId;
        }
        public string getId()
        {
            return artistId;
        }

        public string AristId
        {
            get { return artistId; }
            set { artistId = value; }
        }

        public string CuratorId
        {
            get { return curatorId; }
            set { curatorId = value; }
        }
        public override string toString()
        {
            return "Artist ID is" + this.artistId + "CuratorID is" + this.curatorId + base.toString();
        }
    }
}
