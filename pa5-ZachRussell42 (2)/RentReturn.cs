using System;

namespace pa5_ZachRussell42
{
    public class RentReturn
    {
        // Properties
        private int rentalID;
        private string ISBN;
        private string name;
        private string email;
        private string rentalDate;
        private string returnDate;
        private OutFile outFile;
        private InFile inFile;
        private InFile inFileB;
        private AddEdit[] readFiles;
        private RentReturn[] readFilesB;
        private AddEdit book;
        private RentReturn transactions;
        private static int countTally;

        // Constructors
        public RentReturn() {}
        public RentReturn(int rentalID, string ISBN, string name, string email, string rentalDate, string returnDate)
        {
            this.rentalID = rentalID;
            this.ISBN = ISBN;
            this.name = name;
            this.email = email;
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;
        }
        public RentReturn(OutFile outFile, InFile inFile, InFile inFileB, AddEdit[] readFiles, RentReturn[] readFilesB, AddEdit book, RentReturn transactions) 
        {
            this.outFile = outFile;
            this.inFile = inFile;
            this.inFileB = inFileB;
            this.readFiles = readFiles;
            this.readFilesB = readFilesB;
            this.book = book;
            this.transactions = transactions;
        }

        // Methods
        
            // rentalID setter
        public void SetRentalID(int rentalID)
        {
            this.rentalID = rentalID;
        }
            // rentalID getter
        public int GetRentalID()
        {
            return rentalID;
        }
            // ISBN setter
        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }
            // ISBN getter
        public string GetISBN()
        {
            return ISBN;
        }
            // name setter
        public void SetName(string name)
        {
            this.name = name;
        }
            // name getter
        public string GetName()
        {
            return name;
        }
            // email setter
        public void SetEmail(string email)
        {
            this.email = email;
        }
            // email getter
        public string GetEmail()
        {
            return email;
        }
            // rental date setter
        public void SetRentalDate(string rentalDate)
        {
            this.rentalDate = rentalDate;
        }
            // rental date getter
        public string GetRentalDate()
        {
            return rentalDate;
        }
            // return date setter
        public void SetReturnDate(string returnDate)
        {
            this.returnDate = returnDate;
        }
            // return date getter
        public string GetReturnDate()
        {
            return returnDate;
        }

        // Count Tally Setter
        public void SetCountTally(int tempCountTally)
        {
            countTally = tempCountTally;
        }

        // Count Tally Getter
        public static int GetCountTally()
        {
            return countTally;
        }

        // Increment Count Tally
        public static void IncCountTally()
        {
            countTally++;
        }

