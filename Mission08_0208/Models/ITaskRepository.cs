using SQLitePCL;

namespace Mission8_0206.Models;

public interface ITaskRepository
{
    // Access the appropriate data
    List<Task> Tasks { get; }
    List<Category> Categories { get; }
    
    // Make it possible to use the add, edit, and delete
    void AddTask(Task task);
    void EditTask(Task task);
    void Delete(Task task);
    
}