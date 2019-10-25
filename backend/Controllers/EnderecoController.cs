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

    public class EnderecoController : ControllerBase {
    fastradeContext _contexto = new fastradeContext ();

    //GET: api/Endereco
    [HttpGet]
    public async Task<ActionResult<List<Endereco>>> Get () {

        var Enderecos = await _contexto.Endereco.ToListAsync ();

        if(Enderecos == null){
            return NotFound ();
        }

        return Enderecos;
        
    }
    //GET: api/Endereco/2
    [HttpGet ("{id}")]
    public async Task<ActionResult<Endereco>> Get (int id){

        var Enderecos = await _contexto.Endereco.FindAsync (id);
        if(Enderecos == null){
            return NotFound ();
        }
        return Enderecos;
    }

    //POST api/Endereco
    [HttpPost]
    public async Task<ActionResult<Endereco>> Post (Endereco endereco) {

        try{
            //tratamos contra ataques de SQL Injection
            await _contexto.AddAsync (endereco);

            //Salvamos efetivamente o nosso objeto no banco de dados
            await _contexto.SaveChangesAsync ();
        }catch (DbUpdateConcurrencyException){
            throw;
        }
        return endereco;
    }
    [HttpPut ("{id}")]
    public async Task<ActionResult> Put (int id, Endereco endereco){

        //Se o id do objeto não existir
        //ele retorna erro 401

        if(id != endereco.IdEndereco){
            return BadRequest ();
        }
        //comparamos os atributos que foram modificado atraves do EF
        _contexto.Entry (endereco).State = EntityState.Modified;

        try{
            await _contexto.SaveChangesAsync();
       
        }catch(DbUpdateConcurrencyException){
            //verificamos se o objeto inserido realmente existe no banco
            var endereco_valido = await _contexto.Endereco.FindAsync (id);

            if(endereco_valido == null){
                return NotFound();

            }else{
                throw;
            }
        }
        //Nocontent = Retorna 204, sem nada
        return NoContent ();
        
    }
    //DELETE api/endereco/id
    [HttpDelete ("{id}")]

    public async Task<ActionResult<Endereco>> Delete (int id){

        var endereco = await _contexto.Endereco.FindAsync(id);
        if(endereco == null){
            return NotFound();
        }
        _contexto.Endereco.Remove(endereco);
        await _contexto.SaveChangesAsync();

        return endereco;
    }      
    }
}
