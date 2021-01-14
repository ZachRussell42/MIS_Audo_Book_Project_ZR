using System.IO;
using System;
using System.Linq;

namespace pa5_ZachRussell42
{
    public class InFile
    {
        // Properties
        private int numberOfBooks;
        private int numberOfRentals;

        // Constructors
        public InFile(){}          

        // Methods

                // number of books setter
        public void SetNumberOfBooks(int numberOfBooks)
        {
            this.numberOfBooks = numberOfBooks;
        }
                // number of books getter
        public int GetNumberOfBooks()
        {
            return numberOfBooks;
        }
                // number of rentals setter
        public void SetNumberOfRentals(int numberOfRentals)
        {
            this.numberOfRentals = numberOfRentals;
        }
                // number of rentals getter
        public int GetNumberOfRentals()
        {
            return numberOfRentals;
        }


            // ReadFile Method
        public AddEdit[] ReadFileA()
        {
                // Open File
            StreamReader inFile = new StreamReader("books.txt");

                // Process
            string input = inFile.ReadLine(); // priming read

                    // Temp array
                AddEdit[] myArray = new AddEdit[100];
                    // For each line in books.txt
                while(input != null)
                {
                            // Split by '#' delimiter
                    string[] temp = input.Split('#');
                            // Convert count variable into an int
                    int count = Convert.ToInt32(temp[5]);
                            // Copy each line into temp array
                    myArray[AddEdit.GetCountTally()] = new AddEdit(temp[0], temp[1], temp[2], temp[3], temp[4], count);
                    AddEdit.IncCountTally();

                    // Add 1 to number of books in system
                    numberOfBooks = numberOfBooks + 1;

                    // Update Read
                    input = inFile.ReadLine();
                }

            inFile.Close();
            return myArray;
        }

        // Read File method for rent return
        public RentReturn[] ReadFileB()
        {
            //int tempCount = 0;
                // Open File
            StreamReader inFile = new StreamReader("transactions.txt");

                // Process
            string input = inFile.ReadLine(); // priming read

            // Temp array
                RentReturn[] myArray = new RentReturn[100];
                    // For each line in books.txt
                while(input != null)
                {
                            // Split by '#' delimiter
                    string[] temp = input.Split('#');
                            // Convert count variable into an int
                    int rentalID = Convert.ToInt32(temp[0]);
                            // Copy each line into temp array
                    myArray[RentReturn.GetCountTally()] = new RentReturn(rentalID, temp[1], temp[2], temp[3], temp[4], temp[5]);
                    RentReturn.IncCountTally();
                    //tempCount++;

                    // Add 1 to number of rentals in system
                    numberOfRentals++;

                    // Update Read
                    input = inFile.ReadLine();
                }

            inFile.Close();
            return myArray;
        }
    }
}