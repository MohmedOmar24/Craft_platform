
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Core.Specifications.Categories;
using CraftPlatform.Inventory.Core.Specifications.Products;
using CraftPlatform.Inventory.Services.Errors;
using CraftPlatform.Inventory.Services.Repositories;
using CraftPlatform.Inventory.Shared.Abstraction;
using CraftPlatform.Inventory.Shared.Contracts.Products;

namespace CraftPlatform.Inventory.Services.ProductsImplementations
{
    public class ProductsServices<TRequest, TResponse>(IGenericRepository<Product> productRepository,
                                                      IGenericRepository<Category> categoryRepository) : IGenericServices<TRequest, TResponse>
    {
        public async Task<Result<TResponse>> Create(TRequest contract)
        {
            var oContract = contract as ProductsOperationsContract;
            var oCategoryReadByIdSpecification = new FindCategoryByIdSpecification(oContract!.CategoryId);
            var oCategory = await categoryRepository.FirstOrDefaultAsync(oCategoryReadByIdSpecification);
            var oData = new Product
            {
                Name = oContract!.Name,
                Description = oContract.Description,
                CategoryId = oContract.CategoryId,
                UnitPrice = oContract.UnitPrice,
                Weight = oContract.Weight,
                Height = oContract.Height,
                Length = oContract.Length,
                Width = oContract.Width,
                TaxCost = oContract.TaxCost,
                ProductionCost = oContract.ProductionCost,
                ProfitPerUnit = oContract.ProfitPerUnit,
                Category = oCategory!
            };
            await productRepository.AddAsync(oData);
            return Result.Success(new ProductsContract(
                oData.ProductId,
                oData.CategoryId,
                oData.InventoryId,
                oData.Name,
                oData.Description,
                oData.UnitPrice,
                oData.Width,
                oData.Weight,
                oData.Length,
                oData.Height,
                oData.TaxCost,
                oData.ProfitPerUnit,
                oData.ProductionCost,
                oData.CreatedBy,
                oData.UpdatedBy,
                oData.CreatedAt,
                oData.UpdatedAt
                                   ) as dynamic);
        }
        public async Task<Result<TResponse>> ReadById(Guid productId)
        {
            var oReadByIdSpecification = new FindProductByIdSpecification(productId);
            var oProduct = await productRepository.FirstOrDefaultAsync(oReadByIdSpecification);
            if (oProduct is null)
            {
                return Result.Failure<TResponse>(ProductErrors.ProductNotFound);
            }
            return Result.Success(new ProductsContract(
                oProduct.ProductId,
                oProduct.CategoryId,
                oProduct.InventoryId,
                oProduct.Name,
                oProduct.Description,
                oProduct.UnitPrice,
                oProduct.Width,
                oProduct.Weight,
                oProduct.Length,
                oProduct.Height,
                oProduct.TaxCost,
                oProduct.ProfitPerUnit,
                oProduct.ProductionCost,
                oProduct.CreatedBy,
                oProduct.UpdatedBy,
                oProduct.CreatedAt,
                oProduct.UpdatedAt
                                   ) as dynamic);

        }
        public async Task<Result<IEnumerable<TResponse>>> Read()
        {
            var oReadSpecification = new FindProductsSpecification();
            var oProducts = await productRepository.ListAsync(oReadSpecification);
            var oData = oProducts.Select(oProduct => new ProductsContract(
                oProduct.ProductId,
                oProduct.CategoryId,
                oProduct.InventoryId,
                oProduct.Name,
                oProduct.Description,
                oProduct.UnitPrice,
                oProduct.Width,
                oProduct.Weight,
                oProduct.Length,
                oProduct.Height,
                oProduct.TaxCost,
                oProduct.ProfitPerUnit,
                oProduct.ProductionCost,
                oProduct.CreatedBy,
                oProduct.UpdatedBy,
                oProduct.CreatedAt,
                oProduct.UpdatedAt
                                   )).ToList();
            return Result.Success(oData as dynamic);
        }
        public async Task<Result> Delete(Guid productId)
        {
            var oReadByIdSpecification = new FindProductByIdSpecification(productId);
            var oProduct = await productRepository.FirstOrDefaultAsync(oReadByIdSpecification);
            if (oProduct is null)
            {
                return Result.Failure(ProductErrors.ProductNotFound);
            }
            await productRepository.DeleteAsync(oProduct);
            return Result.Success();
        }
        public async Task<Result> Update(Guid productId, TRequest contract)
        {
            var oContract = contract as ProductsOperationsContract;
            var oFindByIdSpecification = new FindProductByIdSpecification(productId);
            var oProduct = await productRepository.FirstOrDefaultAsync(oFindByIdSpecification);
            if (oProduct is null)
                return Result.Failure(ProductErrors.ProductNotFound);

            {
                oProduct.Name = oContract!.Name;
                oProduct.Description = oContract!.Description;
                oProduct.Width = oContract!.Width;
                oProduct.Height = oContract!.Height;
                oProduct.Length = oContract!.Length;
                oProduct.Weight = oContract!.Weight;
                oProduct.UnitPrice = oContract!.UnitPrice;
                oProduct.TaxCost = oContract!.TaxCost;
                oProduct.ProductionCost = oContract!.ProductionCost;
                oProduct.ProfitPerUnit = oContract!.ProfitPerUnit;
                oProduct.CategoryId = oContract!.CategoryId;
                oProduct.UpdatedAt = DateTime.UtcNow;
                oProduct.CreatedAt = oProduct.CreatedAt;

            }
            await productRepository.UpdateAsync(oProduct);
            return Result.Success();
        }
        public async Task<Result<IEnumerable<TResponse>>> ReadByParentId(Guid categoryId)
        {
            var oReadByCategoryIdSpecification = new FindProductsByCategoryIdSpecification(categoryId);
            var oProducts = await productRepository.ListAsync(oReadByCategoryIdSpecification);
            if (!oProducts.Any())
            {
                return Result.Failure<IEnumerable<TResponse>>(ProductErrors.ProductNotFound);
            }
            var oData = oProducts.Select(oProduct => new ProductsContract(
                oProduct.ProductId,
                oProduct.CategoryId,
                oProduct.InventoryId,
                oProduct.Name,
                oProduct.Description,
                oProduct.UnitPrice,
                oProduct.Width,
                oProduct.Weight,
                oProduct.Length,
                oProduct.Height,
                oProduct.TaxCost,
                oProduct.ProfitPerUnit,
                oProduct.ProductionCost,
                oProduct.CreatedBy,
                oProduct.UpdatedBy,
                oProduct.CreatedAt,
                oProduct.UpdatedAt
                                   )).ToList();
            return Result.Success(oData as dynamic);
        }
        public async Task<Result> UpdateParentId(Guid productId, Guid categoryId)

        {
            var oFindByIdSpecification = new FindProductByIdSpecification(productId);
            var oProduct = await productRepository.FirstOrDefaultAsync(oFindByIdSpecification);
            if (oProduct is null)
                return Result.Failure(ProductErrors.ProductNotFound);
            oProduct.CategoryId = categoryId;
            oProduct.UpdatedAt = DateTime.UtcNow;
            await productRepository.UpdateAsync(oProduct);
            return Result.Success();
        }
        public async Task<Result<TResponse>> ReadSingleByParentId(Guid categoryId,Guid productId)
        {
            var oReadByNameSpecification = new FindSingleProductByCategoryId(categoryId, productId);
            var oProduct = await productRepository.FirstOrDefaultAsync(oReadByNameSpecification);
            if (oProduct is null)
            {
                return Result.Failure<TResponse>(ProductErrors.ProductNotFound);
            }
            return Result.Success(new ProductsContract(
                oProduct.ProductId,
                oProduct.CategoryId,
                oProduct.InventoryId,
                oProduct.Name,
                oProduct.Description,
                oProduct.UnitPrice,
                oProduct.Width,
                oProduct.Weight,
                oProduct.Length,
                oProduct.Height,
                oProduct.TaxCost,
                oProduct.ProfitPerUnit,
                oProduct.ProductionCost,
                oProduct.CreatedBy,
                oProduct.UpdatedBy,
                oProduct.CreatedAt,
                oProduct.UpdatedAt
                                   ) as dynamic);
        }
    }
}

