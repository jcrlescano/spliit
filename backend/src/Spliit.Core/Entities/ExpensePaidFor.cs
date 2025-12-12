namespace Spliit.Core.Entities;

public class ExpensePaidFor
{
    public Guid ExpenseId { get; set; }
    public Expense Expense { get; set; } = null!;
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; } = null!;
    public int Shares { get; set; } = 1;
}
