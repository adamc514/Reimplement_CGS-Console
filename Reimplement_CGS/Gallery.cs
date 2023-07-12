using System;
using System.Collections.Generic;
using System.Text;

namespace Reimplement_CGS
{
   public class Gallery
   {
        private Artists myArtists = new Artists();
        private Curators myCurators = new Curators();
        private Artpieces myArtpieces = new Artpieces();
        
        public string addArtist(string ID,string curId,string firstname,string lastname)
        {
            string result = "";
            if(ID.Length != 5)
            {
                result = "Artist ID must be exactly 5 characters in length";
            }
            else
            {
                if(checkArtist(ID) == true)
                {
                    result = "There is already an artist with that ID";
                }
                else
                {
                  if(curId.Length > 5)
                  {
                        result = "Curator Id must be 5 characters in length";
                  }
                    else
                    {
                        if (firstname.Length + lastname.Length > 40)
                        {
                            result = "Artist full name shouldn't exceed 40 characters in length";
                        }
                        else
                        {
                            Artist art = new Artist(ID, curId, firstname, lastname);
                            myArtists.add(art);
                            result = "Artist has been added to the list!";
                        }
                    }
                }
                return result;
            }

            return result;
        }



        public bool checkArtist(string aID)
        {
            bool flag = false;
            foreach(Artist art in myArtists)
            {
                if(art.getId() == aID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool checkArtpiece(string pieceID)
        {
            bool flag = false;
            foreach(Artpiece piece in myArtpieces)
            {
                if(piece.getID() == pieceID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void addArtist()
        {
            Console.WriteLine("Please enter an artist ID");
            string id = Console.ReadLine();
            if(id.Length != 5)
            {
                Console.WriteLine("Artist Id must be exactly 5 characters");
            }
            else
            {
                foreach(Artist art in myArtists)
                {
                    if(art.getId() == id)
                    {
                        Console.WriteLine("That artist Id already exists");

                    }
                }
                Console.WriteLine("Please enter a curator Id");
                string curId = Console.ReadLine();
                if(curId.Length != 5)
                {
                    Console.WriteLine("Curator id must be 5 characters");
                }
                else
                {
                    foreach(Curator cur in myCurators)
                    {
                        if(cur.getId() == curId) { 

                            Console.WriteLine("That curator already exists");
                        }
                    }
                }
                Console.WriteLine("Please enter a new artist first name");
                string fname = Console.ReadLine();
                Console.WriteLine("Please enter a new artist last name");
                string lname = Console.ReadLine();
                if((fname.Length + lname.Length) > 40)
                {
                    Console.WriteLine("First and last name should not exceed 40 characters");
                }
                else
                {
                    Artist a = new Artist(curId, id, fname, lname);
                    myArtists.add(a);
                }
            }
        }
        public bool checkCurator(string cID) {
            bool flag = false;
            foreach (Curator cur in myCurators) {
                if (cur.getId() == cID) {
                    flag = true;
                }
            }
            return flag;
        }


        public string addCurator(string ID, string firstname, string lastname, double commision) {
            string result = "";
            if (ID.Length != 5)
            {
                result = "the lenght of the curDatorID should be exactly 5 characters";
            }
            else {
                if (checkCurator(ID) == true)
                {
                    result = "There exist another curator with the same ID";
                }
                else {
                    if (firstname.Length + lastname.Length > 40)
                    {
                        result = "names should be less than 40 characters";
                    }
                    else {
                        Curator cur = new Curator(ID, commision, firstname, lastname);
                        myCurators.add(cur);
                        result = "Curator has been succesfully added to the list";
                    }
                }
            }
            return result;
        }


        public void addCurator()
        {
            Console.WriteLine("Please enter a curator id");
            string curId = Console.ReadLine();
            if(curId.Length != 5)
            {
                Console.WriteLine("Curator id must be 5 characters in length");
            }
            else
            {
                foreach(Curator cur in myCurators)
                {
                    if(cur.getId() == curId)
                    {
                        Console.WriteLine("A curator with that Id already exists");
                    }
                }
            }
            Console.WriteLine("Please enter a new curator first name");
            string cId = Console.ReadLine();
            Console.WriteLine("Please enter a new curator last name");
            string lastName = Console.ReadLine();
            if((cId.Length + lastName.Length) > 40)
            {
                Console.WriteLine("Characters cannot exceed 40");
            }
            else
            {
                Curator c = new Curator(curId, 0, cId, lastName);
                myCurators.add(c);
            }

        }

      /*  public void addArtpiece(string pieceID, string title, int year, double price,
            double estimate, string artistID, char status)
        {
            if(pieceID.Length == 5 && title.Length < 40)
            {
                if(checkArtist(artistID) == true)
                {
                    Artpiece piece = new Artpiece(pieceID, title, year, price, 0, artistID, 'D');
                    myArtpieces.add(piece);
                }
            }
        }*/

        public string addArtpiece(string pieceID, string title, int year, double price, 
            double estimate, string artistID, char status)
        {
            string result = "";
            if(pieceID.Length > 5)
            {
                result = "ArtPiece Id should be exactly 5 characters in length";
            }
            else
            {
                if(checkArtpiece(pieceID) == true)
                {
                    result = "There exists already an artpiece with that ID";
                }
                else
                {
                    if (title.Length > 40)
                    {
                        result = "Artpiece title should be no more than 40 characters";
                    }
                    else
                        {
                        bool flag = true;
                        if(checkArtist(artistID) == true)
                        {
                            result = "There exists an arist with that ID";
                            flag = false;
                        }
                        else
                        {
                            if(flag == true)
                            {
                                if(Convert.ToInt32(year) <1900 || Convert.ToInt32(year) > 2021)
                                {
                                    result = "The year must not be under 1900 or greater than the Current year";
                                }
                                else
                                {
                                    Artpiece piece = new Artpiece(pieceID, title, year, price, 0, artistID, 'D');
                                    myArtpieces.add(piece);
                                    result = "Artpiece has been successfully added to the list";
                                }
                            }
                        }
                        
                    }
                }
            }
            return result;

        }

        public void addArtpiece()
        {
            Console.WriteLine("Please enter the Id of the artpiece");
            string artId = Console.ReadLine();
            if(artId.Length != 5)
            {
                Console.WriteLine("Id must be 5 characters in length");
            }
            else
            {
                foreach(Artpiece piece in myArtpieces)
                {
                    if(piece.getID() == artId)
                    {
                        Console.WriteLine("Artpiece already exists, please enter another ID");
                    }
                }
            }
            Console.WriteLine("Please enter the title of the artpiece");
            string piecetitle = Console.ReadLine();
            if(piecetitle.Length > 40)
            {
                Console.WriteLine("Artpiece title should be no more than 40 characters");
            }
            else
            {
                Console.WriteLine("Please enter an artist Id");
                string artistId = Console.ReadLine();
                bool flag = true;
                foreach(Artist art in myArtists)
                {
                    if(art.getId() != artistId)
                    {
                        Console.WriteLine("There is no artist with this ID");
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    Console.WriteLine("Please enter the year of the ArtPiece");
                    //int year = Convert.ToInt32(Console.ReadLine());
                    string year = Console.ReadLine();
                   // int year2 = Convert.ToInt32(year);
                    // Convert.toInt32()   toString()
                    if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2021)
                    {
                        Console.WriteLine("Please enter a valid year between 1900 and 2021");
                    }
                    else
                    {
                        if (year.Length != 4)
                        {
                            Console.WriteLine("The year should not exceed 4 characters in length");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the estimated value of the artpiece");
                            double value = Convert.ToDouble(Console.ReadLine());
                            Artpiece P = new Artpiece(artId, piecetitle, Convert.ToInt32(year), 0, value, artistId, 'D');
                            myArtpieces.add(P);
                            Console.WriteLine("The artpiece has been successfully aded to the list");
                        }
                    }
                }
            }
        }

        public void changeStatus(string ID)
        {
            int i = 0;
            if (verifyArtpiece(ID) == true)
            {
                foreach(Artpiece piece in myArtpieces)
                {
                    if(piece.PieceID != ID)
                    {
                        i++;
                    }
                    else
                    {
                        piece.Status = 'S';
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no item with this ID");
            }
        }
        
        public bool verifyArtpiece(string ID)
        {
            bool flag = false;
            foreach(Artpiece piece in myArtpieces)
            {
                if (piece.PieceID == ID)
                    flag = true;
            }
            return flag;
        }
        private int findArtPiece(string id)
        {
            for(int i = 0; i < myArtpieces.Count; i++)
            {
                if(myArtpieces[i].PieceID == id)
                {
                    i++;
                }
            }
            return 0;
        }

        public double returnValue(string ID)
        {
            double value = 0;
            int i = 0;
            foreach(Artpiece piece in myArtpieces)
            {
                if(piece.PieceID != ID)
                {
                    i++;
                }
                else
                {
                    value = piece.Price;
                }
            }
            return value;
        }

        public void changeStatus2(string artID) {
            foreach (Artpiece art in myArtpieces) {
                if (art.getID() == artID) {
                    art.chnageStatus();
                }
            }

        }

        public void changeStatus3(string artID) {
            foreach (Artpiece art in myArtpieces) {
                if (art.getID() == artID) {
                    art.Status = 'S';
                }
            }
        }


        public void changestatus4(string Id)
        {
            foreach(Artpiece art in myArtpieces)
            {
                if(art.getID() == Id)
                {
                    art.Status = 'S';
                }
            }
        }

        public void changestatus5(string id)
        {
            foreach(Artpiece art in myArtpieces)
            {
                if(art.getID() == id)
                {
                    art.chnageStatus();
                }
            }
        }


        public string sellArtPiece(string pieceID,double price)
        {
            string results = "";
            if(pieceID.Length > 5)
            {
                results = "Artpiece ID should contain exactly 5 characters";
            }
            else
            {
                if(verifyArtpiece(pieceID) == true)
                {
                    results = "This artpiece Id doesnt exist";
                }
                else
                {
                    if(price >= returnValue(pieceID))
                    {
                        results = "Your piece has successfully been sold";
                    }
                    else
                    {
                        results = "The artpiece cannot be sold for this price";
                    }
                }
            }
            return results;
        }

        public double returnItemValue(string Id)
        {
            double value = 0;
            for(int i = 0; i < myArtists.Count; i++)
            {
                if(myArtists[i].AristId == Id)
                {
                    value = myArtpieces[i].Price;
                }
            }
            return value;
        }

        public void sellArtPiece()
        {
            Console.WriteLine("Please enter the piece Id you would like to sell");
            string pieceId = Console.ReadLine();
            if(verifyArtpiece(pieceId) == true)
            {
                Console.WriteLine("How much would you like to pay?");
                double price = Convert.ToDouble(Console.ReadLine());
                if(price >= returnValue(pieceId))
                {
                    Console.WriteLine("Your artpiece has been sold");
                    changeStatus(pieceId);
                }
                else
                {
                    Console.WriteLine("The artpiece you wish to sell cannot be sold");
                }
   
            }
            else
            {
                Console.WriteLine("Please enter the Artist Id of the artpiece");
                string artistId = Console.ReadLine();

                Console.WriteLine("Please enter the curator Id of the artist");
                string curatorId = Console.ReadLine();

                Console.WriteLine("Please enter the value of the artpiece");
                double PieceValue = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter the Year of the artpiece");
                int PieceYear = Convert.ToInt32(Console.ReadLine());

                changeStatus2(pieceId);

               // Artpiece piece = new Artpiece(pieceId,)
            }
        }


        //Practice implementation methods
        public void addArtist2()
        {
            Console.WriteLine("Please enter the Id of the artist");
            string artistId = Console.ReadLine();
            if(artistId.Length != 5)
            {
                Console.WriteLine("AristId must be exactly 5 characters in length");
            }
            else
            {
                foreach(Artist art in myArtists)
                {
                    if(art.getId() == artistId)
                    {
                        Console.WriteLine("An artist with that Id already exists");
                    }
                }
            }
            Console.WriteLine("Please enter the Id of the curator");
            string curatorId = Console.ReadLine();
            if(curatorId.Length != 5)
            {
                Console.WriteLine("Curator Id must be 5 characters in length");
            }
            else
            {
                foreach(Curator cur in myCurators)
                {
                    Console.WriteLine("There exists already a curator with that ID");
                }
            }
            Console.WriteLine("Please enter the first name of the artist");
            string firstname = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the artist");
            string lastname = Console.ReadLine();
            if(firstname.Length + lastname.Length > 40)
            {
                Console.WriteLine("Arist first name and last name should not exceed 40 characters");
            }
            else
            {
                Artist a = new Artist(curatorId, artistId, firstname, lastname);
            }
        }

        public void addCurator2()
        {
            Console.WriteLine("Please enter the curator ID");
            string cId = Console.ReadLine();
            if(cId.Length != 5)
            {
                Console.WriteLine("Curator id must be exactly 5 characters in length");
            }
            else
            {
                foreach(Curator cur in myCurators)
                {
                    if(cur.getId() == cId)
                    {
                        Console.WriteLine("A curator with that Id already exists");
                    }
                }
            }
            Console.WriteLine("Please enter the curator first name");
            string cFirstname = Console.ReadLine();
            Console.WriteLine("Please enter the curator last name");
            string cLastname = Console.ReadLine();
            if((cFirstname.Length + cLastname.Length) > 40)
            {
                Console.WriteLine("Curator first name and last name must not exceed 40 characters");
            }
            else
            {
                Curator c = new Curator(cId, 0, cFirstname, cLastname);
            }
        }
        public void addArtPiece2()
        {
            Console.WriteLine("Please enter the id of the art piece");
            string artId = Console.ReadLine();
            if(artId.Length != 5)
            {
                Console.WriteLine("Artpiece id must be exactly 5 characters in length");
            }
            else
            {
                foreach(Artpiece piece in myArtpieces)
                {
                    Console.WriteLine("An art piece with that id already exists");
                }
            }
            Console.WriteLine("Please enter the title of the art piece");
            string piecename = Console.ReadLine();
            if(piecename.Length != 40)
            {
                Console.WriteLine("Piece length must be no more than 40 characters");
            }
            else
            {
                Console.WriteLine("Please enter the artist Id");
                string artID = Console.ReadLine();
                bool flag = true;
                foreach(Artist art in myArtists)
                {
                    if(art.getId() == artID)
                    {
                        Console.WriteLine("Artist with that Id doesnt exist");
                    }
                    flag = false;
                }
                if(flag == true)
                {
                    Console.WriteLine("Please enter the year of the artpiece");
                    string year = Console.ReadLine();
                    if(Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2021)
                    {
                        Console.WriteLine("The year must be between 1900 and 2021, please enter a valid year");
                    }
                    else
                    {
                        if(year.Length != 4)
                        {
                            Console.WriteLine("Year must be no more than 4 characters in length");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the value of the piece");
                            double estimate = Convert.ToDouble(Console.ReadLine());
                            Artpiece pc = new Artpiece(artID, piecename,Convert.ToInt32(year), estimate, 0, artId, 'D');
                        }
                    }
                }
                
            }
        }
   }
}
