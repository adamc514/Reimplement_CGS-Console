using System;
using System.Collections.Generic;
using System.Text;

namespace Reimplement_CGS
{
    class Person
    {
        string firstname;
        string lastname;
        public Person(){
            this.firstname = "";
            this.lastname = "";
        }
        // Person ps = new Person();
        //Class constructor
        public Person(string FN, string LN) {
            this.firstname = FN;
            this.lastname = LN;
        }
        // Person ps = new Person("Ad", "Cohen")
        public virtual string toString() {
            // returning firstname and lastname
            return "firstname is " + this.firstname + "lastname is " + this.lastname;
        }
    } 
}
