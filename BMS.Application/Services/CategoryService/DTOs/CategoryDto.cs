namespace BMS.Application.Services.CategoryService.DTOs;

public record CategoryDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);
public record CategoryCreatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);
public record CategoryUpdatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);
