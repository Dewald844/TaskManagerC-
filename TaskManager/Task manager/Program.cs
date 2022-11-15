// See https://aka.ms/new-console-template for more information

using System;
using Task_Manager;

namespace Task_Manager
{

   class Program
   {
      static void Main(string[] args)
      {

         IO_Helper helper = new IO_Helper();

         Console.Write("Welcome to task manager C#\n");
         Console.Write("Checking if needed files exist ...\n");

         if (helper.CheckUserFile() && helper.CheckTaskFile())
         {
            Console.Write("User and task file exists \n");

            var userL = helper.ReadUsers();

            foreach (var user in userL)
            {
               Console.Write(user.FirstName +"\n");
            }

            Console.Write("\nCreate new user? y/n :" );
            string createUser = Console.ReadLine();

            if (createUser == "y")
            {
               new UserFunctions().CreateNewUserFromCommandLine(helper);
            }

         }
         else
         {
            Console.Write("User and task file not found creating file...\n");
            helper.CreateUserFile();
            helper.CreateTaskFile();
         }

      }
   }
}