using BMS.Application.Services.CategoryService.Abstractions;
using BMS.Application.Services.CategoryService.DTOs;
using BMS.Domain.Models;

namespace BMS.Application.Services.CategoryService;

public class CategoryService: ICategoryService
{
    public CategoryListModel GetCategoryList()
    {
        throw new NotImplementedException();
    }

    public CategoryDto GetCategoryById(BookCategory category)
    {
        throw new NotImplementedException();
    }

    public CategoryCreatedDto CreateCategory(BookCategory category)
    {
        throw new NotImplementedException();
    }

    public CategoryUpdatedDto UpdateCategory(BookCategory category)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(BookCategory category)
    {
        throw new NotImplementedException();
    }
}