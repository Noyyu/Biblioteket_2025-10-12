using System.Drawing;
using System.Linq.Expressions;

namespace Biblioteket
{
    internal class Program
    {

        //User data
        static string[] userNames = { "UserOne", "UserTwo", "UserTree", "UserFour", "UserFive" };
        static int[] userPasswords = { 1, 2, 3, 4, 5 }; // Stores the users passwards

        static string[] user1 = { }; //Will store the books this user have borrowed
        static string[] user2 = { };
        static string[] user3 = { };
        static string[] user4 = { };
        static string[] user5 = { };

        static string[][] users = { user1, user2, user3, user4, user5 }; // Stores all the users and their stored books

        //Liberary data
        static string[] liberaryBooks = { "Haunting Adeline, by H.D. Carlton", "Twisted Love, by Ana Huang", "Neon Gods, by Katee Robert", "Credence, by Penelope Douglas", "Priest, by Sierra Simone" };
        static int[] liberaryBooksCopies = { 1, 3, 1, 4, 1 };

        static void Main(string[] args)
        {

            bool exitProgram = false;
            bool exitMenu ;
            int userID;
                       

            while (exitProgram == false)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Välkommer till Biblioteket!");
                Console.WriteLine("---------------------------");
                
                // Cheat Sheet
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Existing users:");
;               for (int i = 0; i < users.Length; i++)
                {
                    Console.WriteLine("User name: " + userNames[i] + ", Password: " + userPasswords[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;

                //User in log name
                Console.WriteLine();
                Console.WriteLine("Användarnamn: ");

                //User chooser
                switch (Console.ReadLine())
                {
                    case "UserOne":

                        userID = 1;                                          
                        exitMenu = false;

                        if (PasswordCheck(userID))
                        {
                            Console.WriteLine("Välkommen!");
                           
                            while (!exitMenu)
                            {
                                exitMenu = Run(userID);
                            }
                        }                        
                        break;

                    case "UserTwo":

                        userID = 2;
                        exitMenu = false;

                        if (PasswordCheck(userID))
                        {
                            Console.WriteLine("Välkommen!");

                            while (!exitMenu)
                            {
                                exitMenu = Run(userID);
                            }
                        }
                        break;

                    case "UserThree":

                        userID = 3;
                        exitMenu = false;

                        if (PasswordCheck(userID))
                        {
                            Console.WriteLine("Välkommen!");

                            while (!exitMenu)
                            {
                                exitMenu = Run(userID);
                            }
                        }
                        break;

                    case "UserFour":

                        userID = 4;
                        exitMenu = false;

                        if (PasswordCheck(userID))
                        {
                            Console.WriteLine("Välkommen!");

                            while (!exitMenu)
                            {
                                exitMenu = Run(userID);
                            }
                        }
                        break;

                    case "UseFive":

                        userID = 5;
                        exitMenu = false;

                        if (PasswordCheck(userID))
                        {
                            Console.WriteLine("Välkommen!");

                            while (!exitMenu)
                            {
                                exitMenu = Run(userID);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Det finns ingen användare vid det namnet");
                        break;
                }
            }
        }

        static bool PasswordCheck(int userID)
        {
            int userInput = 0;
            int guesses = 0;
            Console.WriteLine("Lösenord: ");

            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput != userPasswords[userID -1]) //Checks if the password is correct
            {
                Console.WriteLine("Fel lösenord");
                guesses++;
                if (guesses == 3)
                {
                    Console.WriteLine("Du har skrivit in fel lösenord för många gånger, försök igen senare");
                    return false;
                }
            }
            return true;
        }

        static bool Run(int userID)
        {
            switch (Menu())
            {
                case 1:
                    // Show available books
                    Console.Clear();
                    ShowAvailableBooks();
                    Console.WriteLine();
                    //
                    return false;
                case 2:
                    // Borrow book
                    Console.Clear();
                    Console.WriteLine("Vilken bok vill du låna?");
                    ShowAvailableBooks();
                    BorrowThisBook( userID); //Changes the size of the "users borrowed books" array, in this case, makes it bigger (and adds the new book to it)                                    
                    Console.WriteLine();
                    //
                    return false;
                case 3:
                    //Return book
                    Console.Clear();
                    Console.WriteLine("Vilken bok vill du retunera?");
                    ShowUserBooks(userID);
                    Console.WriteLine();
                    ReturnThisBook(userID); //Replaces user Array with a new one, not containing the book they returned                                                                                 
                    Console.WriteLine();
                    //
                    return false;
                case 4:
                    // Shows what books the user have borrowed
                    Console.Clear();
                    ShowUserBooks(userID);
                    Console.WriteLine();

                    return false;
                case 5:
                    //Logs out the user
                    return true;
            }
            return false;
        }
        //Menu
        static int Menu()
        {
            Console.WriteLine("1: Visa böcker");
            Console.WriteLine("2: Låna bok");
            Console.WriteLine("3: Retunera bok");
            Console.WriteLine("4: Mina lån");
            Console.WriteLine("5: Logga ut");

            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise) || userChoise > 5)
            {
                Console.WriteLine("Var snäll välj ett giltigt alternativ");
            }

            return userChoise;
        }

        //Show available books
        static void ShowAvailableBooks()
        {
            for (int i = 0; i < liberaryBooks.Length; i++)
            {
                Console.WriteLine("Bok ID: " + i + ": " + liberaryBooks[i] + ", " + liberaryBooksCopies[i] + " kopior på lager");
            }
        }

        //Show the books the user has borrowed
        static void ShowUserBooks(int userID)
        {
            if (users[userID].Length == 0)
            {
                Console.Write("Du har för närvarande inte lånat några böcker");
            }
            else
            {
                Console.WriteLine("Dina lån:");
                Console.WriteLine();
            }

            for (int i = 0; i < users[userID].Length; i++)
            {
                Console.WriteLine("ID: " + i + ": " + users[userID][i]);
            }
        }

        //Borrow a book
        static void BorrowThisBook( int userID)
        {
            int bookID = 0;
            bool didBorrowBook = false;

            while (!int.TryParse(Console.ReadLine(), out bookID) ||  liberaryBooks.Length - 1 <= bookID)
            {
                Console.WriteLine("Var vänlig välj en bok");
            }
            
            while (!didBorrowBook)
            {
                if ( liberaryBooksCopies[bookID] > 0) //Let the user borrow the book if there are more than 0 copies in store
                {
                    Console.WriteLine("You lånade: " + liberaryBooks[bookID]);
                    liberaryBooksCopies[bookID] -= 1; //Removes book from liberary

                    int i;
                    //Up size of array
                    string[] newArray = new string[users[userID].Length + 1]; //Creates the new user array adding size to it. 


                    for (i = 0; i < users[userID].Length; i++) //Adds the books already in the in the user array (Wont do it if the old array had a legnth of 0 (empty))
                    {
                        newArray[i] = users[userID][i];
                    }

                    if (users[userID].Length == 0) //If the array was empty
                    {
                        newArray[0] = liberaryBooks[bookID]; //Adds the book to the new array
                    }
                    else //If the array have more than one one element in it
                    {
                        newArray[i] = liberaryBooks[bookID]; //Adds the book at the last index in the new array
                    }

                    users[userID] = newArray; //Replaces the user array with the new one
                    didBorrowBook = true;
                }
                else
                {
                    Console.WriteLine("Vi har inte denna boken på lager");
                }
            }
            
        }

        //Return a book
        static void ReturnThisBook(int userID)
        {
            int bookID;

            while (!int.TryParse(Console.ReadLine(), out bookID) || (bookID > users[userID].Length - 1)) //Gets bookID from user, wont let user state a number higher than amount of books in user array
            {
                Console.WriteLine("Du har inte valt ett giltigt ID");
            }

            if (users[userID].Length < 1) //If the user does not have any books
            {
                Console.WriteLine("Du har inga böcker att retunera");
            }
            else //Checks which book is returned and upps the copy amount in the liberary
            {
                switch (users[userID][bookID])
                {
                    case "Haunting Adeline, by H.D. Carlton":
                        liberaryBooksCopies[0] += 1;
                        break;
                    case "Twisted Love, by Ana Huang":
                        liberaryBooksCopies[1] += 1;
                        break;
                    case "Neon Gods, by Katee Robert":
                        liberaryBooksCopies[2] += 1;
                        break;
                    case "Credence, by Penelope Douglas":
                        liberaryBooksCopies[3] += 1;
                        break;
                    case "Priest, by Sierra Simone":
                        liberaryBooksCopies[4] += 1;
                        break;
                }

                int i;
                string[] newArray = new string[users[userID].Length + -1]; //Creates the new user array subtracting size from it. 


                for (i = 0; i < newArray.Length; i++) //Adds the books already in the user array
                {
                    //Makes sure the new array isn't fed an empty spot
                    if (i < bookID) 
                    {
                        newArray[i] = users[userID][i];
                    }
                    else
                    {
                        newArray[i] = users[userID][i + 1];
                    }
                }

                Console.WriteLine("Du har retunerat: " + users[userID][bookID]);
                users[userID] = newArray;
            }
            
        }
    }
}
