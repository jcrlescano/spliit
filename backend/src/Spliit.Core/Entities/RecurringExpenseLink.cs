using Spliit.Core.Common;

namespace Spliit.Core.Entities;

public class RecurringExpenseLink : BaseEntity
{
    public Guid GroupId { get; set; }
    public Guid CurrentFrameExpenseId { get; set; }
    public Expense CurrentFrameExpense { get; set; } = null!;
    public DateTime? NextExpenseCreatedAt { get; set; }
    public DateTime NextExpenseDate { get; set; }
}
