using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase {
        fastradeContext _contexto = new fastradeContext ();

        //Get: Api/Oferta
        [HttpGet]
        public async Task<ActionResult<List<Oferta>>> Get () {
            //Include("")
            var oferta = await _contexto.Oferta.Include("IdProdutoNavigation").Include("IdUsuarioNavigation").ToListAsync();
            if (oferta == null) {
                return NotFound();
            }
            return oferta;
        }
        //Get: Api/Oferta/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<Oferta>> Get(int id){
            var oferta = await _contexto.Oferta.Include("IdProdutoNavigation").Include("IdUsuarioNavigation").FirstOrDefaultAsync (e =>e.IdOferta ==id);

            if (oferta == null){
                return NotFound ();
            }
            return oferta;
        }
        //Post: Api/Oferta
        [HttpPost]
        public async Task<ActionResult<Oferta>> Post (Oferta oferta){
            try{
                await _contexto.AddAsync (oferta);

                await _contexto.SaveChangesAsync();
                

                }catch (DbUpdateConcurrencyException){
                    throw;
            }
            return oferta;
        }
        //Put: Api/Oferta
        [HttpPut ("{id}")]
        public async Task<ActionResult> Put (int id, Oferta oferta){
            if(id != oferta.IdOferta){
                
                return BadRequest ();
            }
            _contexto.Entry (oferta).State = EntityState.Modified;
            try{
                await _contexto.SaveChangesAsync ();
            }catch (DbUpdateConcurrencyException){
                var oferta_valido = await _contexto.Receita.FindAsync (id);

                if(oferta_valido == null) {
                    return NotFound ();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
         // DELETE api/Oferta/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Oferta>> Delete(int id){

            var oferta = await _contexto.Oferta.FindAsync(id);
            if(oferta == null){
                return NotFound();
            }

            _contexto.Oferta.Remove(oferta);
            await _contexto.SaveChangesAsync();

            return oferta;
        }  
    }
}