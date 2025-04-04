using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;


namespace CyberSecurityAwarenessAssistantBot
{
    public class CyberBotInteraction
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        ArrayList replies = new ArrayList();
        ArrayList keywords = new ArrayList();
        string userInput;

        public CyberBotInteraction()
        {

            //get the full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            // then replace the bin\\Debug
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //then combine the project full path and the image name
            //format
            string full_path = Path.Combine(new_path_project, "images.png");

            //then start working on the logo
            //with the Ascii
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(90, 40));

            //for loop,for inner and the outer
            //nested
            for (int height = 0; height < image.Height; height++)
            {
                //then now work on the width
                for (int width = 0; width < image.Width; width++)
                {
                    //now lets work on the Ascii
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    //now make user of the char
                    char ascii_design = color < 200 ? '.' : color < 150 ? '*' : color < 100 ? '+' : color > 50 ? '*' : '0';
                    Console.Write(ascii_design);//output the design

                }// end of the for loop inner
                Console.WriteLine();//skip the line


            }//end of for Loop outer
            //Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                          Welcome To CyberSecurityAwenessBot!!! ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");



            bool isValid = false;
            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CyberBot :->");
                Console.ResetColor();
                TypewriteLine(" Please enter your name? (\"only letters,max 20 characters\"):");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" UserName :->");
                Console.ResetColor();
                user_name = Console.ReadLine();

                if (IsValidUsername(user_name))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" CyberBot :->");
                    Console.ResetColor();
                    TypewriteLine($" {user_name} is Valid username!");
                    isValid = true;

                }
                else if (string.IsNullOrWhiteSpace(user_name))
                {
                    user_name = "Guest";
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" CyberBot :->");
                    Console.ResetColor();
                    TypewriteLine(" I will call you Guest since no name was provided.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" CyberBot :->");
                    Console.ResetColor();
                    TypewriteLine("Invalid username.Please try to insert the correct username!!!");


                }
            }


            //calling the method that have questions and answers
            InitializeRepliesAndKeywords();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" CyberBot :->");
            Console.ResetColor();
            TypewriteLine($" Hey!! {user_name}, how can I assist you today?");

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {user_name}:->");
                Console.ResetColor();
                userInput = Console.ReadLine();

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                    Thank you for using Cybersecurity Bot. Stay safe online!!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                    Console.ResetColor();
                    break;
                }
                else if (userInput == "how are you")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" CyberBot:->");
                    Console.ResetColor();
                    TypewriteLine("I'm good but i will be grate after i help you ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {user_name}:->");
                    Console.ResetColor();
                    userInput = Console.ReadLine();

                }


                ProcessUserInput(userInput);
            }
        }//end of constructor

        static bool IsValidUsername(string user_name)
        {
            //Regex to allow  only letters and limit length to 20  characters
            string pattern = @"^[a-zA-Z]{1,20}$";

            return

                Regex.IsMatch(user_name, pattern);

        }

        private void InitializeRepliesAndKeywords()
        {
            replies.Add("Password should be strong and unique.Use a mix of letters, numbers, and symbols.");
            replies.Add("Phishing emails often ask for sensitive information. Always verify the sender.\"");
            replies.Add("Attacking phones often involves phishing.");
            replies.Add("Safe browsing includes avoiding suspicious links and ensuring websites use HTTPS.");
            replies.Add("Install antivirus software and keep it updated to protect against malware.");
            replies.Add("My purpose is to help you stay safe online");
            replies.Add("you can ask about \n -Phishing emails\n -how are you \n -whats your purpose\n -safe passwords practices\n -To recognise suspicious links");

            keywords.Add("password");
            keywords.Add("phishing");
            keywords.Add("phone");
            keywords.Add("browse");
            keywords.Add("malware");
            keywords.Add("purpose");
            keywords.Add("ask");
        }

        private void ProcessUserInput(string input)
        {
            string[] words = input.Split(' ');
            bool found = false;
            string response = "";

            foreach (string word in words)
            {
                for (int i = 0; i < keywords.Count; i++)
                {
                    if (word.Equals(keywords[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        response += replies[i] + "\n";
                        found = true;
                    }
                }
            }

            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CyberBot:->");
                Console.ResetColor();
                TypewriteLine($" {response}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CyberBot:->");
                Console.ResetColor();
                TypewriteLine("Anything else I can assist you with?");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CyberBot:->");
                Console.ResetColor();
                TypewriteLine("I didn't quite understand that could you rephrase ?");

            }
        }

        //method to make the text appear as if it is being typed in real time
        static void TypewriteLine(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(50); // Adjust the speed by changing the sleep time
            }
            Console.WriteLine();
        }


    }
}