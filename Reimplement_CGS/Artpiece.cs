using System;
using System.Collections.Generic;
using System.Text;

namespace Reimplement_CGS
{
    class Artpiece
    {
        string pieceID;
        string title;
        int year;
        double price;
        double estimate;
        string artistID;
        char status;

        //constructor
        public Artpiece()
        {
            this.pieceID = "";
            this.title = ""; // NULL
            this.year = 0;
            this.price = 0;
            this.estimate = 0;
            this.artistID = "";
            this.status = ' ';
        }

        //overloaded constructor
        public Artpiece(string pieceID,string title,int year,double price,double estimate,string artistID,char status)
          
        {
            this.pieceID = pieceID;
            this.title = title;
            this.year = year;
            this.price = price;
            this.estimate = estimate;
            this.artistID = artistID;
            this.status = status;
        }
        public int getYear()
        {
            return year;
        }
        public string getID()
        {
            return pieceID;
        }
        public string PieceID
        {
            get { return pieceID; }
            set { pieceID = value; }
        }
        public double Price {
            get { return price; }
            set { price = value; }
        }
        public double Estimate
        {
            get { return this.estimate; }
            set { this.estimate = value; }
        }

        public void chnageStatus() {
            this.status = 'S';
        }

        public char Status
        {
            get { return status; }
            set { status = value; }
        }

        public void newStatus(char Stat)
        {
            this.status = Stat;
        }

        public void pricepaid(double Price)
        {
            this.price = Price;
        }
        public override string ToString()
        {
            return "Piece title:" + this.title + "Piece Year:" + this.year + "Piece ID:" + this.title +
                "Artist ID" + this.artistID + "Piece status:" + this.status;
        }

    }
}
