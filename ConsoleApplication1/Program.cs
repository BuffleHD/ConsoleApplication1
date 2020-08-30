using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{

    internal class Program
    {
        public static String token;
        public static List<Bot> bots = new List<Bot>();
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Do you want to create new Bots(1) or use them(2)? Type: 1/2");
        int selection =  Convert.ToInt32(Console.ReadLine());
        if (selection == 1)
        {
            
            Console.WriteLine("Please enter the Token of your MCHost-Account");
            token = Console.ReadLine();
                
         /*   Console.WriteLine("Please enter the Email of your MCHost-Account");
            String email = Console.ReadLine();
            Console.WriteLine("Please enter the Password of your MCHost-Account");
            String password = Console.ReadLine(); 
            token = McHostLogger.setupSession("", "");
            */
            if (token == "failed")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to authentificate. ");
                Console.ResetColor();
            }
            Console.WriteLine("How many Bots do you want to create?");
            int botcount =  Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Creating Bots...");
            Console.WriteLine("Redirecting to Botgenerator...");
        }
        else if (selection == 2)
        {
            
        }
        }
    }
}