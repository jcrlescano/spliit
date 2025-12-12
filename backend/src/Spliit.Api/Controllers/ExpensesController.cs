using Microsoft.AspNetCore.Mvc;
using Spliit.Application.DTOs;
using Spliit.Application.Interfaces;

namespace Spliit.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ExpenseDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var expense = await _expenseService.GetByIdAsync(id, cancellationToken);
        return expense == null ? NotFound() : Ok(expense);
    }

    [HttpGet("group/{groupId:guid}")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetByGroupId(Guid groupId, CancellationToken cancellationToken)
    {
        var expenses = await _expenseService.GetByGroupIdAsync(groupId, cancellationToken);
        return Ok(expenses);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> Create(CreateExpenseDto dto, CancellationToken cancellationToken)
    {
        var expense = await _expenseService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ExpenseDto>> Update(Guid id, UpdateExpenseDto dto, CancellationToken cancellationToken)
    {
        var expense = await _expenseService.UpdateAsync(id, dto, cancellationToken);
        return expense == null ? NotFound() : Ok(expense);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _expenseService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
