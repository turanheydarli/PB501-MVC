namespace BMS.Application.Services.CategoryService.DTOs;

public record CategoryUpdatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);