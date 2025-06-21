using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClientes.Data;
using ApiClientes.Models;

namespace ApiClientes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
    {
        return await _context.Clientes.ToListAsync();
    }

    // GET: api/clientes/count
    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCount()
    {
        return await _context.Clientes.CountAsync();
    }

    // GET: api/clientes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();
        return cliente;
    }

    // GET: api/clientes/search?name=João
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetByName(string name)
    {
        return await _context.Clientes
            .Where(c => c.Nome.Contains(name))
            .ToListAsync();
    }

    // PUT: api/clientes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/clientes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}