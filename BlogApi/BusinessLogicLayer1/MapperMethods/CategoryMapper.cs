using DomainLayer.DTO;
using DomainLayer.DTO.CategoryDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class CategoryMapper
    {
        public DomainLayer.Models.BlogModels.Category MapCategoryDtoToCategory(CategoryZDto CategoryZDto)
        {
            return new DomainLayer.Models.BlogModels.Category
            {
                Name = CategoryZDto.Name,
            };
        }

        public CategoryZDto MapCategoryToCategoryZDto(DomainLayer.Models.BlogModels.Category category)
        {
            return new CategoryZDto
            {
                Name = category.Name,
            };
        }

        public DomainLayer.Models.BlogModels.Category MapDeleteCategoryZRequestToCategoryZ(DeleteRequestCategoryZDto deleteRtCategoryDto)
        {
            return new DomainLayer.Models.BlogModels.Category
            {
                Id = deleteRtCategoryDto.Id
            };
        }
    }
}
