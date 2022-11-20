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
      string[] userStringArray = File.ReadAllText(UserFilePath).Split("\n");
      List<User> userArray = new List<User>();

      for (int i = 0; i < userStringArray.Length - 1; i++)
      {
         string[] userLine = userStringArray[i].Split("|");
         bool isAdmin = userLine[5] == "true";
         User user = new User(
            Int32.Parse(userLine[0])
            , userLine[1]
            , userLine[2]
            , userLine[4]
            , isAdmin);
         userArray.Add(user);
      }

      return userArray;
   }

   public List<Task> ReadTasks()
   {
      string[] taskStringArray =  File.ReadAllText(TaskFilePath).Split("\n");

      Console.Write(taskStringArray.Length + "\n");
      List<Task> taskArray = new List<Task>();
      if (taskStringArray.Length < 2 )
      {

      }
      else
      {
         foreach (var taskString in taskStringArray)
         {
            string[] taskLine = taskString.Split("|");
            bool complete = taskLine[5] == "true";
            bool overDue = taskLine[6] == "true";
            Task task = new Task(
               Int32.Parse(taskLine[0])
               , Int32.Parse(taskLine[1])
               , taskLine[2]
               , taskLine[3]
               , DateTime.Parse(taskLine[4])
               , complete
               , overDue);

            taskArray.Add(task);
         }
      }

      return taskArray;
   }

   public void AppendNewUser (string userWritable)
   {
      File.AppendAllText(UserFilePath, userWritable);
   }

   public void AppendNewTask(string taskWritable)
   {
      File.AppendAllText(TaskFilePath, taskWritable);
   }
}