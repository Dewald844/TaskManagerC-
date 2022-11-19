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
      var file =  File.Create(UserFilePath);
      file.Close();
   }

   public void CreateTaskFile()
   {
      var file = File.Create(TaskFilePath);
      file.Close();
   }

   public List<User> ReadUsers()
   {
      string userFileString = File.ReadAllText(UserFilePath);
      string[] userStringArray =  userFileString.Split("\n");
      List<User> userArray = new List<User>();

      for (int i = 0; i < userStringArray.Length - 1; i++)
      {
         string[] userLine = userStringArray[i].Split(",");
         bool isAdmin = userLine[5] == "true";
         User user = new User(Int32.Parse(userLine[0]), userLine[1], userLine[2], userLine[3] , isAdmin);
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