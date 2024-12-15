using Book.Application.DTOs.Book;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Interfaces
{
    public interface IBookService
    {
        Task InsertAsync(BookDTO request);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(int bookId, BookDTO request);
        Task<List<BookGetDTO>> SelectBook(BookRequest request);
    }
}
