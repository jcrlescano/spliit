using Spliit.Core.Common;

namespace Spliit.Core.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Information { get; set; }
    public string Currency { get; set; } = "$";
    public string? CurrencyCode { get; set; }
    public ICollection<Participant> Participants { get; set; } = new List<Participant>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
