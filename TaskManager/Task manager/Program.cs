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

            while (menuItem != 0)
            {
               if (loggedInUser.IsAdmin(loggedInUser))
               {
                  switch (menuItem)
                  {
                     case 1:
                        UserFunctions.CreateNewUser(helper);
                        break;
                     case 2:
                        TaskFunctions.CreateNewTask(helper);
                        break;
                     case 3:
                        TaskFunctions.ShowAllIncompleteTasks(helper);
                        break;
                     case 4:
                        TaskFunctions.ShowAllOverDueTasks(helper);
                        break;
                  }
               }
               else
               {
                  switch (menuItem)
                  {
                     case 1:
                        TaskFunctions.ShowAllIncompleteTasksForUser(helper, loggedInUser.Id);
                        break;
                     case 2:
                        TaskFunctions.ExtendTaskDueDate(helper, loggedInUser.Id);
                        break;
                     case 3:
                        TaskFunctions.MarkTaskAsComplete(helper, loggedInUser.Id);
                        break;
                  }
               }

               menuItem = Menu.Selection(loggedInUser);

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