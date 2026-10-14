
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Core.Specifications.Inventories;
using CraftPlatform.Inventory.Services.Errors;
using CraftPlatform.Inventory.Services.Repositories;
using CraftPlatform.Inventory.Shared.Abstraction;
using CraftPlatform.Inventory.Shared.Contracts.Inventories;

namespace CraftPlatform.Inventory.Services.InventoriesImplementations
{
    public class InventoriesService<TRequest, TResponse>(IGenericRepository<CraftPlatform.Inventory.Core.Entities.Inventory> inventoryRepository) : IGenericServices<TRequest, TResponse>
    {
        public async Task<Result<TResponse>> Create(TRequest contract) 
        {
            if (contract is null)
                return Result.Failure<TResponse>(InventoryErrors.ContractCannotBeNull);
            var oContract = contract as InventoryOperationsContract;

            var oData = new CraftPlatform.Inventory.Core.Entities.Inventory
            {
                InvenoryId = Guid.NewGuid(),
                Quantity = oContract!.Quantity,
                ReorderLevel = oContract.ReorderLevel,
                Location = oContract.Location,

            };

            await inventoryRepository.AddAsync(oData);
            var oResponse = new InventoryContract(oData.InvenoryId, oData.Quantity, oData.ReorderLevel, oData.Location);

            return Result<TResponse>.Success(oResponse as dynamic);
        }

        public async Task<Result<List<TResponse>>> Read()
        {
            var findInventorySpecification = new FindInventoriesSpecification();
            var oInventories = await inventoryRepository.ListAsync(findInventorySpecification);
            if (oInventories != null && oInventories.Count() > 0)
            {
                var oResponse = oInventories.Select
                    (o => new InventoryContract(o.InvenoryId, o.Quantity, o.ReorderLevel, o.Location)).ToList();
                return Result.Success(oResponse as dynamic);
            }
            else
                return Result.Success(new List<InventoryContract>()as dynamic);
        }

        public async Task<Result<TResponse>> ReadById(Guid inventoryId)
        {
            var FindInventoryByIdSpecification = new FindInventoryByIdSpecification(inventoryId);
            var oInventory = await inventoryRepository.FirstOrDefaultAsync(FindInventoryByIdSpecification);
            if (oInventory == null)
                return Result.Failure<TResponse>(InventoryErrors.InventoryNotFound);
           
            var oResponse = new InventoryContract(oInventory.InvenoryId, oInventory.Quantity, oInventory.ReorderLevel, oInventory.Location);
            return Result.Success(oResponse as dynamic);
        }

        public async Task<Result> Delete(Guid inventoryId)
        {
            var FindInventoryByIdSpecification = new FindInventoryByIdSpecification(inventoryId);
            var oInventory = await inventoryRepository.FirstOrDefaultAsync(FindInventoryByIdSpecification);
            if (oInventory == null)
                return Result.Failure(InventoryErrors.InventoryNotFound);
            await inventoryRepository.DeleteAsync(oInventory);
            return Result.Success();
        }

        public async Task<Result> Update(Guid inventoryId, TRequest contract)
        {
            if (contract is null)
                return Result.Failure(InventoryErrors.ContractCannotBeNull);
            var oContract = contract as InventoryOperationsContract;
           
            var FindInventoryByIdSpecification = new FindInventoryByIdSpecification(inventoryId);
            var oInventory = await inventoryRepository.FirstOrDefaultAsync(FindInventoryByIdSpecification);
            if (oInventory == null)
                return Result.Failure(InventoryErrors.InventoryNotFound);
            
            
            oInventory.Quantity = oContract!.Quantity;
            oInventory.ReorderLevel = oContract.ReorderLevel;
            oInventory.Location = oContract.Location;
            await inventoryRepository.UpdateAsync(oInventory);
           
            return Result.Success();
        }

        public Task<Result<IEnumerable<TResponse>>> ReadByParentId(Guid parentContractId)
        {
            throw new NotImplementedException();
        }
        public Task<Result<TResponse>> ReadSingleByParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
        public Task<Result> UpdateParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }

    }
}
