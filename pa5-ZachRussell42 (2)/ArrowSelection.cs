using System;

namespace pa5_ZachRussell42
{
    public class ArrowSelection
    {
        // Arrow Key Selection Movement
        public int ArrowKeyMovement(string keyInput, int min, int max, ref int tally)
        {
            // Establishes use of classes
            pa5_ZachRussell42.Display display = new Display();

            // Up arrow input that decreases menu choice tally
            if (keyInput == "UpArrow")
            {
                Console.Clear();
                tally--;
                tally = IntBoundaries(tally, min, max);
                display.Options(ref tally);
            }

            // Down arrow input that increases menu choice tally
            if (keyInput == "DownArrow")
            {
                Console.Clear();
                tally++;
                tally = IntBoundaries(tally, min, max);
                display.Options(ref tally);
            }
            // Returns new choice tally
            return tally;
        }


        // Set boundaries to an integer method
        public int IntBoundaries(int number, int min, int max)
        {
            // if the number is below the bounderies of the min, then it will return the max boundary value, reseting the arrow to the top of the menu, allowing quick access
            if (number < min)
            {
                return max;
            }

            // if the number is above the bounderies of the max, then it will return the min boundary value, reseting the arrow to the bottom of the menu, allowing quick access
            else if (number > max)
            {
                return min;
            }

            // If the number is between the boundaries, then it will return that number as normal
            else
            {
                return number;
            }
        }
    }
}