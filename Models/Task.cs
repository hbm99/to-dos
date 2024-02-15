namespace todos.Models;

/// <summary>
/// Task entity.
/// </summary>
public class Task : IEntity
{
    /// <summary>
    /// Task identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Task description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Task status.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Task creation date.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Task completion date.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
}
