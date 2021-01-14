using System.IO;
using System.Linq;
using System;

namespace pa5_ZachRussell42
{
    public class OutFile
    {
        // Properties

        private AddEdit[] readFiles;
        private AddEdit book;
        private RentReturn[] readFilesB;
        private RentReturn transactions;
        private InFile inFile;


        // Constructor
        public OutFile(AddEdit[] readFiles, AddEdit book, RentReturn[] readFilesB, RentReturn transactions, InFile inFile)
        {
            this.readFiles = readFiles;
            this.book = book;
            this.readFilesB = readFilesB;
            this.transactions = transactions;
            this.inFile = inFile;
        }
        
        // Methods

        public void WriteFile(char version)
        {
            // Add/Edit for overwritting all data
            if (version == 'a')
            {
                // Open File
                StreamWriter outFile = new StreamWriter("books.txt");

                // Process 
                for (int i = 0; i < inFile.GetNumberOfBooks(); i++)
                {
                    if (readFiles[i+1] != null)
                    {
                        outFile.WriteLine($"{readFiles[i].GetISBN()}#{readFiles[i].GetTitle().ToUpper()}#{readFiles[i].GetAuthor().ToUpper()}#{readFiles[i].GetGenre().ToUpper()}#{readFiles[i].GetListenTime()}#{readFiles[i].GetCount()}");
                    }
                    else
                    {
                        outFile.Write($"{readFiles[i].GetISBN()}#{readFiles[i].GetTitle().ToUpper()}#{readFiles[i].GetAuthor().ToUpper()}#{readFiles[i].GetGenre().ToUpper()}#{readFiles[i].GetListenTime()}#{readFiles[i].GetCount()}");
                    }
                }
                // Close File
                outFile.Close();
            }
            // Add/Edit for appending 1 line
            else if (version == 'b')
            {
                if (inFile.GetNumberOfBooks() > 0)
                {
                    // Open File
                    StreamWriter outFile = new StreamWriter("books.txt", true);

                    // Process
                    outFile.WriteLine();
                    outFile.Write($"{book.GetISBN()}#{book.GetTitle().ToUpper()}#{book.GetAuthor().ToUpper()}#{book.GetGenre().ToUpper()}#{book.GetListenTime()}#{book.GetCount()}");

                    // Close File
                    outFile.Close();
                }
                else if (inFile.GetNumberOfBooks() == 0)
                {
                    // Open File
                    StreamWriter outFile = new StreamWriter("books.txt");

                    // Process
                    outFile.Write($"{book.GetISBN()}#{book.GetTitle().ToUpper()}#{book.GetAuthor().ToUpper()}#{book.GetGenre().ToUpper()}#{book.GetListenTime()}#{book.GetCount()}");

                    // Close File
                    outFile.Close();
                }
            }
            // Rent/Return for overwritting all data
            else if (version == 'c')
            {
                // Open File
                StreamWriter outFile = new StreamWriter("transactions.txt");

                // Process 
                for (int i = 0; i < inFile.GetNumberOfRentals(); i++)
                {
                    if (readFilesB[i+1] != null)
                    {
                        outFile.WriteLine($"{readFilesB[i].GetRentalID()}#{readFilesB[i].GetISBN()}#{readFilesB[i].GetName().ToUpper()}#{readFilesB[i].GetEmail().ToUpper()}#{readFilesB[i].GetRentalDate()}#{readFilesB[i].GetReturnDate()}");
                    }
                    else
                    {
                        outFile.Write($"{readFilesB[i].GetRentalID()}#{readFilesB[i].GetISBN()}#{readFilesB[i].GetName().ToUpper()}#{readFilesB[i].GetEmail().ToUpper()}#{readFilesB[i].GetRentalDate()}#{readFilesB[i].GetReturnDate()}");
                    }
                }
                // Close File
                outFile.Close();
            }
            // Rent/Return for appending 1 line
            else if (version == 'd')
            {
                if (inFile.GetNumberOfRentals() > 0)
                {
                    // Open File
                    StreamWriter outFile = new StreamWriter("transactions.txt", true);

                    // Process
                    outFile.WriteLine();
                    outFile.Write($"{transactions.GetRentalID()}#{transactions.GetISBN()}#{transactions.GetName().ToUpper()}#{transactions.GetEmail().ToUpper()}#{transactions.GetRentalDate()}#{transactions.GetReturnDate()}");

                    // Close File
                    outFile.Close();
                }
                else if (inFile.GetNumberOfRentals() == 0)
                {
                    // Open File
                    StreamWriter outFile = new StreamWriter("transactions.txt");

                    // Process
                    outFile.Write($"{transactions.GetRentalID()}#{transactions.GetISBN()}#{transactions.GetName().ToUpper()}#{transactions.GetEmail().ToUpper()}#{transactions.GetRentalDate()}#{transactions.GetReturnDate()}");

                    // Close File
                    outFile.Close();
                }
            }
        }
        public void WriteReportFile(string fileName, string[] reportArray)
        {
            // Find and assign current date to recordDate
            DateTime today = DateTime.Today;
            string recordDate = today.ToString("MM/dd/yyyy");
            // Open File
            StreamWriter outFile = new StreamWriter(fileName, true);
            // Process
            foreach (string textLine in reportArray)
            {
                if (textLine != null)
                {
                    outFile.WriteLine(textLine);
                }
            }
            outFile.WriteLine("_______________________________");
            outFile.WriteLine($"Date of Record : {recordDate}");

            // Close File
            outFile.Close();
        
        }
    }
}