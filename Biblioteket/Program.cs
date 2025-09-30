using System.Linq.Expressions;

namespace Biblioteket
{
    internal class Program
    {
        /*
        //Petter sa nej
        struct Book
        {
            // get; makes them read only outside of the struct, private set; makes me able to change the value inside the struct
            public string name    { get; private set; } = "";
            public int?   ID       { get; private set; } = null;
            public int?   copys    { get; private set; } = null;
            public int    borrowed { get; private set; } = 0;



            public Book(string name, int? ID, int? copys) //Constructor
            {
                this.name     = name;
                this.ID       = ID; //Isn't actually needes since the array will have ID:s, but the task calls for it
                this.copys    = copys;
                this.borrowed = 0;
            }

            public void Borrow() //Lets the user borrow the book
            {
                if (this.copys > 0) //If there are any copies to be borrowed
                {
                    this.copys--;
                    this.borrowed++;
                }
                else
                {
                    Console.WriteLine(this.name + " is out of stock");
                }
            }
            public void Return() //Lets the user return the book
            {
                if (this.borrowed > 0) //If the user actually borrowed the book, let them return it (We dont want infinate books)
                {
                    this.copys++;
                    this.borrowed--;
                }
                else
                {
                    Console.WriteLine("You cant return a book you've not borrowed");
                }
            }
        }
        */


        static void Main(string[] args)
        {
            /* Petter sa nej igen
            //The books (Look up the titles at your own risk)
            Book book1 = new ("Haunting Adeline, by H.D. Carlton", 1, 2);
            Book book2 = new ("Twisted Love, by Ana Huang",        2, 2);
            Book book3 = new ("Credence, by Penelope Douglas",     3, 1);
            Book book4 = new ("Neon Gods, by Katee Robert",        4, 4);
            Book book5 = new ("Priest, by Sierra Simone",          5, 1);

            Book[] books = { book1, book2, book3, book4, book5 };
            */

            bool exit = false;

            //User data
            string[] userNames = { "UserOne", "UserTwo", "UserTree", "UserFour", "UserFive" };
            int[] userIDs = { 1, 2, 3, 4, 5 }; // Stores the users passwards

            string[] user1 = { }; //Will store the books this user have borrowed
            string[] user2 = { };
            string[] user3 = { };
            string[] user4 = { };
            string[] user5 = { };

            string[][] users = { user1, user2, user3, user4, user5 }; // Stores all the users and their stored books

            //Liberary data
            string[] bookNames = { "Haunting Adeline, by H.D. Carlton", "Twisted Love, by Ana Huang", "Neon Gods, by Katee Robert", "Credence, by Penelope Douglas", "Priest, by Sierra Simone" };
            int[] bookCopies = { 1, 3, 1, 4, 1 };

            Console.WriteLine("---------------------------");
            Console.WriteLine("Välkommer till Biblioteket!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            Console.WriteLine("Användarnamn: ");

            while (exit == false)
            {
                switch (Console.ReadLine())
                {
                    case "UserOne":
                        Console.WriteLine("Lösenord: ");
                        int ID = 0;
                        while (!int.TryParse(Console.ReadLine(), out ID) || ID != userIDs[0])
                        {
                            Console.WriteLine("Fel lösenord");
                        }
                        if (ID == userIDs[0])
                        {
                            Console.WriteLine("Välkommen!");
                            Menu();
                        }
                        break;

                    case "UserTwo":
                        break;

                    case "UserThree":
                        break;

                    case "UserFour":
                        break;

                    case "UseFive":
                        break;

                    default:
                        Console.WriteLine("Icke existerande användare");
                        break;
                }
            }
        }



        //Menu
        static void Menu(int user)
        {
            Console.WriteLine("1: Visa böcker");
            Console.WriteLine("2: Låna bok");
            Console.WriteLine("3: Retunera bok");
            Console.WriteLine("4: Mina lån");
            Console.WriteLine("5: Logga ut");

            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise))
            {
                Console.WriteLine("Var snäll välj ett giltigt alternativ");
            }
             //Hmmmm 
            switch (userChoise)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }

        }

        //Show available books
        static void ShowAvailableBooks(string[] names, int[] copies)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Book ID: " + i + ": " + names[i] + ", " + copies[i] + " kopior på lager");
            }
        }

        //Show the books the user has borrowed
        static void ShowUserBooks(string[] userBooks)
        {
            for (int i = 0; i < userBooks.Length; i++)
            {
                Console.WriteLine("ID: " + i + ": " + userBooks[i]);
            }
        }

        //Borrow a book
        static int BorrowThisBook(int ID, int[] copies)
        {
            if (copies[ID] > 0)
            {
                return 1;
            }
            else
            {
                Console.WriteLine("Vi har inte denna boken på lager");
                return 0;
            }
        }

        //Return a book
        static int ReturnThisBook(int ID, int[] borrowed)
        {
            if (borrowed[ID] > 0)
            {
                return -1;
            }
            else
            {
                Console.WriteLine("Du har itne lånat denna boken");
                return 0;
            }
        }

        //Change user array size
        static string[] ChangeSize(int size, string[] names)
        {
            string[] ret = new string[names.Length + size];
            for (int i = 0; i < names.Length + size; i++)
            {
                ret[i] = names[i];
            }
            return ret;
        }
    }
}
