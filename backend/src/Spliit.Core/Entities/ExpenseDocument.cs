using Spliit.Core.Common;

namespace Spliit.Core.Entities;

public class ExpenseDocument : BaseEntity
{
    public string Url { get; set; } = string.Empty;
    public int Width { get; set; }
    public int Height { get; set; }
    public Guid? ExpenseId { get; set; }
    public Expense? Expense { get; set; }
}
