using BlogApi.DomainLayer.Models;
using DomainLayer.DTO.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperModel
{
    public class CategoryMapper
    {
        public Category MapCategoryRequestToCategory(CreateRequestCategoryDto createRequestCategoryDto)
        {
            return new Category
            {
                CategoryName = createRequestCategoryDto.CategoryName,
                CreatedAt = DateTime.UtcNow
            };
        }

        public CategoryDto MapCategoryToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
            };
        }

        public Category MapUpdateCategoryDtoToCategory(UpdateCategoryDto updateCategoryDto)
        {
            return new Category
            {
                Id = updateCategoryDto.Id,
                CategoryName = updateCategoryDto.CategoryName,
            };
        }
    }
}
