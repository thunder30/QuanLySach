using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab02_QuanLySach.Models;

namespace lab02_QuanLySach.Models
{
    
    public class ListBook
    {
        private List<Book> list = new List<Book>();
        public ListBook()
        {

        }

        public List<Book> List { get => list; set => list = value; }
    }
}