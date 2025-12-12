using Microsoft.AspNetCore.Mvc;
using Spliit.Application.DTOs;
using Spliit.Application.Interfaces;

namespace Spliit.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetAll(CancellationToken cancellationToken)
    {
        var groups = await _groupService.GetAllAsync(cancellationToken);
        return Ok(groups);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroupDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var group = await _groupService.GetByIdAsync(id, cancellationToken);
        return group == null ? NotFound() : Ok(group);
    }

    [HttpPost]
    public async Task<ActionResult<GroupDto>> Create(CreateGroupDto dto, CancellationToken cancellationToken)
    {
        var group = await _groupService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GroupDto>> Update(Guid id, UpdateGroupDto dto, CancellationToken cancellationToken)
    {
        var group = await _groupService.UpdateAsync(id, dto, cancellationToken);
        return group == null ? NotFound() : Ok(group);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _groupService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
