using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICategoryRepository categoryRepository;

        public BookController(IBookRepository bookRepo, ICategoryRepository categoryRepo)
        {
            bookRepository = bookRepo;
            categoryRepository = categoryRepo;
        }
        
        public ViewResult List()
        {
            //ViewBag.SelectedCategory = categoryRepository.AllCategories.ToList()[1].Name;
            //return View(bookRepository.AllBooks);

            BookListVM bookListVM = new BookListVM
            {
                Books = bookRepository.AllBooks,
                SelectedCategory = categoryRepository.AllCategories.ToList()[1].Name
            };

            return View(bookListVM);
        }

        public IActionResult Details(int id)
        {
            var book = bookRepository.GetBookById(id);
            return View(book);
        }
    }
}
