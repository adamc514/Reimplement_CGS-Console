using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;

namespace Reimplement_CGS
{
    class Program
    {
        static Gallery gal = new Gallery();
        static Curators myCurators = new Curators();
        static Artists myArtists = new Artists();
        static Artpieces myArtpieces = new Artpieces();

        public static bool verifyPiece(string ID)
        {
            bool flag = false;
            foreach (Artpiece piece in myArtpieces)
            {
                if ((piece.PieceID) == ID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static void changeStatus(string ID)
        {
            int i = 0;
            if (verifyPiece(ID) == true)
            {
                foreach (Artpiece piece in myArtpieces)
                {
                    if (piece.PieceID != ID)
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

        public static double returnItemValue(string Id)
        {
            double value = 0;
            for (int i = 0; i < myArtists.Count; i++)
            {
                if (myArtists[i].AristId == Id)
                {
                    value = myArtpieces[i].Price;
                }
            }
            return value;
        }


        public static void listCurators()
        {
            Console.WriteLine("List of curators");
            foreach (Curator cur in myCurators)
            {
                Console.WriteLine(cur.CuratorID + " " + cur.getFirst() + " " + cur.getLast());
            }
        }


        public static void listArtists()
        {
            Console.WriteLine("List of Artists");
            foreach (Artist art in myArtists)
            {
                Console.WriteLine(art.getId() + " " + art.getFirst() + " " + art.getLast());
            }
        }

        public static void listOfArt()
        {
            Console.WriteLine("List of artpieces");
            foreach (Artpiece piece in myArtpieces)
            {
                Console.WriteLine(piece.getID() + " " + piece.ToString());
            }
        }

        public static void displayMenu()
        {
            Console.WriteLine("Choose from one of the following options");
            Console.WriteLine("Option 1: Add Curator");
            Console.WriteLine("Option 2: Add Artist");
            Console.WriteLine("Option 3: Add Artpiece");
            Console.WriteLine("Option 4: Sell Artpiece");
            Console.WriteLine("Option 5: List of Artists");
            Console.WriteLine("Option 6: List of Artpieces");
            Console.WriteLine("Option 7: List of Curators");
        }


        public static void Main(string[] args)
        {

            bool menu = true;
            string id;
            string curId;
            string artId;
            string artTitle = "";
            double value = 0.0;



                while (menu)
                {
                    displayMenu();
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        //Curator
                        case 1:

                            {
                                do
                                {
                                    Console.WriteLine("Please enter a curator Id");
                                    id = Console.ReadLine();
                                } while (id.Length != 5);
                                if (gal.checkCurator(id) == true)
                                {
                                    Console.WriteLine("Id already exists");
                                }
                                else
                                {
                                    Console.WriteLine("Please enter your first name: ");
                                    string fn = Console.ReadLine();
                                    Console.WriteLine("Please enter your last name: ");
                                    string ln = Console.ReadLine();
                                    if ((fn.Length + ln.Length) > 40)
                                    {
                                        Console.WriteLine("Characters cannot exceed 40");
                                    }
                                    else
                                    {
                                        Curator c = new Curator(id, 0, fn, ln);
                                        myCurators.add(c);
                                        Console.WriteLine("Curator has been added to the list");
                                    }

                                }
                                break;
                            }
                            //Artist
                        case 2:
                            do
                            {
                                Console.WriteLine("Please enter your Artist id");
                                artId = Console.ReadLine();
                            } while (artId.Length != 5);
                            if (gal.checkCurator(artId) == true)
                            {
                                Console.WriteLine("This is not your artist id, Please enter a non-existing id");
                            }
                            else
                            {
                                Console.WriteLine("Please enter your first name: ");
                                string fn = Console.ReadLine();
                                Console.WriteLine("Please enter your last name: ");
                                string ln = Console.ReadLine();
                                if ((fn.Length + ln.Length) > 40)
                                {
                                    Console.WriteLine("Characters cannot exceed 40");
                                }
                                else
                                {
                                    Artist a = new Artist(artId, fn, ln, "");
                                    myArtists.add(a);
                                    Console.WriteLine("Artist has been added to the list");
                                }
                            }
                            break;
                            //ArtPiece
                        case 3:
                            do
                            {
                                Console.WriteLine("Please enter the Id of the artpiece");
                                artId = Console.ReadLine();
                            } while (artId.Length != 5);
                            if (gal.checkArtpiece(artId) == true)
                            {
                                Console.WriteLine("There is already an existing artpiece with this Id");
                            }
                            else
                            {
                                Console.WriteLine("Enter the title of the artpiece");
                                artTitle = Console.ReadLine();
                            }
                            if (artTitle.Length > 40)
                            {
                                Console.WriteLine("Your art title cannot exceed 40 characters");
                            }
                            else
                            {
                                Console.WriteLine("Please enter the artist Id");
                                artId = Console.ReadLine();
                                bool flag = true;
                                if (gal.checkArtist(artId) == true)
                                {
                                    Console.WriteLine("There is no artist with this ID");
                                    flag = false;

                                } if (flag == true)
                                {
                                    Console.WriteLine("Please enter the year of the ArtPiece");
                                    string year = Console.ReadLine();
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
                                            value = Convert.ToDouble(Console.ReadLine());
                                            Artpiece P = new Artpiece(artId, artTitle, Convert.ToInt32(year), 0, value, artId, 'D');
                                            myArtpieces.add(P);
                                            Console.WriteLine("Artpiece has been added to the list");
                                        }
                                    }
                                }
                            }
                            break;
                            //Sell artpiece
                        case 4:
                            Console.WriteLine("Please enter the artpiece ID you would like to sell");
                            string pieceID = Console.ReadLine();
                            if (verifyPiece(pieceID) == true) {

                                Console.WriteLine("How much would you like to pay?");
                                double price = Convert.ToDouble(Console.ReadLine());
                                if (price >= returnItemValue(pieceID))
                                {
                                    Console.WriteLine("Your artpiece has been sold");
                                    changeStatus(pieceID);
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

                                changeStatus(pieceID);
                            }
                            break;


                        case 5:
                        
                        listArtists();
                            break;
                        case 6:
                            listOfArt();
                            break;
                        case 7:
                            listCurators();
                            break;
                    }
                }
        }
    }
}

