using CadastroLivros.Data;
using CadastroLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroLivros.Controller
{
    [ApiController]
    [Route("v1/livros")]

    public class LivroController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Livro>>> Get([FromServices] DataContext context)
        {
            var livros = await context.Livros.Include(x => x.Categoria).ToListAsync();
            return livros;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Livro>> GetById([FromServices] DataContext context, int id)
        {
            var livro = await context.Livros.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Id == id);
            return livro;
        }

        [HttpGet]
        [Route("categorias/{id:int}")]

        public async Task<ActionResult<List<Livro>>> GetByCategoria([FromServices] DataContext context, int id)
        {
            var livros = await context.Livros
                .Include(x => x.Categoria)
                .AsNoTracking()
                .Where(x => x.IdCategoria == id)
                .ToListAsync();
            return livros;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Livro>> Post(
            [FromServices] DataContext context,
            [FromBody]Livro model)
        {
            if (ModelState.IsValid)
            {
                context.Livros.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Livro>> Put(
            [FromServices] DataContext context,
            [FromBody]Livro model, int id)
        {
            if (context.Livros.Any(x => x.Id == id))
            {
                if (ModelState.IsValid)
                {
                    model.Id = id;
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("Livro não encontrado");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
           [FromServices] DataContext context,
           int id)
        {
            var livro = context.Livros.FirstOrDefault(x => x.Id == id);
            context.Entry(livro).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
