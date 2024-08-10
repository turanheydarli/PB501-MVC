using BMS.Application.Services.CategoryService.DTOs;
using BMS.Domain.Models;

namespace BMS.Application.Services.CategoryService.Abstractions;

public interface ICategoryService
{
   CategoryListModel GetCategoryList();
   CategoryDto GetCategoryById(BookCategory category);
   CategoryCreatedDto CreateCategory(BookCategory category);
   CategoryUpdatedDto UpdateCategory(BookCategory category);
    void DeleteCategory(BookCategory category);
}