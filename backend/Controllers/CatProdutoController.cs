using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    // Definimos nossa rota do controller e dizemos que é um controller de API
    [Route("api/[controller]")]
    [ApiController]
    public class CatProdutoController : ControllerBase
    {
        fastradeContext _contexto = new fastradeContext();

        //GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<List<CatProduto>>> Get()
        {
            var catprodutos = await _contexto.CatProduto.ToListAsync();

            if (catprodutos == null)
            {
                return NotFound();
            }
            return catprodutos;
        }

        //GET: api/Categoria2
        [HttpGet("{id}")]
        public async Task<ActionResult<CatProduto>> Get(int id)
        {
            // FindAsync = procura algo especifico no banco 
            var catproduto = await _contexto.CatProduto.FindAsync(id);

            if (catproduto == null)
            {
                return NotFound();
            }
            return catproduto;
        }

        //POST api/Categoria
        [HttpPost]
        public async Task<ActionResult<CatProduto>> Post(CatProduto catproduto)
        {
            try
            {
                // Tratamos contra ataques de SQL Injection
                await _contexto.AddAsync(catproduto);

                //Salvamos efetivamente o nosso objeto no banco de dadOS
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return catproduto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CatProduto catproduto)
        {
            //Se o Id do objeto não existir
            //ele retorna 400
            if (id != catproduto.IdCatProduto)
            {
                return BadRequest();
            }

            //Comparamos os atributos que foram modificados atraves EF
            _contexto.Entry(catproduto).State = EntityState.Modified;
            try
            {

                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //verificamos se o objeto insirido realmente existe no banco
                var catproduto_valido = await _contexto.CatProduto.FindAsync(id);

                if (catproduto_valido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //Nocontent = retorna 204. sem nada
            return NoContent();
        }
        //DELETE api/categoria/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatProduto>> Delete(int id)
        {
            var catproduto = await _contexto.CatProduto.FindAsync(id);
            if (catproduto == null)
            {
                return NotFound();
            }
            _contexto.CatProduto.Remove(catproduto);
            await _contexto.SaveChangesAsync();

            return catproduto;
        }


    }
}