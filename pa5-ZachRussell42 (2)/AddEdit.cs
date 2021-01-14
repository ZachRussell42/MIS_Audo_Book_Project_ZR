using System.IO;
using System;

namespace pa5_ZachRussell42
{
    public class AddEdit
    {
        // Properties
        private string ISBN;
        private string title;
        private string author;
        private string genre;
        private string listenTime;
        private int count;
        private OutFile outFile;
        private InFile inFile;
        private AddEdit[] readFiles;
        private AddEdit book;
        private RentReturn[] readFilesB;

        private static int countTally;
        // Constructors
        public AddEdit(){}
        public AddEdit(string ISBN, string title, string author, string genre, string listenTime, int count)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.listenTime = listenTime;
            this.count = count;
        }

        public AddEdit(OutFile outFile, InFile inFile, AddEdit[] readFiles, AddEdit book, RentReturn[] readFilesB) 
        {
            this.outFile = outFile;
            this.inFile = inFile;
            this.readFiles = readFiles;
            this.book = book;
            this.readFilesB = readFilesB;
        }
        // Methods
        // ISBN Setter
        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }
        // ISBN Getter
        public string GetISBN()
        {
            return ISBN;
        }
        // Title Setter
        public void SetTitle(string title)
        {
            this.title = title;
        }
        // Title Getter
        public string GetTitle()
        {
            return title;
        }
        // Author Setter
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        // Author Getter
        public string GetAuthor()
        {
            return author;
        }
        // Genre Setter
        public void SetGenre(string genre)
        {
            this.genre = genre;
        }
        // Genre Getter
        public string GetGenre()
        {
            return genre;
        }
        // Listening Time Setter
        public void SetListenTime(string listenTime)
        {
            this.listenTime = listenTime;
        }
        // Listening Time Getter
        public string GetListenTime()
        {
            return listenTime;
        }
        // Count Setter
        public void SetCount(int count)
        {
            this.count = count;
        }
        // Count Getter
        public int GetCount()
        {
            return count;
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

        // Add Method
        public void AddBook()
        {
            Console.Clear();
            // Resets count tally
            book.SetCountTally(0);
            // Prompt user to enter ISBN
            Console.WriteLine("(Enter '-1' to go back)\n\nEnter ISBN :");
            string ISBNInput = Console.ReadLine();
            // Determine if ISBN matches any current books
            int element = 0;
            // Establish bool values
            bool isInput = false;
            bool isISBN = false;
            bool isTitle = false;
            isInput = IsInputInvalid(ISBNInput, 'b');
            if (isInput == false)
            {
                isISBN = IsISBNMatching(ISBNInput, readFiles, ref element);

                // Add 1 to count if ISBN already exists
                if (isISBN == true)
                {
                    readFiles[element].SetCount((readFiles[element].GetCount()) + 1);
                    Console.WriteLine($"This audio book already exists in the system. You add 1 to the stock");
                    Console.WriteLine($"The audio book titled '{readFiles[element].GetTitle()}' has increased its stock to {readFiles[element].GetCount()}\nPress enter to continue...");
                    Console.ReadLine();
                    // Save data
                    outFile.WriteFile('a');
                }
                    // Add new book
                else if (isISBN == false && isInput == false)
                {
                    // Assigns user input to each variable

                    Console.Clear(); Console.WriteLine($"(Enter '-1' to go back)\n\nPlease enter:\nISBN: {ISBNInput}\nTitle:"); string titleInput = Console.ReadLine(); isInput = IsInputInvalid(titleInput, 'a');
                    if (isInput == false)
                    {
                        Console.Clear(); Console.WriteLine($"(Enter '-1' to go back)\nPlease enter:\nISBN: {ISBNInput}\nTitle: {titleInput}\nAuthor:"); string authorInput = Console.ReadLine(); isInput = IsInputInvalid(authorInput, 'a');
                        // Check if title input is invalid and/or if it already exits with author
                        if (isInput == false) {isTitle = IsTitleMatchingAuthor(titleInput, authorInput, readFiles);}
                        if (isInput == false && isTitle == false)
                        {
                            Console.Clear(); Console.WriteLine($"(Enter '-1' to go back)\n\nPlease enter:\nISBN: {ISBNInput}\nTitle: {titleInput}\nAuthor: {authorInput}\nGenre:"); string genreInput = Console.ReadLine(); isInput = IsInputInvalid(genreInput, 'a');
                            if (isInput == false)
                            {
                                Console.Clear(); Console.WriteLine($"(Enter '-1' to go back)\n\nPlease enter:\nISBN: {ISBNInput}\nTitle: {titleInput}\nAuthor: {authorInput}\nGenre: {genreInput}\nListen Time (minutes):"); string listenTimeInput = Console.ReadLine(); isInput = IsInputInvalid(listenTimeInput, 'b');
                                if (isInput == false)
                                {
                                    Console.Clear(); Console.WriteLine($"(Enter '-1' to go back)\n\nPlease enter:\nISBN: {ISBNInput}\nTitle: {titleInput}\nAuthor: {authorInput}\nGenre: {genreInput}\nListen Time (minutes): {listenTimeInput}\nCount:"); string countInputString = Console.ReadLine(); isInput = IsInputInvalid(countInputString, 'b');
                                    if (isInput == false)
                                    {
                                        // Convert count to int
                                        int countInput = Convert.ToInt32(countInputString);
                                        // Sets each input equal to book instance
                                        book.SetISBN(ISBNInput); book.SetTitle(titleInput); book.SetAuthor(authorInput); book.SetGenre(genreInput); book.SetListenTime(listenTimeInput); book.SetCount(countInput);
                                        // Save new data
                                        outFile.WriteFile('b');
                                        // Update number of unique books
                                        inFile.SetNumberOfBooks(inFile.GetNumberOfBooks() + 1);
                                    }
                                }
                            }
                        }
                    }
        
                }
            }
        }
        // Edit Method
        public void EditBook()
        {
            Console.Clear();
            // Display "enter the ISBN of the book you want to edit"
            Console.WriteLine("Enter the ISBN of the book you would like to edit:\nISBN:");
            string ISBNInput = Console.ReadLine();
            // Check ISBN to see if book is currently rented
            int element = 0;
            bool isConflict = CheckForConflicts(ISBNInput, readFiles, readFilesB, ref element);
            // Reset count tally
            book.SetCountTally(0);

            if (isConflict == false)
            {
                Console.Clear();

                // allow user to edit information
                Console.WriteLine("Please enter:\nNew ISBN:"); ISBNInput = Console.ReadLine();  isConflict = IsInputInvalid(ISBNInput, 'b'); if (!isConflict) {isConflict = IsInputInvalid(ISBNInput, 'c');}
                if (isConflict == false)
                {
                    Console.Clear(); Console.WriteLine($"Please enter:\nNew ISBN: {ISBNInput}\nNew Title:"); string titleInput = Console.ReadLine(); isConflict = IsInputInvalid(titleInput, 'a');
                    if (isConflict == false)
                    {
                        Console.Clear(); Console.WriteLine($"Please enter:\nNew ISBN: {ISBNInput}\nNew Title: {titleInput}\nNew Author:"); string authorInput = Console.ReadLine(); isConflict = IsInputInvalid(authorInput, 'a');
                        if (isConflict == false){isConflict = IsTitleMatchingAuthor(titleInput, authorInput, readFiles);}
                        if (isConflict == false)
                        {
                            Console.Clear(); Console.WriteLine($"Please enter:\nNew ISBN: {ISBNInput}\nNew Title: {titleInput}\nNew Author: {authorInput}\nNew Genre:"); string genreInput = Console.ReadLine(); isConflict = IsInputInvalid(genreInput, 'a');
                            if (isConflict == false)
                            {
                                Console.Clear(); Console.WriteLine($"Please enter:\nNew ISBN: {ISBNInput}\nNew Title: {titleInput}\nNew Author: {authorInput}\nNew Genre: {genreInput}\nNew Listen Time:"); string listenTimeInput = Console.ReadLine(); isConflict = IsInputInvalid(listenTimeInput, 'b');
                                if (isConflict == false)
                                {
                                    Console.Clear(); Console.WriteLine($"Please enter:\nNew ISBN: {ISBNInput}\nNew Title: {titleInput}\nNew Author: {authorInput}\nNew Genre: {genreInput}\nNew Listen Time: {listenTimeInput}\nNew Count:"); string countInputString = Console.ReadLine(); isConflict = IsInputInvalid(countInputString, 'b');
                                    if (isConflict == false)
                                    {
                                        // Convert count into an int
                                        int countInput = Convert.ToInt32(countInputString);
                                        // Change array values
                                        readFiles[element].SetISBN(ISBNInput); readFiles[element].SetTitle(titleInput); readFiles[element].SetAuthor(authorInput); readFiles[element].SetGenre(genreInput); readFiles[element].SetListenTime(listenTimeInput); readFiles[element].SetCount(countInput);
                                        // Save array to books.txt file
                                        outFile.WriteFile('a');
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
        // Check input for conflicts Method
        private bool CheckForConflicts(string ISBNInput, AddEdit[] readFiles, RentReturn[] readFilesB, ref int element)
        {
            int tempCount = 0;
            bool isConflictISBN = false;
            bool isConflictRent = false;

            // check if matching ISBN
            bool isISBN = IsISBNMatching(ISBNInput, readFiles, ref element);
            // check if ISBN is a number
            bool isInt = IsInputInvalid(ISBNInput, 'b');
            if (isISBN == false && isInt == false)
            {
                isConflictISBN = true;
                Console.WriteLine("The ISBN you entered is not in the database.\nPress 'enter' to continue...");
                Console.ReadLine();
            }
            if (isInt) {isConflictISBN = true;}
            
            // Reset tempCount
            tempCount = 0;

            // loop for checking if rented
            while (readFilesB[tempCount] != null && isConflictRent == false)
            {
                if (readFilesB[tempCount].GetISBN() == ISBNInput && readFilesB[tempCount].GetReturnDate() == "N/A")
                {
                    isConflictRent = true;
                    Console.WriteLine("The audio book you want to edit is currently being rented. You cannot edit the book until all copies have been returned.\nPress 'enter' to continue...");
                    Console.ReadLine();
                }
                else if (isConflictRent == false)
                {
                    tempCount++;
                }
            }
            // Establish return bool
            bool isConflict = false;
            if (isConflictISBN == true || isConflictRent == true) {isConflict = true;}
            return isConflict;
        }
        // Check if there is a matching ISBN for input
        private bool IsISBNMatching(string ISBNInput, AddEdit[] readFiles, ref int element)
        {
            // establish variables
            int tempCount = 0;
            bool isISBN = false;
            while (readFiles[tempCount] != null && isISBN == false)
            {
                if ((readFiles[tempCount].GetISBN()) == ISBNInput)
                {
                    isISBN = true;
                    element = tempCount;
                }
                if (isISBN == false)
                {
                    tempCount++;
                }
            }
            return isISBN;
        }
        
        // Check for matching titles
        private bool IsTitleMatchingAuthor(string titleInput, string authorInput, AddEdit[] readFiles)
        {
            // establish variables
            int tempCount = 0;
            bool isTitle = false;

            while (readFiles[tempCount] != null && isTitle == false)
            {
                if (readFiles[tempCount].GetTitle().ToUpper() == titleInput.ToUpper() && readFiles[tempCount].GetAuthor().ToUpper() == authorInput.ToUpper())
                {
                    isTitle = true;
                    Console.WriteLine($"The title '{titleInput}' by '{authorInput}' already exists in the database\nPress 'enter' to continue...");
                    Console.ReadLine();
                }
                if (isTitle == false)
                {
                    tempCount++;
                }
            }

            return isTitle;
        }
        
        // Check for invalid input
        private bool IsInputInvalid(string input, char version)
        {
            bool isInput = false;
            int maxLetters = 20;
            if (version == 'a' && input.Length >= 20) {maxLetters = 50;}
            // Checks if input is empty or if it reaches the max letter capacity
            if (version == 'a')
            {
                if (input == null || input == "")
                {
                    Console.WriteLine("Input is invalid. Try again.\nPress 'enter' to continue...");
                    Console.ReadLine();
                    isInput = true;
                }
                else if (input.Length >= maxLetters)
                {
                    Console.WriteLine($"Input is longer than {maxLetters -1} letters. Try again.\nPress 'enter' to continue...");
                    Console.ReadLine();
                    isInput = true;
                }
            }
            // checks if input is an int
            else if (version == 'b')
            {
                int num;
                if (int.TryParse(input, out num) == false)
                {
                    Console.WriteLine("Input is not an integer. Please enter a whole number.\nPress 'enter' to continue...");
                    Console.ReadLine();
                    isInput = true;
                }
                if (isInput == false)
                {
                    num = Convert.ToInt32(input);
                }
                // if number is less than or equal to zero or higher than 10 million, it will set input as invalid
                if ((num != -1 && (num <= 0 || num >= 100000000) && isInput == false))
                {
                    Console.WriteLine("Input is outside of boundaries. It needs to be greater than 0 and less than 100,000,000\nPress 'enter' to continue...");
                    Console.ReadLine();
                    isInput = true;
                }
                if (num == -1)
                {
                    isInput = true;
                }  
            }
            // Checks if input ISBN already exists
            else if (version == 'c')
            {
                // establish variables
                int tempCount = 0;
                while (readFiles[tempCount] != null && isInput== false)
                {
                    if ((readFiles[tempCount].GetISBN()) == input)
                    {
                        Console.WriteLine("This ISBN number already exists, try a different value.\nPress 'enter' to continue...");
                        Console.ReadLine();
                        isInput = true;
                    }
                    if (isInput == false)
                    {
                        tempCount++;
                    }
                }
            }

            return isInput;
        }
    }
}