using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;

namespace Book.Domain.Contracts
{
    public interface IBookRepository
    {
        Task InsertAsync(BookInfo request);
        Task<BookInfo> UpdateAsync();
        Task DeleteAsync(int bookId);
        Task<List<BookInfo>> SelectBook(BookRequest request);
    }
}
