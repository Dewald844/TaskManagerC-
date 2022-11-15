namespace Task_Manager;

public class User
{
   public string  FirstName;
   public string  LastName;
   public string UserName;
   private string _Password;
   private bool   _IsAdmin;

   public User(string fName, string lName, string password, bool isAdmin)
   {
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
         user.FirstName + "," +
         user.LastName  + "," +
         user.UserName + "," +
         user._Password + "," +
         isAdmin + "\n";
   }

   public bool IsAdmin(User user)
   {
      return user._IsAdmin;
   }

}

public class UserFunctions
{
   public void CreateNewUserFromCommandLine(IO_Helper helper)
   {
      Console.Write("\nEnter user first name :" );
      var userFirstName = Console.ReadLine();
      Console.Write("\nEnter user last name :" );
      var userLastName = Console.ReadLine();
      Console.Write("\nEnter user password :" );
      var userPassword = Console.ReadLine();
      Console.Write("\nGrant user admin access? y/n :" );
      var adminAccess = Console.ReadLine();

      var userAdmin = adminAccess == "y" ? true : false;

      Console.Write("\nCreating new user");
      Console.Write("\nFirst name : " + userFirstName);
      Console.Write("\nLast name : " + userLastName);
      Console.Write("\n Admin access : " + adminAccess);

      Console.Write("Proceed ? y/n :");
      var proceed = Console.ReadLine();

      if (proceed == "y")
      {
         var newUser = new User(userFirstName, userLastName, userPassword, userAdmin);
         var newUserString = newUser.UserWritable(newUser);
         helper.AppendNewUser(newUserString);
      }
   }

   public User CheckUserForSignIn(List<User> userL,  string userName, string password)
   {
      foreach (var user in userL)
      {
         if (user.UserName == userName)
         {
            if (user.CheckPassword(user, password))
            {
               return user;
            }
         }
      }

   }
}
