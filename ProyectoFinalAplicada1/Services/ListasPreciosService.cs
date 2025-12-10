using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class ListasPreciosService(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ListaPrecio.AnyAsync(l => l.ListaPrecioId == id);
    }

    public async Task<ListaPrecio?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

       
        return await contexto.ListaPrecio
            .Include(l => l.Detalles)
            .ThenInclude(d => d.Producto)
            .AsNoTracking() 
            .FirstOrDefaultAsync(l => l.ListaPrecioId == id);
    }

    public async Task<List<ListaPrecio>> Listar(Expression<Func<ListaPrecio, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ListaPrecio
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Insertar(ListaPrecio lista)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.ListaPrecio.Add(lista);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(ListaPrecio lista)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        
        var listaActual = await contexto.ListaPrecio
            .Include(l => l.Detalles)
            .FirstOrDefaultAsync(l => l.ListaPrecioId == lista.ListaPrecioId);

        if (listaActual != null)
        {
            
            listaActual.Nombre = lista.Nombre;
            listaActual.Activa = lista.Activa;


            contexto.Set<ListaPrecioDetalle>().RemoveRange(listaActual.Detalles);

           
            foreach (var detalle in lista.Detalles)
            {
                
                listaActual.Detalles.Add(new ListaPrecioDetalle
                {
                    ProductoId = detalle.ProductoId,
                    PrecioMayorista = detalle.PrecioMayorista
                });
            }

           
            return await contexto.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<bool> Guardar(ListaPrecio lista)
    {
        if (!await Existe(lista.ListaPrecioId))
        {
            return await Insertar(lista);
        }
        else
        {
            return await Modificar(lista);
        }
    }

    
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var lista = await contexto.ListaPrecio.FindAsync(id);

        if (lista != null)
        {
            contexto.ListaPrecio.Remove(lista); 
            return await contexto.SaveChangesAsync() > 0;
        }
        return false;
    }
}