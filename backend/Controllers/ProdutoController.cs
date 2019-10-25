using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        fastradeContext _contexto = new fastradeContext ();

        //Get: Api/Produtoreceita
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get () {

            var produtos = await _contexto.Produto.Include("IdCatProdutoNavigation").ToListAsync();

            if (produtos == null) {
                return NotFound();
            }
            return produtos;
        }
        //Get: Api/Produtoreceita
        [HttpGet ("{id}")]
        public async Task<ActionResult<Produto>> Get(int id){
            var produto = await _contexto.Produto.Include("IdCatProdutoNavigation").FirstOrDefaultAsync (e => e.IdProduto == id);

            if (produto == null){
                return NotFound ();
            }
            return produto;
        }
        //Post: Api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> Post (Produto produto){
            try{
                await _contexto.AddAsync (produto);

                await _contexto.SaveChangesAsync();
                

                }catch (DbUpdateConcurrencyException){
                    throw;
            }
            return produto;
        }
        //Put: Api/Produto
        [HttpPut ("{id}")]
        public async Task<ActionResult> Put (int id, Produto produto){
            if(id != produto.IdProduto){
                
                return BadRequest ();
            }
            _contexto.Entry (produto).State = EntityState.Modified;
            try{
                await _contexto.SaveChangesAsync ();
            }catch (DbUpdateConcurrencyException){
                var produto_valido = await _contexto.Produto.FindAsync (id);

                if(produto_valido == null) {
                    return NotFound ();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
         // DELETE api/Produto/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id){

            var produto = await _contexto.Produto.FindAsync(id);
            if(produto == null){
                return NotFound();
            }

            _contexto.Produto.Remove(produto);
            await _contexto.SaveChangesAsync();

            return produto;
        }  
    }
}   