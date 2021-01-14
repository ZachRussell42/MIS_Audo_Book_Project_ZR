using System;

namespace pa5_ZachRussell42
{
    public class Display
    {
        // Uses the tally variable
        public void Options(ref int tally)
        {
            // if statement boundaries allow for additional space to add future options if need be
            // menu
            if (tally <= 7)
            {
                ColorLine(" __________________", "Cyan", 1);
                ColorLine("|Audio Books Menu  ", "Cyan", 2); ColorLine("|", "Cyan", 2); Console.WriteLine("\\");
                ColorLine("|------------------", "Cyan", 2); ColorLine("|", "Cyan", 2); Console.WriteLine("|\\");
                ColorLine("|", "Cyan", 2); ArrowSelect("Add", 0, tally, 2); ColorLine("             |", "Cyan", 2); Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ArrowSelect("Edit", 1, tally, 2); ColorLine("            |", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ArrowSelect("Rent", 2, tally, 2); ColorLine("            |", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ArrowSelect("Return", 3, tally, 2); ColorLine("          |", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ArrowSelect("Run Report", 4, tally, 2); ColorLine("      |", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ColorLine("------------------", "Red", 2); ColorLine("|", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|", "Cyan", 2);ArrowSelect("Exit", 5, tally, 2); ColorLine("            |", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("|__________________", "Cyan", 2); ColorLine("|", "Cyan", 2);Console.Write("|"); ColorLine("|", "Cyan", 1);
                ColorLine("\\", "Cyan", 2); Console.Write("__________________\\|"); ColorLine("|", "Cyan", 1);
                ColorLine(" \\__________________", "Cyan", 2); Console.Write("\\"); ColorLine("|", "Cyan", 1);

            }

            // Exit options
            if (tally >= 8 && tally <= 9)
            {
                ColorLine(" __________________", "Red", 1);
                ColorLine("|       Exit       ", "Red", 2); ColorLine("|", "Red", 2); Console.WriteLine("\\");
                ColorLine("|------------------", "Red", 2); ColorLine("|", "Red", 2); Console.WriteLine("|\\");
                ColorLine("|", "Red", 2); ArrowSelect("Yes", 8, tally, 2); ColorLine("             |", "Red", 2); Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2); ColorLine("                  |", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2); ColorLine("                  |", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2); ColorLine("                  |", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2); ColorLine("                  |", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2);ColorLine("------------------", "Red", 2); ColorLine("|", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|", "Red", 2);ArrowSelect("No ", 9, tally, 2); ColorLine("             |", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("|__________________", "Red", 2); ColorLine("|", "Red", 2);Console.Write("|"); ColorLine("|", "Red", 1);
                ColorLine("\\", "Red", 2); Console.Write("__________________\\|"); ColorLine("|", "Red", 1);
                ColorLine(" \\__________________", "Red", 2); Console.Write("\\"); ColorLine("|", "Red", 1);
            }

            // Report options
            if (tally >= 10 && tally <= 14)
            {
                ColorLine(" ______________________________", "Green", 1);
                ColorLine("|          Report Menu         ", "Green", 2); ColorLine("|", "Green", 2); Console.WriteLine("\\");
                ColorLine("|------------------------------", "Green", 2); ColorLine("|", "Green", 2); Console.WriteLine("|\\");
                ColorLine("|", "Green", 2); ArrowSelect("Total Rentals", 10, tally, 2); ColorLine("               |", "Green", 2); Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2); ColorLine("                              |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2);ArrowSelect("Individual Customer Rentals", 11, tally, 2); ColorLine(" |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2); ColorLine("                              |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2);ArrowSelect("Historical Customer Rentals", 12, tally, 2); ColorLine(" |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2); ColorLine("                              |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2); ColorLine("                              |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2); ColorLine("                              |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2);ColorLine("------------------------------", "Red", 2); ColorLine("|", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|", "Green", 2);ArrowSelect("Back", 13, tally, 2); ColorLine("                        |", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("|______________________________", "Green", 2); ColorLine("|", "Green", 2);Console.Write("|"); ColorLine("|", "Green", 1);
                ColorLine("\\", "Green", 2); Console.Write("______________________________\\|"); ColorLine("|", "Green", 1);
                ColorLine(" \\______________________________", "Green", 2); Console.Write("\\"); ColorLine("|", "Green", 1);
            }
        }


        // WriteLine/write for the selected option. Uses a text input, the menu choice tally, and a number to match with the tally. 'version' determines whether its WriteLine or Write
        public void ArrowSelect(string text, int textNum, int tally, int version)
        {
            // Version 1 is a 'WriteLine' output
            if (version == 1)
            {
                // Uses the user text input and current menu tally to determine if a specific text should be highlighted to display that the user currently has it selected
                if (textNum == tally) 
                {
                    ColorLine("► " + text, "Yellow", 1);
                }

                // If the assigned number and the menu tally dont match, it means the user does not have that option selected, so it is printed as a regular, unaltered text
                else
                {
                    Console.WriteLine("  " + text);
                }
            }
            // version 2 is a 'Write' output
            else if (version == 2)
            {
                // Uses the user text input and current menu tally to determine if a specific text should be highlighted to display that the user currently has it selected
                if (textNum == tally)
                {
                    ColorLine("► " + text, "Yellow", 2);
                }

                // If the assigned number and the menu tally dont match, it means the user does not have that option selected, so it is printed as a regular, unaltered text
                else
                {
                    Console.Write("  " + text);
                }
            }
        }


        // Color Text (WriteLine)
        public void ColorLine(string text, string color, int version)
        {
            // Changes color of a string if you pass the text and color parameters
            if (color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == "Cyan")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (color == "DarkGreen")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (color == "Gray")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (color == "Magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (color == "DarkRed")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (color == "DarkBlue")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            // version 1 is a 'WriteLine' output
            if (version == 1)
            {
                Console.WriteLine(text);        // .PadRight(Console.WindowWidth - 1)
            }

            // version 2 is a 'Write' output
            else if (version == 2)
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }
    }
}