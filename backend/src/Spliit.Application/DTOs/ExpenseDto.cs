using Spliit.Core.Enums;

namespace Spliit.Application.DTOs;

public record ExpenseDto(
    Guid Id,
    Guid GroupId,
    DateTime ExpenseDate,
    string Title,
    int CategoryId,
    int Amount,
    Guid PaidById,
    bool IsReimbursement,
    SplitMode SplitMode,
    string? Notes,
    DateTime CreatedAt
);

public record CreateExpenseDto(
    Guid GroupId,
    DateTime ExpenseDate,
    string Title,
    int CategoryId,
    int Amount,
    Guid PaidById,
    bool IsReimbursement,
    SplitMode SplitMode,
    string? Notes,
    List<ExpensePaidForDto> PaidFor
);

public record UpdateExpenseDto(
    DateTime ExpenseDate,
    string Title,
    int CategoryId,
    int Amount,
    Guid PaidById,
    bool IsReimbursement,
    SplitMode SplitMode,
    string? Notes,
    List<ExpensePaidForDto> PaidFor
);

public record ExpensePaidForDto(
    Guid ParticipantId,
    int Shares
);
