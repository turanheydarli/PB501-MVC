namespace BMS.Application.Services.PublishersService.DTOs;

public record PublisherDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);

public record PublisherUpdatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);

public record PublisherCreatedDto(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name);