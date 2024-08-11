using BMS.Application.Services.CategoryService.DTOs;
using BMS.Application.Services.CategoryService.Models;
using BMS.Data.Models;

namespace BMS.Application.Services.CategoryService.Abstractions;

public interface ICategoryService
{
    CategoryListModel GetCategoryList();
    CategoryDto GetCategoryById(int id);
    CategoryCreatedDto CreateCategory(BookCategory category);
    CategoryUpdatedDto UpdateCategory(BookCategory category);
    void DeleteCategory(BookCategory category);
}