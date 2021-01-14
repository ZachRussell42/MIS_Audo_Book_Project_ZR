using System;
using System.Linq;

namespace pa5_ZachRussell42
{
    public class Reports
    {
        // Properties
        private AddEdit[] readFiles;
        private AddEdit book;
        private RentReturn[] readFilesB;
        private RentReturn transactions;
        private InFile inFile;
        private InFile inFileB;


        // Constructors
        public Reports(){}

        public Reports(AddEdit[] readFiles, AddEdit book, RentReturn[] readFilesB, RentReturn transactions, InFile inFile, InFile inFileB)
        {
            this.readFiles = readFiles;
            this.book = book;
            this.readFilesB = readFilesB;
            this.transactions = transactions;
            this.inFile = inFile;
            this.inFileB = inFileB;
        }

        // Methods
        public string[] TotalRentals()
        {
            // while loop that searches for rentals made in an input month and year (MM/yyyy)

            // string text variables for array
            string title1;
            string title2;
            string textOutput;
            string closingLine;
            // string array for text data
            string[] reportArray = new string[inFileB.GetNumberOfRentals() + 3];
            int loopCount2 = 2;
                // temp variables for while loop
            int loopCount = 0;
            int rentalCount = 0;
            // User input for month and year
            Console.WriteLine("Input Date - leave month or year empty to exclude it from the sorting");
            Console.WriteLine("Input Month (MM):");
            string monthInput = Console.ReadLine();
            Console.WriteLine("Input Year (yyyy):");
            string yearInput = Console.ReadLine();

            // Title text
            title1 = ($"{"".PadRight(45, '_')}All_Rentals{"".PadRight(45, '_')}"); Console.WriteLine(title1); reportArray[0] = title1;
            title2 = ($"{"ISBN".PadRight(30, '_')}{"Name".PadRight(30, '_')}{"Rental Date".PadRight(30, '_')}Return Date"); Console.WriteLine(title2); reportArray[1] = title2;

                // while loop that displays and counts
            while (readFilesB[loopCount] != null)
            {
                    // split rental date by month and year
                string[] date = (readFilesB[loopCount].GetRentalDate()).Split('/');
                    // if statement checking if month and year match inputs
                if ((date[0] == monthInput && date[2] == yearInput) || (date[0] == monthInput && yearInput == "") || (monthInput == "" && yearInput == date[2]))
                {
                    textOutput = ($"{readFilesB[loopCount].GetISBN().PadRight(30, ' ')}{readFilesB[loopCount].GetName().PadRight(30, ' ')}{readFilesB[loopCount].GetRentalDate().PadRight(30, ' ')}{readFilesB[loopCount].GetReturnDate()}");
                    Console.WriteLine(textOutput);
                    rentalCount++;

                    // record in array
                    reportArray[loopCount2] = textOutput;
                    loopCount2++;
                }
                loopCount++;
            }

            // if-else statements to determine what to display
            if (monthInput != "" && yearInput != "")
            {
                closingLine = ($"{"".PadRight(45, '_')}___________{"".PadRight(45, '_')}") + ($"\nTotal Rentals for the month '{monthInput}' of the year '{yearInput}' is {rentalCount}"); Console.WriteLine(closingLine);
                // Record in array
                reportArray[loopCount2] = closingLine;
            }
            else if (monthInput == "" && yearInput != "")
            {
                closingLine = ($"{"".PadRight(45, '_')}___________{"".PadRight(45, '_')}") + ($"\nTotal Rentals for the year of '{yearInput}' is {rentalCount}"); Console.WriteLine(closingLine);
                // Record in array
                reportArray[loopCount2] = closingLine;
            }
            else if (monthInput != "" && yearInput == "")
            {
                closingLine = ($"{"".PadRight(45, '_')}___________{"".PadRight(45, '_')}") + ($"\nTotal Rentals for the month '{monthInput}' of all years is {rentalCount}"); Console.WriteLine(closingLine);
                // Record in array
                reportArray[loopCount2] = closingLine;
            }
            else
            {
                Console.WriteLine("You did not input any dates, please try again.\nPress enter to continue...");
            }

            return reportArray;
        }

