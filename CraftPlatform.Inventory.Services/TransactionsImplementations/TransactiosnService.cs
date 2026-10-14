
using CraftPlatform.Inventory.Core.Entities;
using CraftPlatform.Inventory.Core.Interfaces;
using CraftPlatform.Inventory.Core.Specifications.Transactions;
using CraftPlatform.Inventory.Services.Errors;
using CraftPlatform.Inventory.Services.Repositories;
using CraftPlatform.Inventory.Shared.Abstraction;
using CraftPlatform.Inventory.Shared.Contracts.Transactions;

namespace CraftPlatform.Inventory.Services.TransactionsImplementations
{
    public class TransactiosnService<TRequest, TResponse>(IGenericRepository<Transaction> transactionRepository) : IGenericServices<TRequest, TResponse>
    {
        public async Task<Result<TResponse>> Create(TRequest contract)
        {
            if (contract is null)
                return Result.Failure<TResponse>(TransactionErrors.ContractCannotBeNull);

            var oContract = contract as TransactionsOperationsContract;
            var oData = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                Notes = oContract!.Notes,
                Quantity = oContract.Quantity,
                TransactionDate = oContract.TransactionDate,
                TransactionType = oContract.TransactionType,
                EmployeeId = oContract.EmployeeId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Guid.Empty,
            };
            await transactionRepository.AddAsync(oData);
            return Result.Success(new TransactionContract(oData.TransactionId, oData.EmployeeId,
                                                         oData.TransactionDate, oData.Quantity,
                                                         oData.TransactionType, oData.Notes,
                                                         oData.CreatedBy, oData.UpdatedBy,
                                                         oData.CreatedAt, oData.UpdatedAt) as dynamic);
        }    
        public async Task<Result<List<TResponse>>> Read()
        {
            var findTransactionsSpecification = new FindTransactionsSpecification();
            var oTransactions = await transactionRepository.ListAsync(findTransactionsSpecification);
            if (oTransactions != null && oTransactions.Count() > 0)
            {
                var oResponse = oTransactions.Select
                    (o => new TransactionContract(o.TransactionId, o.EmployeeId,
                                                  o.TransactionDate, o.Quantity,
                                                  o.TransactionType, o.Notes,
                                                  o.CreatedBy, o.UpdatedBy,
                                                  o.CreatedAt, o.UpdatedAt)).ToList();
                return Result.Success(oResponse as dynamic);
            }
            else
                return Result.Success(new List<TransactionContract>() as dynamic);
        }
        public async Task<Result<TResponse>> ReadById(Guid contractId)
        {
            var findTransactionByIdSpecification = new FindTransactionByIdSpecification(contractId);
            var oTransaction = await transactionRepository.FirstOrDefaultAsync(findTransactionByIdSpecification);
            if (oTransaction == null)
                return Result.Failure<TResponse>(TransactionErrors.TransactionNotFound);

            return Result.Success(new TransactionContract(oTransaction.TransactionId, oTransaction.EmployeeId,
                                                         oTransaction.TransactionDate, oTransaction.Quantity,
                                                         oTransaction.TransactionType, oTransaction.Notes,
                                                         oTransaction.CreatedBy, oTransaction.UpdatedBy,
                                                         oTransaction.CreatedAt, oTransaction.UpdatedAt) as dynamic);
        }
        public async Task<Result> Delete(Guid contractId)
        {
            var findTransactionByIdSpecification = new FindTransactionByIdSpecification(contractId);
            var oTransaction = await transactionRepository.FirstOrDefaultAsync(findTransactionByIdSpecification);
            if (oTransaction == null)
                return Result.Failure(TransactionErrors.TransactionNotFound);
            await transactionRepository.DeleteAsync(oTransaction);
            return Result.Success();
        }
        public async Task<Result> Update(Guid contractId, TRequest contract)
        {
            var findTransactionByIdSpecification = new FindTransactionByIdSpecification(contractId);
            var oTransaction = await transactionRepository.FirstOrDefaultAsync(findTransactionByIdSpecification);

            if (oTransaction == null)
                return Result.Failure(TransactionErrors.TransactionNotFound);

            var oContract = contract as TransactionsOperationsContract;

            oTransaction.Notes = oContract!.Notes;
            oTransaction.Quantity = oContract.Quantity;
            oTransaction.TransactionDate = oContract.TransactionDate;
            oTransaction.TransactionType = oContract.TransactionType;
          //  oTransaction.EmployeeId = oContract.EmployeeId;
            oTransaction.UpdatedAt = DateTime.UtcNow;
            oTransaction.UpdatedBy = Guid.Empty;
           

            await transactionRepository.UpdateAsync(oTransaction);
            return Result.Success();
        }
        public async Task<Result> UpdateParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<TResponse>> ReadSingleByParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<IEnumerable<TResponse>>> ReadByParentId(Guid parentContractId)
        {
           throw new NotImplementedException();
        }
        
    }
}
