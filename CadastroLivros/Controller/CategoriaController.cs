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
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody]Categoria model)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(
           [FromServices] DataContext context,
           [FromBody]Categoria model, int id)
        {
            if (context.Categorias.Any(x => x.Id == id))
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
                return BadRequest("Categoria não encontrada");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
          [FromServices] DataContext context,
          int id)
        {
            var categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
            context.Entry(categoria).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }

    }
}

