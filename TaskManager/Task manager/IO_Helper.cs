namespace Task_Manager;

using System.IO;

public class IO_Helper
{

   public string UserFilePath = "../../../../Files/user.txt";
   public string TaskFilePath = "../../../../Files/task.txt";

   public bool CheckUserFile()
   {
      return File.Exists(UserFilePath);
   }

   public bool CheckTaskFile()
   {
      return File.Exists(TaskFilePath);
   }

   public void CreateUserFile()
   {
      File.Create(UserFilePath);
   }

   public void CreateTaskFile()
   {
      File.Create(TaskFilePath);
   }

   public List<User> ReadUsers()
   {
      string userFileString = File.ReadAllText(UserFilePath);
      string[] userStringArray =  userFileString.Split("\n");
      List<User> userArray = new List<User>();

      for (int i = 0; i < userStringArray.Length - 1; i++)
      {
         string[] userLine = userStringArray[i].Split(",");
         bool isAdmin = userLine[4] == "true" ? true : false;
         User user = new User(userLine[0], userLine[1], userLine[2], isAdmin);
         userArray.Add(user);
      }

      return userArray;
   }

   public string ReadTasks()
   {
      return File.ReadAllText(TaskFilePath);
   }

   public void AppendNewUser (string userWritable)
   {
      File.AppendAllText(UserFilePath, userWritable);
   }
}