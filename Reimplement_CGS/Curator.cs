using System;
using System.Collections.Generic;
using System.Text;

namespace Reimplement_CGS
{
    class Curator : Person
    {
        string curatorID;
        double commision;
        const double commRate = 0.25;

        //constructor
        public Curator() {
            this.curatorID = "";
            this.commision = 0.0;
        }
        //overloaded constructor
        public Curator(string curatorID, double commision, string FName, string Lname):base(FName, Lname) {
            this.curatorID = curatorID;
            this.commision = commision;
        }

        public override string toString() {
            return "curatorID is " + this.curatorID + "commision is " + this.commision + base.toString();
        }
        public string getId()
        {
            return curatorID;
        }
        public string CuratorID {
            get { return curatorID; }
            set { curatorID = value; }
        }

        public double Commision {
            get { return commision; }
            set { commision = value; }
        }
    }
}
