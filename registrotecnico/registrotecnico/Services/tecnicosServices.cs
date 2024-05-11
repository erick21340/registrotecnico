using Microsoft.EntityFrameworkCore;
using registrotecnico.DAL;
using registrotecnico.Models;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace registrotecnico.Services
{
    public class tecnicosServices
    {
        private readonly Contexto _contexto;
        public tecnicosServices(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<bool> Existe(int tecnicosid)
        {
            return await _contexto.tecnicos!.AnyAsync(t => t.TecnicosId == tecnicosid);
        }

        public async Task<bool> Insertar(tecnicos tecnicos)
        {
            _contexto.Add(tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(tecnicos tecnicos)
        {
            _contexto.Update(tecnicos);
            var guardado = await _contexto.SaveChangesAsync() > 0;
            _contexto.tecnicos!.Entry(tecnicos).State = EntityState.Detached;
            return guardado;
        }

        public async Task<bool> Eliminar(tecnicos tecnicos)
        {
            return await _contexto.tecnicos!.AsNoTracking().Where(t => t.TecnicosId == tecnicos.TecnicosId).ExecuteDeleteAsync() > 0;
        }

        public async Task<tecnicos?> Buscar(int tecnicoID)
        {
            return await _contexto.tecnicos!.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicosId ==tecnicoID );
        }

        public async Task<List<tecnicos>> Listar(Expression<Func<tecnicos, bool>> criterio)
        {
            return await _contexto.tecnicos!.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Guardar(tecnicos tecnicos)
        {
            if (await Existe(tecnicos.TecnicosId))
            {
                return await Modificar(tecnicos);
            }
            else
            {
                return await Insertar(tecnicos);
            }
        }
    }
}
