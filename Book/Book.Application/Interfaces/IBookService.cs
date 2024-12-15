using Book.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Interfaces
{
    public interface IBookService
    {
        Task InsertAsync(BookCreateDTO request);
    }
}
