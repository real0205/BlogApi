using BusinessLogicLayer.IService;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models.BlogModels;


namespace BusinessLogicLayer.Service
{
    public class CategoriesService: ICategorieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category? CreateCategory(Category category, out string message)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name cannot be empty";
                return null;
            }

            DomainLayer.Models.BlogModels.Category result = _unitOfWork.categoryRepository.Create(category);
            message = "Successful";
            return result;
        }



        public bool DeleteCategory(int id, out string message)
        {
            Category? Result = GetCategory(id);

            if (Result == null)
            {
                message = "Invalid id";
                return false;
            }

            _unitOfWork.categoryRepository.Delete(Result);
            message = "Deleted Successfully";
            return true;

        }

        public List<Category> GetAllCategory()
        {
            return _unitOfWork.categoryRepository.Get();
        }

        public Category? GetCategory(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.categoryRepository.Get(id);
        }

        public Category? UpdateCategory(Category category, out string message)
        {
            if (category.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name is Required";
                return null;
            }

            Category? updatedCategory = _unitOfWork.categoryRepository.Update(category);

            if (updatedCategory is null)
            {
                message = "Category not found";
                return null;
            }

            message = "Successfully Upated";
            return updatedCategory;
        }
    }
}
