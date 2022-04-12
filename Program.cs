using System;

namespace challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Website link for challenge
            //https://open.kattis.com/problems/encodedmessage

            //Variables for the number of test cases
            int test_cases_int = 0;
            int case_completed = 0;

            //Variables for the encoded message
            String encoded_message = "";
            bool upper_and_lower_check = false;

            // Label for number of cases
            Console.Write("Number of cases to process: ");

            // Read the lines of code and convert into integer for number of cases
            test_cases_int = Int32.Parse(Console.ReadLine());

            //Check if the entered test case is 100 at most and a positive integer
            if (test_cases_int >= 100 || test_cases_int < 0)
            {
                Console.WriteLine("Should be positive and/or less than 100");
                Environment.Exit(0);
            }

            //enter into a do loop while number of cases are not processed
            do
            {

                //Empty space
                Console.WriteLine();

                //Label for input
                Console.Write("Input: ");
                //Get the encoded message from the user 
                encoded_message = Console.ReadLine();

                //Check if the letter is upper and lower cases only
                for (int i = 0; i < encoded_message.Length; i++)
                {
                    if ((char.IsUpper(encoded_message[i])) || (char.IsLower(encoded_message[i])))
                    {
                        upper_and_lower_check = true;
                    }
                }

                //If it does not have upper and lower cases letters break the loop
                if (upper_and_lower_check == false)
                {
                    Console.WriteLine("The message should consist upper and lower letters");
                    Environment.Exit(0);
                }

                //Check if the message length is between 1 to 10,000 characters
                if (encoded_message.Length >= 10000 || encoded_message.Length <= 1)
                {
                    Console.WriteLine("The length of the message should be between 10,000 and 1");
                    Environment.Exit(0);
                }

                //Check if the message is a square number
                double division = Math.Sqrt(encoded_message.Length);
                if (division % 1 != 0)
                {
                    Console.WriteLine("The length of the message should be a square");
                    Environment.Exit(0);
                }

                //Create the 2D array

                //Columns and rows should be equal to square
                int number_of_rows = Convert.ToInt32(Math.Sqrt(encoded_message.Length));
                int number_of_col = Convert.ToInt32(Math.Sqrt(encoded_message.Length));

                //Create the array for storage
                char[,] the_message = new char[number_of_rows, number_of_col];

                //Initialize the 2d array for storage
                for (int a = 0; a < number_of_rows; a++)
                {
                    for (int b = 0; b < number_of_col; b++)
                    {
                        the_message[a, b] = encoded_message[b + (a * number_of_col)];
                    }
                }

                //Create the array for rotation;
                char[,] rotated_message = new char[number_of_rows, number_of_col];

                //rotated_message[0, 0] = the_message[0, 1];
                //rotated_message[0, 1] = the_message[1, 1];

                //Initialize the array while rotating the array
                for (int k = 0; k < number_of_rows; k++)
                {
                    for (int l = number_of_col - 1; l >= 0; l--)
                    {
                        rotated_message[k, l] = the_message[l, k];
                    }
                }

                //Output label
                Console.Write("Output: ");

                //Reverse the rotated array again and give the result
                for (int n = number_of_rows - 1; n >= 0; n--)
                {
                    for (int m = 0; m < number_of_col; m++)
                    {
                        Console.Write(rotated_message[n, m]);
                    }
                }
                Console.WriteLine();
                //Increment case number
                case_completed++;
            } while (case_completed < test_cases_int);

        }
    }
}
