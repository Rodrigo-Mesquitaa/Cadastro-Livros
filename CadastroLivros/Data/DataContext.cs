using CadastroLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroLivros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { 
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
