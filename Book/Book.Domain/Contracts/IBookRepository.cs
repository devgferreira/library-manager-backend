using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain;
using Book.Domain.Entities;

namespace Book.Domain.Contracts
{
    public interface IBookRepository
    {
        Task<BookInfo> InsertAsync();
        Task<BookInfo> UpdateAsync();
        Task DeleteAsync(int bookId);
        Task<BookInfo> SelectBook(string title, string author, string genre, string isbn);
    }
}
