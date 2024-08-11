namespace BMS.Application.Services.CategoryService.DTOs;

public record CategoryCreatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);