﻿using BooksStore.Business;
using BooksStore.Business.Models;
using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FirstMVC.Controllers
{
    public class BooksController : Controller
    {

        public static List<BookViewModel> _books;

        public BooksController()
        {
            _books = new List<BookViewModel>();
            _books.Add(new BookViewModel
            {
                BookID = 1,
                Title = "The Three Body Problem",
                ISBN = "9780444566980",
                Synopsis = "The Three-Body Problem is a story by Chinese science fiction author Liu Cixin, the first novel in the Remembrance of Earth's Past trilogy. The series portrays a fictional past, present, and future whe…",
                Image = "https://erdorin.org/wp-content/uploads/2017/06/three-body-problem.jpg",
                Format = Format.Paperback,
                Language = Language.English,
                Price = 400,
                GenreId = 1,
                AuthorID = 1,
                Status = true,
                CreatedAt = DateTime.Now,
                LastUpdate = DateTime.Now
            });
            _books.Add(new BookViewModel
            {
                BookID = 1,
                Title = "1984",
                ISBN = "54145145",
                Synopsis = "abcd",
                Image = "https://kopp-medien.websale.net/bilder/gross/133206.jpg",
                Format = Format.Paperback,
                Language = Language.English,
                Price = 200,
                GenreId = 1,
                AuthorID = 1,
                Status = true,
                CreatedAt = DateTime.Now,
                LastUpdate = DateTime.Now
            });
        }
        // GET: Books
        public ActionResult Books()
        {
            return View(_books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(x => x.BookID == id);
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var genres = new BooksStoreBusiness().GetGenres();
            ViewBag.Genres = genres;

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var genres = new BooksStoreBusiness().GetGenres();
                ViewBag.Genres = genres;

                var BooksStoreBusinessObject = new BooksStoreBusiness();
                var genresFullList = BooksStoreBusinessObject.GetGenres();
                

                var Title = collection["Title"].ToString();
                var ISBN = collection["ISBN"].ToString();
                var Synopsis = collection["Synopsis"].ToString();
                var Image = collection["Image"].ToString();
                var Price = Convert.ToDouble(collection["Price"]);
                var SelectedGenresList = new List<GenreModel>();
                foreach (var genre in genresFullList)
                {
                    if (collection[$"{genre.Name}"] != null)
                    {
                        SelectedGenresList.Add(genre);
                    }
                }
                var Status = collection["Status"] != null;

                var datObject = new BooksStoreBusiness();
                datObject.CreateBook(
                    Title,
                    Synopsis,
                    Image,
                    ISBN,
                    Price,
                    SelectedGenresList,
                    Status,
                   
                    DateTime.Now,
                    DateTime.Now);

                return RedirectToAction("Books");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
