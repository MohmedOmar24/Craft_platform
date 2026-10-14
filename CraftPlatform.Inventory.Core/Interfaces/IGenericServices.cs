using CraftPlatform.Inventory.Shared.Abstraction;

 
namespace CraftPlatform.Inventory.Core.Interfaces
{
    public interface IGenericServices<TRequest,TResponse>
    { 
        Task<Result<TResponse>> Create(TRequest contract);
        Task<Result<List<TResponse>>> Read();
        Task<Result<IEnumerable<TResponse>>> ReadByParentId(Guid parentContractId);
        Task<Result<TResponse>> ReadById(Guid contractId);
        Task<Result<TResponse>> ReadSingleByParentId(Guid contractId,Guid parentContractId);
        Task<Result> Delete(Guid contractId);
        Task<Result> Update(Guid contractId,TRequest contract);
        Task<Result> UpdateParentId(Guid contractId,Guid parentContractId);
      
    }
}