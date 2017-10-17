using System;
using System.IO;
using System.Text;

namespace BookLibrary
{
    class Program
    {
        //=== Class Variables ===/
        public static Book CurrentBook;
        public static string projectPath = Directory.GetCurrentDirectory();
        public static string libraryPath = projectPath + @"\book library\";


        static void Main(string[] args)
        {

            // Set Users name
            //Console.WriteLine("Hello, what is your name?");
            //User User1 = new User();
            //User1.UserName = Console.ReadLine();
            //Console.WriteLine("Hi " + User1.UserName);

            //=== Add a new book to the library
            //string createNewBookQuestion = "Do you want to add a new book to the library (Yes / No)?";
            //string createNewBookAnswer = inputCheck(createNewBookQuestion);
            //if (createNewBookAnswer == "Yes")
            //{
            //    Console.WriteLine("What is the title of the new book?");
            //    string newBook = Console.ReadLine();

            //    // Creates the new book
            //    Book Book1 = new Book();
            //    setCurrentBook(Book1);
            //    Book1.BookName  = newBook;
            //    Book1.CreateNewBook(Book1);

            //    // Adds information to the newly created book
            //    string accessLibraryQuestion = "Do you want to add some information to the new book (Yes / No)?";
            //    string accessLibraryAnswer = inputCheck(accessLibraryQuestion);
            //    if (accessLibraryAnswer == "Yes")
            //    {
            //        Book1.AddInformationToBook(Book1);
            //    }
            //    else if (accessLibraryAnswer == "No")
            //    {
            //        Console.WriteLine("Ok");
            //    }
            //}
            //else if (createNewBookAnswer == "No")
            //{
            //    Console.WriteLine("Ok");
            //}

            // Update information within the library
            string readLibraryQuestion = "Do you want to upadte any information within the library (Yes / No)?";
            string readLibraryAnswer = inputCheck(readLibraryQuestion);
            if (readLibraryAnswer == "Yes")
            {
                readLibraryFileNames();

                string bookToUpdateQuestion = "Which book from the above list do you want to update?";
                string bookToUpdateAnswer = checkBookExists(bookToUpdateQuestion);

                Book bookToUpdate = new Book();
                setCurrentBook(bookToUpdate);
                bookToUpdate.BookName = bookToUpdateAnswer;
                bookToUpdate.UpdateInformationInBook(bookToUpdate);


            }
            else if (readLibraryAnswer == "No")
            {
                Console.WriteLine("TOk");
                Console.ReadLine();
            }
        }


        // ==== Class Methods ===/
        public Book getCurrentBook() {
            return CurrentBook;
        }
        private static void setCurrentBook(Book aBook) {
            CurrentBook = aBook;
        }

        // Checks if the user input is correct 
        static public string inputCheck(string aQuestion)
        {
            bool incorrectInput = true;
            while (incorrectInput)
            {
                Console.WriteLine(aQuestion);
                string input = Console.ReadLine();

                if (input == "Yes" || input == "No")
                {
                    incorrectInput = false;

                    if (input == "Yes") {
                        return input;
                    }
                    else if (input == "No") {
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, I did not understand that.");
                }
            }
            return "";
        }                

        // Discovered and dispays all the books within the library
        static private void readLibraryFileNames()
        {
            // Detects all the books within the library
            string[] fileNames = Directory.GetFiles(libraryPath);

            // Iterates over all the books within the library
            foreach (string fileName in fileNames)
            {
                // Displays the file name
                Console.WriteLine(Path.GetFileNameWithoutExtension(fileName));
            }
        }

        // Checks if the book exsists
        static private string checkBookExists(string aQuestion)
        {

            bool bookExsists = false;
            bool whileLoop = true;
            string bookName = "";

            // Detects all the books within the library
            string[] fileNames = Directory.GetFiles(libraryPath);

            while (whileLoop)
            {
                Console.WriteLine(aQuestion);
                bookName = Console.ReadLine();

                // Iterates over the books within the library
                foreach (string fileName in fileNames)
                {
                    if (Path.GetFileNameWithoutExtension(fileName) == bookName)
                    {
                        bookExsists = true;
                        whileLoop = false;
                    }
                }

                // If the book does not exsist
                if (!bookExsists)
                {
                    // Unsuccessful message
                    Console.WriteLine(bookName + " was not found within the library.");
                }
            }

            return bookName;
        }
    }
}