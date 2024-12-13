﻿using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync();
        Task<TransactionDto> GetTransactionAsync(int id);
        Task<bool> CreateTransactionAsync(TransactionDto transactionDto);
        Task<bool> TransactionExistsAsync(int transactionId);
        Task<bool> UpdateTransactionAsync(TransactionDto transactionDto);
        Task<bool> DeleteTransactionAsync(TransactionDto transactionDto);
        Task<bool> SaveAsync();
    }
}
