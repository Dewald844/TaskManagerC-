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

            var loggedInUser = UserFunctions.LogInUser(helper);
            Console.Write("\n Welcome " + loggedInUser.UserName);

            var menuItem = Menu.Selection(loggedInUser);

            if (loggedInUser.IsAdmin(loggedInUser))
            {
               if (menuItem == 1)
               {
                  UserFunctions.CreateNewUser(helper);
               }
            }
         }
         else
         {
            Console.Write("\nUser and task file not found creating file...");
            helper.CreateUserFile();
            helper.CreateTaskFile();
            Console.Write("\nPlease create an admin user");
            UserFunctions.CreateNewUser(helper);
         }
      }
   }
}