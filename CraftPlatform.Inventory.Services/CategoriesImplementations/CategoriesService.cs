using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Core.Specifications.Categories;
using CraftPlatform.Inventory.Services.Errors;
using CraftPlatform.Inventory.Services.Repositories;
using CraftPlatform.Inventory.Shared.Abstraction;
using CraftPlatform.Inventory.Shared.Contracts.Categories;

namespace CraftPlatform.Inventory.Services.CategoriesImplementations
{
    public class CategoriesService<TRequest, TRespone>(IGenericRepository<Category> categoryRepository):IGenericServices<TRequest,TRespone>
    {
        public async Task<Result<TRespone>> Create(TRequest contract)
        {
            var oContract = contract as CategoriesOperationsContract;
            var oData = new Category
            {
                Name = oContract!.Name,
                Description = oContract.Description,
            };

            await categoryRepository.AddAsync(oData);
            return Result.Success(oContract as dynamic);
        }
       
        public async Task<Result<TRespone>> ReadById(Guid categoryId)
        {
            var oReadByIdSpecification = new FindCategoryByIdSpecification(categoryId);
            var category = await categoryRepository.FirstOrDefaultAsync(oReadByIdSpecification);
            if(category != null)
            {
                var oData = new CategoriesContract
                (
                    category.CategoryId,
                    category.Name,
                    category.Description,
                    category.CreatedBy,
                    category.UpdatedBy,
                    category.CreatedAt,
                    category.UpdatedAt
                );
                return Result.Success(oData as dynamic);
            }
            else return Result.Failure<TRespone>(CategoryErrors.CategoryNotFound);
        }

        public  async Task<Result> Delete(Guid categoryId)
        {
            var oReadByIdSpecification = new FindCategoryByIdSpecification(categoryId);
            var category = await categoryRepository.FirstOrDefaultAsync(oReadByIdSpecification);
            if (category != null)
            {
                await categoryRepository.DeleteAsync(category);
                return Result.Success();
            }
            else return Result.Failure(CategoryErrors.CategoryNotFound);
        }

        public async Task<Result<IEnumerable<TRespone>>> Read()
        {
            var oReadAllSpecification = new FindCategoriesSpecification();
            var categories = await categoryRepository.ListAsync(oReadAllSpecification);
            var oData = categories.Select(category => new CategoriesContract
            (
                    category.CategoryId,
                    category.Name,
                    category.Description,
                    category.CreatedBy,
                    category.UpdatedBy,
                    category.CreatedAt,
                    category.UpdatedAt
                ));
            return Result.Success(oData as dynamic);
        }
      
        public async Task<Result> Update(Guid categoryId, TRequest contract)
        {
            var oContract = contract as CategoriesOperationsContract;
            var oReadByIdSpecification = new FindCategoryByIdSpecification(categoryId);
            var categoryToUpdate = await categoryRepository.FirstOrDefaultAsync(oReadByIdSpecification);
            if(categoryToUpdate != null)
            {

                categoryToUpdate.Name = oContract!.Name;
                categoryToUpdate.Description = oContract.Description;
                categoryToUpdate.UpdatedAt = DateTime.UtcNow;
                categoryToUpdate.UpdatedBy =Guid.NewGuid(); 
                await categoryRepository.UpdateAsync(categoryToUpdate);
                return Result.Success();
            }
            else return Result.Failure(CategoryErrors.CategoryNotFound);

        }

       
        
        public Task<Result<IEnumerable<TRespone>>> ReadByParentId(Guid parentContractId)
          => throw new NotImplementedException();
      
        public Task<Result<TRespone>> ReadSingleByParentId(Guid contractId, Guid parentContractId)
          => throw new NotImplementedException();

        public Task<Result> UpdateParentId(Guid contractId, Guid parentContractId)
          =>throw new NotImplementedException();
        
    }
}
