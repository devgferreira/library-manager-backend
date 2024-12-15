﻿using Book.Application.DTOs.Book;
using Book.Application.Interfaces;
using Book.Domain.Contracts;
using Book.Domain.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task InsertAsync(BookCreateDTO request)
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
    }
}