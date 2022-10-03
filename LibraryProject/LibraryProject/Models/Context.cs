using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class Context:DbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Kitaplar> Kitaplars { get; set; }
        DbSet<Kiralama> Kiralamas { get; set; }

    }
}