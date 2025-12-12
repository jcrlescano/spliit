using Spliit.Application.DTOs;
using Spliit.Application.Interfaces;
using Spliit.Core.Entities;
using Spliit.Core.Interfaces;

namespace Spliit.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ExpenseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var expense = await _expenseRepository.GetByIdAsync(id, cancellationToken);
        return expense == null ? null : MapToDto(expense);
    }

    public async Task<IEnumerable<ExpenseDto>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        var expenses = await _expenseRepository.GetByGroupIdAsync(groupId, cancellationToken);
        return expenses.Select(MapToDto);
    }

    public async Task<ExpenseDto> CreateAsync(CreateExpenseDto dto, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var expense = new Expense
            {
                GroupId = dto.GroupId,
                ExpenseDate = dto.ExpenseDate,
                Title = dto.Title,
                CategoryId = dto.CategoryId,
                Amount = dto.Amount,
                PaidById = dto.PaidById,
                IsReimbursement = dto.IsReimbursement,
                SplitMode = dto.SplitMode,
                Notes = dto.Notes
            };

            await _expenseRepository.AddAsync(expense, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return MapToDto(expense);
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task<ExpenseDto?> UpdateAsync(Guid id, UpdateExpenseDto dto, CancellationToken cancellationToken = default)
    {
        var expense = await _expenseRepository.GetByIdAsync(id, cancellationToken);
        if (expense == null) return null;

        expense.ExpenseDate = dto.ExpenseDate;
        expense.Title = dto.Title;
        expense.CategoryId = dto.CategoryId;
        expense.Amount = dto.Amount;
        expense.PaidById = dto.PaidById;
        expense.IsReimbursement = dto.IsReimbursement;
        expense.SplitMode = dto.SplitMode;
        expense.Notes = dto.Notes;
        expense.UpdatedAt = DateTime.UtcNow;

        _expenseRepository.Update(expense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(expense);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var expense = await _expenseRepository.GetByIdAsync(id, cancellationToken);
        if (expense == null) return false;

        _expenseRepository.Delete(expense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static ExpenseDto MapToDto(Expense expense) => new(
        expense.Id,
        expense.GroupId,
        expense.ExpenseDate,
        expense.Title,
        expense.CategoryId,
        expense.Amount,
        expense.PaidById,
        expense.IsReimbursement,
        expense.SplitMode,
        expense.Notes,
        expense.CreatedAt
    );
}
