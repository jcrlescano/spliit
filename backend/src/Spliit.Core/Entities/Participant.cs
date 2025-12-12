using Spliit.Core.Common;

namespace Spliit.Core.Entities;

public class Participant : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public ICollection<Expense> ExpensesPaidBy { get; set; } = new List<Expense>();
    public ICollection<ExpensePaidFor> ExpensesPaidFor { get; set; } = new List<ExpensePaidFor>();
}
