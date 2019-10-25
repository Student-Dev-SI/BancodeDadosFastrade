using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_fastread.Controllers
{

//Definimos nossa rota do controller e dizemos que é um controller de API
[Route ("api/[controller]")]
[ApiController]
    public class TipoUsuarioController : ControllerBase {
    fastradeContext _contexto = new fastradeContext ();

    //GET: api/TipoUsuario
    [HttpGet]
    public async Task<ActionResult<List<TipoUsuario>>> Get () {

        var TipoUsuarios = await _contexto.TipoUsuario.ToListAsync ();

        if(TipoUsuarios == null){
            return NotFound ();
        }

        return TipoUsuarios;
        
    }
    //GET: api/TipoUsuario/2
    [HttpGet ("{id}")]
    public async Task<ActionResult<TipoUsuario>> Get (int id){

        var TipoUsuarios = await _contexto.TipoUsuario.FindAsync (id);
        if(TipoUsuarios == null){
            return NotFound ();
        }
        return TipoUsuarios;
    }

    //POST api/TipoUsuario
    [HttpPost]
    public async Task<ActionResult<TipoUsuario>> Post (TipoUsuario tipousuario) {

        try{
            //tratamos contra ataques de SQL Injection
            await _contexto.AddAsync (tipousuario);

            //Salvamos efetivamente o nosso objeto no banco de dados
            await _contexto.SaveChangesAsync ();
        }catch (DbUpdateConcurrencyException){
            throw;
        }
        return tipousuario;
    }
    [HttpPut ("{id}")]
    public async Task<ActionResult> Put (int id, TipoUsuario tipousuario){

        //Se o id do objeto não existir
        //ele retorna erro 401

        if(id != tipousuario.IdTipoUsuario){
            return BadRequest ();
        }
        //comparamos os atributos que foram modificado atraves do EF
        _contexto.Entry (tipousuario).State = EntityState.Modified;

        try{
            await _contexto.SaveChangesAsync();
       
        }catch(DbUpdateConcurrencyException){
            //verificamos se o objeto inserido realmente existe no banco
            var tipousuario_valido = await _contexto.TipoUsuario.FindAsync (id);

            if(tipousuario_valido == null){
                return NotFound();

            }else{
                throw;
            }
        }
        //Nocontent = Retorna 204, sem nada
        return NoContent ();
        
    }
    //DELETE api/tipousuario/id
    [HttpDelete ("{id}")]
    public async Task<ActionResult<TipoUsuario>> Delete (int id){

        var tipousuario = await _contexto.TipoUsuario.FindAsync(id);
        if(tipousuario == null){
            return NotFound();
        }
        _contexto.TipoUsuario.Remove(tipousuario);
        await _contexto.SaveChangesAsync();

        return tipousuario;
    }      
    }
}