        // Rent
        public void RentBook()
        {
            Console.Clear();
            // View books
            Console.WriteLine("---------------------------------------------------------------------------------------AudioBooks---------------------------------------------------------------------------------");
            Console.WriteLine($"{"ISBN".PadRight(30, '_')}{"Title".PadRight(50, '_')}{"Author".PadRight(30, '_')}{"Genre".PadRight(30, '_')}{"Listening Time".PadRight(30, '_')}{"Count".PadRight(30, ' ')}\n");
            for (int i = 0; i < inFile.GetNumberOfBooks(); i++)
            {
                Console.WriteLine($"{readFiles[i].GetISBN().PadRight(30, ' ')}{readFiles[i].GetTitle().PadRight(50, ' ')}{readFiles[i].GetAuthor().PadRight(30, ' ')}{readFiles[i].GetGenre().PadRight(30, ' ')}{readFiles[i].GetListenTime().PadRight(30, ' ')}{Convert.ToString(readFiles[i].GetCount()).PadRight(30, ' ')}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            if (inFile.GetNumberOfBooks() == 0)
            {
                Console.WriteLine("N/A");
            }
                // Type ISBN from visual
            Console.WriteLine("\nPlease enter the ISBN of the book you would like to rent:\nISBN:");
            string ISBNInput = Console.ReadLine();
            // Determine if ISBN input exists and if there is a copy left
            bool isISBN = false;
            // Reset count tally
            book.SetCountTally(0);
            // Set temp count = 0
            int tempCount = 0;
            // Sets isCount = false by default. Only changes to true if chosen book count is 0
            bool isCount = false;

                // While loop to determine if ISBN matches anything
            while (readFiles[tempCount] != null && isISBN == false && isCount == false)
            {
                if (readFiles[tempCount].GetISBN() == ISBNInput)
                {
                    if (readFiles[tempCount].GetCount() > 0)
                    {
                        readFiles[tempCount].SetCount(readFiles[tempCount].GetCount() - 1);
                        isISBN = true;
                    }
                    else
                    {
                        Console.WriteLine("There are no more copies left of this audio book. Please wait for one to be returned or enter a different one.\nPress 'enter' to continue...");
                        Console.ReadLine();
                        isCount = true;
                    }
                }
                else
                {
                    tempCount++;
                }
            }
            if (readFiles[tempCount] == null && isISBN == false && inFile.GetNumberOfBooks() > 0)
            {
                Console.WriteLine("You did not enter a pre-existing ISBN number. Press 'enter' to try again...");
                Console.ReadLine();
            }
            if (readFiles[tempCount] == null && isISBN == false && inFile.GetNumberOfBooks() == 0)
            {
                Console.WriteLine("There are no books availabile to rent. Please add more audio books to the system database. Press 'enter' to continue...");
                Console.ReadLine();
            }
                
            // Rent book
            if (isISBN == true)
            {
                string[] tempName = {};
                bool isLastName = true;
                // Input Name and Email
                Console.Clear(); Console.WriteLine("Please enter:\nYour Name:"); string name = Console.ReadLine(); 
                if (name.Contains(' ')) 
                {
                    tempName = name.Split(' ');
                    // if statement that checks if the split name contains a last name 
                    if ((tempName.Length != 2) && (tempName[0] != " ") && (tempName[1] != " ")) {isLastName = false;}
                }
                else {isLastName = false;}
                // if statement that uses isLastName to determine if the program accesses the rent fuction or exits
                if (isLastName == false) {Console.WriteLine("Input does not contain a last name. Please input as '(first name) (last name)'.\nPress 'enter' to continue..."); Console.ReadLine();}
                else
                {
                    Console.Clear(); Console.WriteLine($"Please enter:\nYour Name: {name}\nYour Email:"); string email = Console.ReadLine(); bool isSymbol = email.Contains('@'); bool isPeriod = email.Contains('.'); bool isSpace = email.Contains(' ');
                    if (isSymbol == false || isPeriod == false || isSpace == true) {Console.WriteLine("Input is not a valid email. Please input as '(example@example.domain)'.\nPress 'enter' to continue..."); Console.ReadLine();}
                    else
                    {
                    
                        string ISBN = ISBNInput;

                        // Check if user has already rented chosen audio book
                                // While-loop and If-else statement to catch incorrect input
                        bool isEmail = false;   // bool isEmail is used for while loop. Changes to true once matching email is found
                        bool isISBN2 = false;    // bool isISBN is used for while loop. Changes to true once matching ISBN is found
                        bool isName = false;    // bool isName is use for while loop. Changes to true once a matching email but different name is found
                        int tempCount2 = 0;      // int tempCount is used for while loop. Keeps track of the current array

                        while (readFilesB[tempCount2] != null && (isEmail == false || isISBN2 == false) && isName == false)
                        {
                            // if email and ISBN match, isEmail and isISBN2 return true
                            if (readFilesB[tempCount2].GetEmail().ToUpper() == email.ToUpper() && readFilesB[tempCount2].GetName().ToUpper() != name.ToUpper())
                            {
                                isName = true;
                            }
                            else if (readFilesB[tempCount2].GetEmail().ToUpper() == email.ToUpper() && readFilesB[tempCount2].GetISBN() == ISBN)
                            {
                                isEmail = true;
                                isISBN2 = true;
                            }
                            else
                            {
                                tempCount2++;
                            }
                        }
                        if (isName)
                        {
                            Console.WriteLine($"There is a different name already tied to this email. Please use a different email.\nPress 'enter' to continue...");
                            Console.ReadLine();
                        }
                        else if (isEmail == true && isISBN2 == true && readFilesB[tempCount2].GetReturnDate() == "N/A")
                        {
                            Console.WriteLine($"You already have this audio book rented.\nPress 'enter' to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Add 1 to total number of rentals to get current unique rentalID
                            int rentalID = (inFileB.GetNumberOfRentals() + 1);

                            // Find and assign current date to rentalDate
                            DateTime today = DateTime.Today;
                            string rentalDate = today.ToString("MM/dd/yyyy");
                            
                            // Assign 'N/A' for return date as a place holder
                            string returnDate = "N/A";

                            // Assign variables to 'transactions' object
                            transactions.SetRentalID(rentalID); transactions.SetISBN(ISBN); transactions.SetName(name); transactions.SetEmail(email); transactions.SetRentalDate(rentalDate); transactions.SetReturnDate(returnDate);

                            // Append new user data to transactions
                            outFile = new OutFile(readFiles, book, readFilesB, transactions, inFile);
                            outFile.WriteFile('a');
                            outFile = new OutFile(readFiles, book, readFilesB, transactions, inFileB);
                            outFile.WriteFile('d');

                                // Update number of rentals
                            inFileB.SetNumberOfRentals(inFileB.GetNumberOfRentals() + 1);
                        }
                    }
                }
            }
        }

        // Return 
        public void ReturnBook()
        {
            // Input email and ISBN
            Console.Clear(); Console.WriteLine("Return Audio Book\n\nEnter Information:\nYour Email:"); string email = Console.ReadLine(); bool isSymbol = email.Contains('@'); bool isPeriod = email.Contains('.');
            if (isSymbol == false || isPeriod == false) {Console.WriteLine("Input is not a valid email. Please try again.\nPress 'enter' to continue..."); Console.ReadLine();}
            else
            {
                Console.Clear(); Console.WriteLine($"Return Audio Book\n\nEnter Information:\nYour Email: {email}\nISBN:"); string ISBN = Console.ReadLine();
                    // While-loop and If-else statement to catch incorrect input
                bool isEmail = false;   // bool isEmail is used for while loop. Changes to true once matching email is found
                bool isISBN = false;    // bool isISBN is used for while loop. Changes to true once matching ISBN is found
                int tempCount = 0;      // int tempCount is used for while loop. Keeps track of the current array

                while (readFilesB[tempCount] != null && (isEmail == false || isISBN == false))
                {
                    if (readFilesB[tempCount].GetEmail().ToUpper() == email.ToUpper() && readFilesB[tempCount].GetISBN() == ISBN && readFilesB[tempCount].GetReturnDate() == "N/A")
                    {
                        isEmail = true;
                        isISBN = true;
                    }
                    else
                    {
                        tempCount++;
                    }
                }
                if ((isEmail == false || isISBN == false) || (readFilesB[tempCount].GetReturnDate() != "N/A"))
                {
                    Console.WriteLine($"The email '{email}' matched with the book ISBN of '{ISBN}' could not be found in the transactions log, or it has already been returned. Please re-enter the information.\nPress 'enter' to continue...");
                    Console.ReadLine();
                }
                else if (isEmail == true && isISBN == true && readFilesB[tempCount].GetReturnDate() == "N/A")
                {
                    // Add 1 to 'count' of the returned book
                        // Find equivalent ISBN
                            // Establish different tempCount int
                    int tempCount2 = 0;
                            // Establish different isISBN bool
                    bool isISBN2 = false;
                        // While loop searching for ISBN
                    while (readFiles[tempCount2] != null && isISBN2 == false)
                    {
                        if ((readFiles[tempCount2].GetISBN()) == ISBN)
                        {
                            isISBN2 = true;
                            readFiles[tempCount2].SetCount((readFiles[tempCount2].GetCount()) + 1);
                        }
                        if (isISBN2 == false)
                        {
                            tempCount2++;
                        }
                    }

                    // Update returnDate
                        // Find current date
                    DateTime today = DateTime.Today;
                        // Convert DateTime current date into a string
                    string returnDate = today.ToString("MM/dd/yyyy");
                        // Set returnDate
                    readFilesB[tempCount].SetReturnDate(returnDate);


                    // Update txt files
                    outFile = new OutFile(readFiles, book, readFilesB, transactions, inFile);
                    outFile.WriteFile('a');
                    outFile = new OutFile(readFiles, book, readFilesB, transactions, inFileB);
                    outFile.WriteFile('c');
                }
            }
        }
    }
}