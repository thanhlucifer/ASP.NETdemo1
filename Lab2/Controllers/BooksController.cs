using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;


namespace Lab2.Controllers
{
    public class BooksController : Controller
    {
        // GET: Book
        private List<Book> listbook;

        public BooksController()
        {
            listbook = new List<Book>();
            listbook.Add(new Book()
            {
                Id = 1,
                Title = "Vụ Ám Sát Ông Roger Ackroyd",
                Author = "Agatha Christie",
                PublicYear = 2020,
                Price = 400,
                Cover = "Content/images/book1.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 2,
                Title = "Ca Dao Tục Ngữ Việt Nam",
                Author = "Hải Yến ",
                PublicYear = 2020,
                Price = 70,
                Cover = "Content/images/book2.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 3,
                Title = "Đường Thi",
                Author = "Trần Trọng Kim",
                PublicYear = 1950,
                Price = 100,
                Cover = "Content/images/book3.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 4,
                Title = "Ngân Hàng Biết Tìm Khách Hàng Ở Đâu? ",
                Author = "Trịnh Minh Thảo",
                PublicYear = 2023,
                Price = 260,
                Cover = "Content/images/book4.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 5,
                Title = "Kotler Bàn Về Tiếp Thị",
                Author = "Philip Kotler",
                PublicYear = 2019,
                Price = 250,
                Cover = "Content/images/book6.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 6,
                Title = "Dạy Con Làm Giàu ",
                Author = "Robert T Kiyosaki, Sharon L Lechter",
                PublicYear = 2019,
                Price = 300,
                Cover = "Content/images/book5.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 7,
                Title = "Đắc Nhân Tâm ",
                Author = "Dale Carnegie",
                PublicYear = 2020,
                Price = 80,
                Cover = "Content/images/book7.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 8,
                Title = "Giao Tiếp Thông Minh Và Tài Ứng Xử ",
                Author = "Đức Thành",
                PublicYear = 2022,
                Price = 100,
                Cover = "Content/images/book8.jpg"
            });
            listbook.Add(new Book()
            {
                Id = 10,
                Title = "Đạo Lý Làm Người ",
                Author = "Lan Phương",
                PublicYear = 2022,
                Price = 110,
                Cover = "Content/images/book9.jpg"
            });

        }
        public ActionResult ListBooks()
        {
            ViewBag.TitlePageName = "Book View Page";
            return View(listbook);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book =listbook.Find(s => s.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book =listbook.Find(s =>s.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listbook.Find(b => b.Id== book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover= book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;
                    return View("ListBooks", listbook);

                }catch(Exception ex)
                {
                    return HttpNotFound(ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Input Model not Valide!");
                return View(book);
            }
        }
    }
}