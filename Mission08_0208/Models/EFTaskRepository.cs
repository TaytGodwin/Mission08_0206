using SQLitePCL;

namespace Mission8_0206.Models;


public class EFTaskRepository : ITaskRepository
{
    // Creates local variable to store database connection
    private HabitsContext _context;
    
    public EFTaskRepository(HabitsContext temp)
    {
        _context = temp;
    }
    
    // Gets the correct information from each table
    public List<Task> Tasks => _context.Tasks.ToList();
    public List<Category> Categories => _context.Categories.ToList();
    
    // Add task route connection for controller
    public void AddTask(Task task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }
    
    // Edit task route connection for controller
    public void EditTask(Task task)
    {
        _context.Update(task);
        _context.SaveChanges();
    }
    
    // Delete task route for the controller
    public void Delete(Task task)
    {
        _context.Remove(task);
        _context.SaveChanges();
    }
}