using System.Security.Cryptography;

namespace Task_Manager;

public class User
{
   public int Id;
   public string  FirstName;
   public string  LastName;
   public string UserName;
   private string _Password;
   private bool   _IsAdmin;

   public User(int id, string fName, string lName, string password, bool isAdmin)
   {
      Id = id;
      FirstName = fName;
      LastName  = lName;
      UserName = fName + "_" + lName;
      _Password = password;
      _IsAdmin  = isAdmin;
   }

   public bool CheckPassword(User user, string password)
   {
      return user._Password == password;
   }

   public string UserWritable(User user)
   {
      var isAdmin = user._IsAdmin ? "true" : "false";
      return
         user.Id        + "|" +
         user.FirstName + "|" +
         user.LastName  + "|" +
         user.UserName  + "|" +
         user._Password + "|" +
         isAdmin + "\n";
   }

   public bool IsAdmin(User user)
   {
      return user._IsAdmin;
   }

}

public abstract class UserFunctions
{
   public static void CreateNewUser(IO_Helper helper)
   {

      var nextId = helper.ReadUsers().Count + 1;

      Console.Write("\nEnter user first name :" );
      var userFirstName = Console.ReadLine();
      Console.Write("\nEnter user last name :" );
      var userLastName = Console.ReadLine();
      Console.Write("\nEnter user password :" );
      var userPassword = Console.ReadLine();
      Console.Write("\nGrant user admin access? y/n :" );
      var adminAccess = Console.ReadLine();

      var userAdmin = adminAccess == "y";

      Console.Write("\nCreating new user");
      Console.Write("\nFirst name : " + userFirstName);
      Console.Write("\nLast name : " + userLastName);
      Console.Write("\nUser name : " + userFirstName + "_" + userLastName);
      Console.Write("\nAdmin access : " + adminAccess);

      var newUser = new User(nextId, userFirstName, userLastName, userPassword, userAdmin);
      var newUserString = newUser.UserWritable(newUser);
      helper.AppendNewUser(newUserString);

   }

   public static User LogInUser (IO_Helper helper)
   {
      List<User> userL = helper.ReadUsers();

      User? maybeUser = null;

      Console.Write("\nPlease enter your credentials to log in");
      Console.Write("\nUsername : ");
      var usernameInput = Console.ReadLine();

      foreach (var user in userL)
      {
         if (user.UserName == usernameInput)
         {
            maybeUser = user;
         }
      }

      if (maybeUser == null)
      {
         Console.Write("\nUser name not found please try again.");
         LogInUser(helper);
      }
      else
      {
         Console.Write("\nPassword :");
         var password = Console.ReadLine();

         if (password != null && maybeUser.CheckPassword(maybeUser, password)){ }
         else
         {
            Console.Write("Incorrect password please try again");
         }
      }

      return maybeUser;
   }
}
