using Spliit.Core.Common;
using Spliit.Core.Enums;

namespace Spliit.Core.Entities;

public class Activity : BaseEntity
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public ActivityType ActivityType { get; set; }
    public Guid? ParticipantId { get; set; }
    public Guid? ExpenseId { get; set; }
    public string? Data { get; set; }
}
