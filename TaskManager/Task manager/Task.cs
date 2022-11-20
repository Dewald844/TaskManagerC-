using System.Security.Cryptography;

namespace Task_Manager;

public class Task
{
   public int Id;
   public int UserId ;
   public string Title;
   public string Description;
   public DateTime DueDate;
   public bool Complete;
   public bool OverDue;

   public Task(int taskId, int assignee, string title, string description, DateTime dueDate, bool complete, bool overDue)
   {
      Id          = taskId;
      UserId      = assignee;
      Title       = title;
      Description = description;
      DueDate     = dueDate;
      Complete    = complete;
      OverDue     = overDue;
   }

   public Task CheckOverdue(Task task)
   {
      task.OverDue = task.DueDate < DateTime.Now;
      return task;
   }

   public string TaskWriteable(Task task)
   {
      return
         task.Id          + "|" +
         task.UserId      + "|" +
         task.Title       + "|" +
         task.Description + "|" +
         task.DueDate     + "|" +
         task.Complete    + "|" +
         task.OverDue     + "\n";
   }
}

public abstract class TaskFunctions
{
   public static void CreateNewTask(IO_Helper helper)
   {
      var nextId = helper.ReadTasks().Count + 1;
      var users = helper.ReadUsers();

      Console.Write("Please select user to assign task to.\n");
      foreach (var user in users)
      {
         Console.Write(user.Id + " : " + user.FirstName + " " + user.LastName + "\n");
      }

      var userId = Int32.Parse(Console.ReadLine());

      Console.Write("\nEnter task title :" );
      var taskTitle = Console.ReadLine();
      Console.Write("\nEnter task description :" );
      var description = Console.ReadLine();
      Console.Write("\nEnter task due date (mm/dd/yyyy) :" );
      var dueDate = Console.ReadLine();

      var newTask = new Task(nextId, userId, taskTitle, description, DateTime.Parse(dueDate), false, false);
      var newTaskString = newTask.TaskWriteable(newTask);

      helper.AppendNewTask(newTaskString);
   }

   public static void ShowAllIncompleteTasks(IO_Helper helper)
   {
      var taskL = helper.ReadTasks();

      foreach (var task in taskL.Where(task => !task.Complete)) // linq expression
      {
         Console.Write("\n" + task.Id +  " " + task.Title + " " + task.UserId + " " + task.DueDate);
      }
   }

   public static void ShowAllOverDueTasks(IO_Helper helper)
   {
      var taskL = helper.ReadTasks();

      foreach (var task in taskL.Where(task => task.OverDue))
      {
         Console.Write(task.Title + " " + task.UserId + " " + task.DueDate);
      }
   }

   public static void MarkTaskAsComplete(IO_Helper helper)
   {

      ShowAllIncompleteTasks(helper);

      Console.Write("\n Select task to complete");
      var taskId = Int32.Parse(Console.ReadLine());
   }
}