        public string[] IndividualReports()
        {
            // Establish strings used for texts
            string title1;
            string textOutput;
            string textDivider;
            string userTotal;
            // Establish text array
            string[] reportArray = new string[100];
            int loopCount2 = 1;

            // while loop that searches rentals made by an input email address
                // temp variables for while loop
            int loopCount = 0;
            int rentalCount = 0;
                // User input for email
            Console.WriteLine("Input Email:");
            string emailInput = Console.ReadLine(); Console.Clear();
                // temp userName variable to be used in display
            string userName = "";
                // "Database" Display
            title1 = ("________________________________________________________Individual_Report________________________________________________________"); Console.WriteLine(title1); reportArray[0] = title1;

                // while loop that displays and counts
            while (readFilesB[loopCount] != null)
            {
                if (emailInput.ToUpper() == readFilesB[loopCount].GetEmail().ToUpper())
                {
                    textOutput = ($"\nEmail : {readFilesB[loopCount].GetEmail()}      Name : {readFilesB[loopCount].GetName()}      ISBN : {readFilesB[loopCount].GetISBN()}        Rental Date : {readFilesB[loopCount].GetRentalDate()}       Return Date : {readFilesB[loopCount].GetReturnDate()}");
                    reportArray[loopCount2] = textOutput;
                    loopCount2++;
                    Console.WriteLine(textOutput);
                    rentalCount++;

                    // assign the name of user
                    userName = readFilesB[loopCount].GetName();
                }
                loopCount++;
            }
            textDivider = ("------------------------------------------------------------------------------------------------------------------------"); reportArray[loopCount2] = textDivider;
            loopCount2++;
            Console.WriteLine(textDivider);

            if (rentalCount > 0)
            {
                userTotal = ($"\n{userName} has rented a total of {rentalCount} audio books");
                reportArray[loopCount2] = userTotal;
                Console.WriteLine(userTotal);
            }
            else
            {
                Console.WriteLine($"The email input '{emailInput}' is not found in the database\n\nPress 'enter' to continue...");
            }

            return reportArray;
        }

        public string[] HistoricalRentals()
        {
            // Establish temp loop variables
            int loopCount = 0;
            string[] tempArrayEmails = new string[inFileB.GetNumberOfRentals()];

            // Sort by customer
            while (readFilesB[loopCount] != null)
            {
                // Assign each customer name to a spot in the tempArray
                tempArrayEmails[loopCount] = readFilesB[loopCount].GetEmail();
                // Sort by date for each customer
                loopCount++;
            }
            // Sort all email array by first letter of email
            Array.Sort(tempArrayEmails);

            // establish uniqueEmails array to hold only 1 copy of each person's email
            string[] uniqueEmails = new string[inFileB.GetNumberOfRentals()];
            int[] totalRentals = new int[inFileB.GetNumberOfRentals()];
            
            // establish temp loop variables
            int loopCount2 = 0;
            int loopCount3 = 0;

            if (inFileB.GetNumberOfRentals() > 0)
            {
                totalRentals[loopCount3]++;
            }

            // for loop that only keeps unique emails and assigns them to the uniqueEmails array
            for (loopCount2 = 1; loopCount2 < inFileB.GetNumberOfRentals(); loopCount2++)
            {
                if (tempArrayEmails[loopCount2 - 1] != tempArrayEmails[loopCount2])
                {
                    uniqueEmails[loopCount3] = tempArrayEmails[loopCount2 - 1];
                    loopCount3++;
                }
                if (loopCount2 == (inFileB.GetNumberOfRentals() - 1))
                {
                    uniqueEmails[loopCount3] = tempArrayEmails[loopCount2];
                    totalRentals[loopCount3]++;
                    loopCount3++;
                }
                else
                {
                    totalRentals[loopCount3]++;
                }
            }


            loopCount2 = 0;
            int loopCount4 = 3;
            // Establish all strings for myArray
            string title1;
            string title2;
            string title3;
            // Sort transactions
            title1 = ("___________________________________");
            title2 = ("Sorted by Email then by Rental Time");
            title3 = ($"{"Email".PadRight(30, '_')}{"Name".PadRight(30, '_')}{"Rental ID".PadRight(30, '_')}{"ISBN".PadRight(30, '_')}{"Rental Date".PadRight(30, '_')}{"Return Date".PadRight(30, '_')}{"Total Rentals".PadRight(30, ' ')}");
            Console.WriteLine(title1 + "\n" + title2 + "\n" + title3);
            string textOutput = "";
            string textDivider = "";
            string customerTotals;
            string[] myArray = new string[inFileB.GetNumberOfRentals()*3];
            myArray[0] = title1; myArray[1] = title2; myArray[2] = title3;
            while (loopCount2 < loopCount3)
            {
                loopCount = 0;
                textDivider =($"{"-".PadRight(193, '-')}");
                Console.WriteLine(textDivider);
                myArray[loopCount4] = textDivider;
                // while loop
                while (readFilesB[loopCount] != null)
                {
                    if (uniqueEmails[loopCount2] == readFilesB[loopCount].GetEmail())
                    {
                        textOutput = ($"{readFilesB[loopCount].GetEmail().PadRight(30, ' ')}{readFilesB[loopCount].GetName().PadRight(30, ' ')}{Convert.ToString(readFilesB[loopCount].GetRentalID()).PadRight(30, ' ')}{readFilesB[loopCount].GetISBN().PadRight(30, ' ')}{readFilesB[loopCount].GetRentalDate().PadRight(30, ' ')}{readFilesB[loopCount].GetReturnDate().PadRight(30, ' ')}");
                        Console.WriteLine(textOutput);
                        loopCount4++;
                        myArray[loopCount4] = textOutput;
                    }
                    loopCount++;
                }
                customerTotals = ($"{"".PadRight(192, ' ')}{Convert.ToString(totalRentals[loopCount2]).PadRight(30, ' ')}");
                Console.WriteLine(customerTotals);
                loopCount2++;

                loopCount4++;
                myArray[loopCount4] = customerTotals;
                loopCount4++;
            }
            return myArray;
        }
    }
}