using System;
using System.Linq;
using System.IO;


namespace pa5_ZachRussell42
{
    class Program
    {
        static void Main(string[] args)
        {
            // Establish Use of display and arrowselections
            pa5_ZachRussell42.ArrowSelection arrowSelect = new ArrowSelection();
            pa5_ZachRussell42.Display display = new Display();

            // Establish Base Variables
            int tally = 0;
            bool isMenuRunning = true;

            // Hides the cursor
            Console.CursorVisible = false;

            // Menu
            while (isMenuRunning)
            {
                Console.Clear();
                bool isEnterPressed = false;

                // Initial Display
                display.Options(ref tally);

                // Menu Choice Loop (breaks when 'Enter' is pressed)
                while (isEnterPressed == false)
                {
                    // Inputs key choice and converts it to a string
                    string keyInput = Console.ReadKey().Key.ToString();

                    // Create instance of ArrowKeyMovement
                    tally = arrowSelect.ArrowKeyMovement(keyInput, 0, 5, ref tally);

                    if (keyInput == "Enter" || keyInput == "Escape")
                    {
                        // Create instances of all objects that will be used, updates each time the program returns to the menu
                        AddEdit book = new AddEdit();
                        RentReturn transactions = new RentReturn();
                        book.SetCountTally(0);
                        transactions.SetCountTally(0);

                        InFile inFile = new InFile();
                        InFile inFileB = new InFile();

                        AddEdit[] readFiles = inFile.ReadFileA();
                        RentReturn[] readFilesB = inFileB.ReadFileB();

                        OutFile outFile = new OutFile(readFiles, book, readFilesB, transactions, inFile);
                        AddEdit addEdit = new AddEdit(outFile, inFile, readFiles, book, readFilesB);
                        RentReturn rentReturn = new RentReturn(outFile, inFile, inFileB, readFiles, readFilesB, book, transactions);
                        Reports reports = new Reports(readFiles, book, readFilesB, transactions, inFile, inFileB);

                        // Add
                        if (tally == 0 && keyInput == "Enter")
                        {
                            // Calls AddBook method from addEdit object
                            addEdit.AddBook();

                            // Initial Display
                            tally = 0;
                            Console.Clear();
                            display.Options(ref tally);

                        }

                        // Edit
                        else if (tally == 1 && keyInput == "Enter")
                        {
                            // Calls EditBook method from addEdit object
                            addEdit.EditBook();

                            // Initial Display
                            tally = 0;
                            Console.Clear();
                            display.Options(ref tally);   
                        }

                        // Rent
                        else if (tally == 2 && keyInput == "Enter")
                        {
                            // Rent book
                            rentReturn.RentBook();

                            // Initial Display
                            tally = 0;
                            Console.Clear();
                            display.Options(ref tally);
                            
                        }

                        // Return
                        else if (tally == 3 && keyInput == "Enter")
                        {
                            // Return book
                            rentReturn.ReturnBook();

                            // Initial Display
                            tally = 0;
                            Console.Clear();
                            display.Options(ref tally);
                        }

                        // Run Report
                        else if (tally == 4 && keyInput == "Enter")
                        {
                            tally = 10;
                            bool isEnterPressed2 = false;

                            // Initial Display
                            Console.Clear();
                            display.Options(ref tally);

                            // Menu Choice Loop (breaks when 'Enter' is pressed)
                            while (isEnterPressed2 == false)
                            {
                                // Inputs key choice and converts it to a string
                                string keyInput2 = Console.ReadKey().Key.ToString();

                                // Create instance of ArrowKeyMovement
                                tally = arrowSelect.ArrowKeyMovement(keyInput2, 10, 13, ref tally);

                                if (keyInput2 == "Enter" || keyInput2 == "Escape" || keyInput2 == "Backspace")
                                {
                                    // Total Rentals by month and by year
                                    while (tally == 10 && keyInput2 == "Enter")
                                    {
                                        Console.Clear();
                                        // Call TotalRentals through the reports instance
                                        string[] reportArray = reports.TotalRentals();
                                        Console.WriteLine("Enter '1' if you want to save data to a file, or press 'enter' to go back.");
                                        string menuChoice = Console.ReadLine();
                                        if (menuChoice == "1" && reportArray != null)
                                        {
                                            Console.WriteLine("Enter file name: ");
                                            string fileName = Console.ReadLine();
                                            outFile.WriteReportFile(fileName, reportArray);
                                        }
                                        // Initial Display
                                        keyInput = "";
                                        tally = 0;
                                        Console.Clear();
                                        isEnterPressed2 = true;
                                        display.Options(ref tally);
                                    }

                                    // Individual Customer Rentals
                                    while (tally == 11 && keyInput2 == "Enter")
                                    {
                                        Console.Clear();
                                        // Call IndividualReports through the reports instance
                                        string[] reportArray = reports.IndividualReports();
                                        Console.WriteLine("Enter '1' if you want to save data to a file, or press 'enter' to go back.");
                                        string menuChoice = Console.ReadLine();
                                        if (menuChoice == "1" && reportArray != null)
                                        {
                                            Console.WriteLine("Enter file name: ");
                                            string fileName = Console.ReadLine();
                                            outFile.WriteReportFile(fileName, reportArray);
                                        }
                                        // Initial Display
                                        keyInput = "";
                                        tally = 0;
                                        Console.Clear();
                                        isEnterPressed2 = true;
                                        display.Options(ref tally);
                                    }

                                    // Historical Customer Rentals
                                    while (tally == 12 && keyInput2 == "Enter")
                                    {
                                        Console.Clear();
                                        // Call HistoricalRentals through the reports instance
                                        string[] reportArray = reports.HistoricalRentals();
                                        Console.WriteLine("Enter '1' if you want to save data to a file, or press 'enter' to go back.");
                                        string menuChoice = Console.ReadLine();
                                        if (menuChoice == "1" && reportArray != null)
                                        {
                                            Console.WriteLine("Enter file name: ");
                                            string fileName = Console.ReadLine();
                                            outFile.WriteReportFile(fileName, reportArray);
                                        }
                                        // Initial Display
                                        keyInput = "";
                                        tally = 0;
                                        Console.Clear();
                                        isEnterPressed2 = true;
                                        display.Options(ref tally);
                                    }

                                    // Back
                                    while ((tally == 13 && keyInput2 == "Enter") || (keyInput2 == "Escape" || keyInput2 == "Backspace"))
                                    {
                                        isEnterPressed2 = true;
                                        // Initial Display
                                        keyInput = "";
                                        keyInput2 = "";
                                        tally = 0;
                                        Console.Clear();
                                        display.Options(ref tally);

                                    }
                                }
                            }
                        }

                        // Exit
                        else if ((tally == 5 && keyInput == "Enter") || keyInput == "Escape")
                        {
                            // Establish loop variables
                            bool isMenuRunning2 = true;
                            bool isEnterPressed2 = false;

                            // Establish tally position
                            tally = 8;
                            
                            // While exit menu is running loop
                            while (isMenuRunning2)
                            {
                                Console.Clear();
                                
                                // Initial Display
                                display.Options(ref tally);

                                // While 'Enter' hasn't been pressed loop
                                while (isEnterPressed2 == false)
                                {
                                    // Inputs key choice and converts it to a string
                                    string keyInput2 = Console.ReadKey().Key.ToString();

                                    // Create instance of ArrowKeyMovement
                                    tally = arrowSelect.ArrowKeyMovement(keyInput2, 8, 9, ref tally);

                                    // 'Enter' input to select options
                                    if (keyInput2 == "Enter" || keyInput2 == "Escape")
                                    {
                                        // 'Yes' to exit. Terminates program
                                        if (tally == 8 && keyInput2 == "Enter")
                                        {
                                            Console.Clear();

                                            // Set boolean values in a way that exits all loops
                                            isEnterPressed = true;
                                            isMenuRunning = false;
                                            isEnterPressed2 = true;
                                            isMenuRunning2 = false;

                                            // Makes cursor visible again
                                            Console.CursorVisible = true;


                                        }

                                        // 'No' to exit. Returns to menu
                                        else if ((tally == 9 && keyInput2 == "Enter") || keyInput2 == "Escape")
                                        {
                                            Console.Clear();

                                            // Resets tally position to menu number
                                            tally = 0;

                                            // Static display
                                            display.Options(ref tally);

                                            // Set boolean values in a way that exits 'Exit' loops
                                            isEnterPressed2 = true;
                                            isMenuRunning2 = false;
                                        }
                                    }

                                    // Clears input other than 'Enter' and up/down arrow keys
                                    else
                                    {
                                        Console.Clear();
                                        // Initial Display
                                        display.Options(ref tally);
                                    }
                                }
                            }
                        }
                    }

                    // Clears input other than 'Enter' and up/down arrow keys
                    else
                    {
                        Console.Clear();
                        // Initial Display
                        display.Options(ref tally);
                    }
                }

            }
        }
    }
}
