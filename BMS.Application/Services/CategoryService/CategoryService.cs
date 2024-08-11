using BMS.Application.Services.CategoryService.Abstractions;
using BMS.Application.Services.CategoryService.DTOs;
using BMS.Application.Services.CategoryService.Models;
using BMS.Data.Models;
using BMS.Data.Persistence.Contexts;
using BMS.Data.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BMS.Application.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly IRepository<BookCategory, MsSqlDbContext> _repository;

    public CategoryService(IRepository<BookCategory, MsSqlDbContext> repository)
    {
        _repository = repository;
    }

    public CategoryListModel GetCategoryList()
    {
        var categories = _repository.GetList();

        var categoriesDto = categories.Select(b => new CategoryDto(b.Id, b.CreatedAt, b.UpdatedAt, b.Name));

        var categoryListModel = new CategoryListModel()
        {
            Items = categoriesDto.ToList()
        };

        return categoryListModel;
    }


    public CategoryDto GetCategoryById(int categoryId)
    {
        BookCategory category = _repository.Get(b => b.Id == categoryId);

        if (category == null)
        {
            throw new Exception();
        }

        return new CategoryDto(category.Id, category.CreatedAt, category.UpdatedAt, category.Name);
    }

    public CategoryCreatedDto CreateCategory(BookCategory category)
    {
        BookCategory createdCategory = _repository.Add(category);

        return new CategoryCreatedDto(createdCategory.Id, createdCategory.CreatedAt, createdCategory.UpdatedAt,
            createdCategory.Name);
    }

    public CategoryUpdatedDto UpdateCategory(BookCategory category)
    {
        BookCategory categoryToUpdate = _repository.Get(b => b.Id == category.Id);

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.UpdatedAt = DateTime.UtcNow;

        _repository.Update(categoryToUpdate);

        return new CategoryUpdatedDto(category.Id, category.CreatedAt, category.UpdatedAt, category.Name);
    }

    public void DeleteCategory(BookCategory category)
    {
        BookCategory deletedCategory = _repository.Get(b => b.Id == category.Id);

        _repository.Delete(deletedCategory);
    }
}