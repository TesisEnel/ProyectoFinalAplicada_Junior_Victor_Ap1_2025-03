using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class AbonosService(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Abono.AnyAsync(a => a.AbonoId == id);
    }

    public async Task<Abono?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Abono
            .Include(a => a.Cliente) // Incluimos Cliente por si necesitas ver el nombre
            .FirstOrDefaultAsync(a => a.AbonoId == id);
    }

    public async Task<List<Abono>> Listar(Expression<Func<Abono, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Abono
            .Include(a => a.Cliente)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Insertar(Abono abono)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Abono.Add(abono);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Abono abono)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(abono);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Abono abono)
    {
        if (!await Existe(abono.AbonoId))
        {
            return await Insertar(abono);
        }
        else
        {
            return await Modificar(abono);
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var abono = await contexto.Abono.FindAsync(id);

        if (abono != null)
        {
            contexto.Abono.Remove(abono);
            return await contexto.SaveChangesAsync() > 0;
        }
        return false;
    }
}