using Spliit.Core.Common;
using Spliit.Core.Enums;

namespace Spliit.Core.Entities;

public class Expense : BaseEntity
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public DateTime ExpenseDate { get; set; } = DateTime.UtcNow.Date;
    public string Title { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int Amount { get; set; }
    public int? OriginalAmount { get; set; }
    public string? OriginalCurrency { get; set; }
    public decimal? ConversionRate { get; set; }
    public Guid PaidById { get; set; }
    public Participant PaidBy { get; set; } = null!;
    public ICollection<ExpensePaidFor> PaidFor { get; set; } = new List<ExpensePaidFor>();
    public bool IsReimbursement { get; set; }
    public SplitMode SplitMode { get; set; } = SplitMode.Evenly;
    public ICollection<ExpenseDocument> Documents { get; set; } = new List<ExpenseDocument>();
    public string? Notes { get; set; }
    public RecurrenceRule RecurrenceRule { get; set; } = RecurrenceRule.None;
    public RecurringExpenseLink? RecurringExpenseLink { get; set; }
    public Guid? RecurringExpenseLinkId { get; set; }
}
