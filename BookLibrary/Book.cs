using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookLibrary
{
    class Book
    {
        //=== Class Variables ===/
        public static string projectPath = Directory.GetCurrentDirectory();
        public static string libraryPath = projectPath + @"\book library\";


        //=== Class Methods ===/
        public string BookName { get; set; }

        public string BookAuthor { get; set; }

        public string DatePublished { get; set; }

        public string Price { get; set; }

        // Create new Library
        public void CreateNewBook(Book aBook)
        {
            try
            {
                // Creates a new txt file within the "book libraries" folder
                FileStream newFile = File.Create(libraryPath + aBook.BookName + ".txt");
                newFile.Dispose();
                
                // Success message
                Console.WriteLine("You have added " + aBook.BookName + " to the library.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        // Add information to the book
        public void AddInformationToBook(Book aBook)
        {
            try
            {
                // Define the Author of the book
                Console.WriteLine("Who is the author?");
                aBook.BookAuthor = "Author: " + Console.ReadLine();

                // Define the date when the book was published 
                Console.WriteLine("What date was the book originally published?");
                aBook.DatePublished = "Date published: " + Console.ReadLine();

                // Define the price of the book
                Console.WriteLine("What is the price of the book?");
                aBook.Price = "Price: " + Console.ReadLine();

                // Add all the inforation to an array varibale
                List<string> bookInformation = new List<string>();
                bookInformation.Add(aBook.BookAuthor);
                bookInformation.Add(aBook.DatePublished);
                bookInformation.Add(aBook.Price);

                // Defines the folder book path
                string bookPath = libraryPath + aBook.BookName + ".txt";

                // Write the information to the book file
                File.WriteAllLines(bookPath, bookInformation);                

                // Success message
                Console.WriteLine("You have successfully addded information to " + aBook.BookName);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        // Read the books information
        public void UpdateInformationInBook(Book aBook)
        {

            try
            {
                // Detects all the information within the book
                string[] informationLines = File.ReadAllLines(libraryPath + aBook.BookName + ".txt");

                List<string> informationList = new List<string>();
                string[] informationValueSplit;
                Char splitDelimiter = ':';

                foreach (string informationLine in informationLines) {
                    informationValueSplit = informationLine.Split(splitDelimiter);
                    informationList.Add(informationValueSplit[1].TrimStart());
                }

                aBook.BookAuthor = informationList[1];
                aBook.DatePublished = informationList[2];
                aBook.Price = informationList[3];

                aBook.displayAllInformation(aBook);

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void displayAllInformation(Book aBook) {
            Console.WriteLine("Name: " + aBook.BookName);
            Console.WriteLine("Author: " + aBook.BookAuthor);
            Console.WriteLine("Date Published: " + aBook.DatePublished);
            Console.WriteLine("Price: " + aBook.Price);            
        }


    }
}
