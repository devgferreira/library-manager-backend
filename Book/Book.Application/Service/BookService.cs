using Book.Application.DTOs.Book;
using Book.Application.Interfaces;
using Book.Domain.Contracts;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task DeleteAsync(int bookId)
        {
            try
            {
                await _bookRepository.DeleteAsync(bookId);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public async Task InsertAsync(BookDTO request)
        {
            try
            {
                await _bookRepository.InsertAsync(request: new BookInfo
                {
                    Title = request.Title,
                    Author = request.Author,
                    Genre = request.Genre,
                    ISBN = request.ISBN,
                    PublicationYear = request.PublicationYear,
                    Publisher = request.Publisher,
                    QuantityAvailable = request.QuantityAvailable,
                    LibraryLocation = request.LibraryLocation
                });
                return;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public async Task<List<BookGetDTO>> SelectBook(BookRequest request)
        {
            try
            {
                var books = await _bookRepository.SelectBook(request);
                var bookDTOs = books.Select(book => new BookGetDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationYear,
                    Publisher = book.Publisher,
                    QuantityAvailable = book.QuantityAvailable,
                    LibraryLocation = book.LibraryLocation
                }).ToList();

                return bookDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateAsync(int bookId, BookDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
