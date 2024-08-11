using BMS.Application.Services.AuthorsService;
using BMS.Application.Services.AuthorsService.Abstractions;
using BMS.Application.Services.BooksService;
using BMS.Application.Services.BooksService.Abstractions;
using BMS.Application.Services.CategoryService;
using BMS.Application.Services.CategoryService.Abstractions;
using BMS.Application.Services.PublishersService;
using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Data.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BMS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPublisherService, PublisherService>();

        return services;
    }
}