namespace Task_Manager;

class  Task
{
   public User Assignee;
   public string Title;
   public string Description;
   public DateTime DueDate;
   public bool Complete;
   public bool OverDue;

   public Task(User assignee, string title, string description, DateTime dueDate)
   {
      Assignee    = assignee;
      Title       = title;
      Description = description;
      DueDate     = dueDate;
      Complete    = false;
      OverDue     = false;
   }

   public Task CheckOverdue(Task task)
   {
      task.OverDue = task.DueDate < DateTime.Now;
      return task;
   }

}