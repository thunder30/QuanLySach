using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab02_QuanLySach.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        public Book()
        {

        }

        public Book(int id, string title, string author, string image_cover)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Image_cover = image_cover;
        }

        public Book(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Author = book.Author;
            this.Image_cover = book.Image_cover;
        }

        [Required(ErrorMessage = "Id không được trống")]
        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề sách không được vượt quá 250 ký tự")]
        [Display(Name = "Tiêu đề")]
        public string Title { get => title; set => title = value; }
        [Required(ErrorMessage = "Tác giả không được trống")]
        public string Author { get => author; set => author = value; }
        [Required(ErrorMessage = "Đường dẫn không được trống")]
        public string Image_cover { get => image_cover; set => image_cover = value; }
    }
}