using Kutuphane.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Burada, direkt oluşturmus oldugumuz ApplicationDbContext’in ctorunu, dışarıdan DbContextOptions alabilir hale getiriyoruz ve aldıgımız option’ı da ana klasın ctor’una paslıyoruz.
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        


    }
}
