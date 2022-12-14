namespace Task_Manager;

using System.IO;

public class IO_Helper
{

   private string UserFilePath = "../../../../Files/user.txt";
   private string TaskFilePath = "../../../../Files/task.txt";

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
      var userStringArray = File.ReadAllText(UserFilePath).Split("\n");
      var userArray = new List<User>();

      for (int i = 0; i < userStringArray.Length - 1; i++)
      {
         var userLine = userStringArray[i].Split("|");
         var isAdmin = userLine[5] == "true";
         var user = new User(
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
      var taskStringArray =  File.ReadAllText(TaskFilePath).Split("\n");
      var taskArray = new List<Task>();

      if (taskStringArray.Length < 2 )
      { }
      else
      {
         for (int i = 0; i < taskStringArray.Length - 1; i++)
         {
            var taskLine = taskStringArray[i].Split("|");
            var complete = taskLine[5] == "True";
            var overDue = taskLine[6] == "True";
            var task = new Task (
               Int32.Parse(taskLine[0])
               , Int32.Parse(taskLine[1])
               , taskLine[2]
               , taskLine[3]
               , DateTime.Parse(taskLine[4])
               , complete
               , overDue);

            taskArray.Add(task.CheckOverdue(task));
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

   public void RewriteTaskFile(List<Task> taskL)
   {
      File.Delete(TaskFilePath);

      var newFile = File.Create(TaskFilePath);

      newFile.Close();

      foreach (var task in taskL)
      {
         AppendNewTask(task.TaskWriteable(task));
      }
   }
}