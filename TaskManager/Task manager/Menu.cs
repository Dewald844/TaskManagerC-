namespace Task_Manager
{
   public abstract class Menu
   {
      public static int Selection(User user)
      {
         if (user.IsAdmin(user))
         {
            Console.Write("\n Please choose a function to execute");
            Console.Write("\n 1 : Create new user");
            Console.Write("\n 2 : Create new task");
            Console.Write("\n 3 : Show all incomplete tasks");
            Console.Write("\n 4 : Show all overdue tasks");
            Console.Write("\n 0 : Exit program");
         }
         else
         {
            Console.Write("\n Please choose a function to execute");
            Console.Write("\n 1 : Show your incomplete tasks");
            Console.Write("\n 2 : Extent tasks due date");
            Console.Write("\n 3 : Mark task complete");
            Console.Write("\n 0 : Exit program");
         }

         Console.Write("\n Selection : ");
         var input = Console.ReadLine();

         if (input == null)
         {
            return Selection(user);
         }

         return Int32.Parse(input) ;
      }
   }
}