using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ProdutoReceitaController : ControllerBase {
        fastradeContext _contexto = new fastradeContext ();

        //Get: Api/Produtoreceita
        [HttpGet]
        public async Task<ActionResult<List<ProdutoReceita>>> Get () {

            var produtoreceitas = await _contexto.ProdutoReceita.Include("IdProdutoNavigation").Include("IdReceitaNavigation").ToListAsync();

            if (produtoreceitas == null) {
                return NotFound();
            }
            return produtoreceitas;
        }
        //Get: Api/Produtoreceita
        [HttpGet ("{id}")]
        public async Task<ActionResult<ProdutoReceita>> Get(int id){
            var produtoreceita = await _contexto.ProdutoReceita.Include("IdProdutoNavigation").Include("IdReceitaNavigation").FirstOrDefaultAsync (e => e.IdProdutoReceita == id);

            if (produtoreceita == null){
                return NotFound ();
            }
            return produtoreceita;
        }
        //Post: Api/ProdutoReceita
        [HttpPost]
        public async Task<ActionResult<ProdutoReceita>> Post (ProdutoReceita produtoreceita){
            try{
                await _contexto.AddAsync (produtoreceita);

                await _contexto.SaveChangesAsync();
                

                }catch (DbUpdateConcurrencyException){
                    throw;
            }
            return produtoreceita;
        }
        //Put: Api/ProdutoReceita
        [HttpPut ("{id}")]
        public async Task<ActionResult> Put (int id, ProdutoReceita produtoreceita){
            if(id != produtoreceita.IdProdutoReceita){
                
                return BadRequest ();
            }
            _contexto.Entry (produtoreceita).State = EntityState.Modified;
            try{
                await _contexto.SaveChangesAsync ();
            }catch (DbUpdateConcurrencyException){
                var produtoreceita_valido = await _contexto.ProdutoReceita.FindAsync (id);

                if(produtoreceita_valido == null) {
                    return NotFound ();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
         // DELETE api/ProdutoReceita/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoReceita>> Delete(int id){

            var produtoreceita = await _contexto.ProdutoReceita.FindAsync(id);
            if(produtoreceita == null){
                return NotFound();
            }

            _contexto.ProdutoReceita.Remove(produtoreceita);
            await _contexto.SaveChangesAsync();

            return produtoreceita;
        }  
    }
}   