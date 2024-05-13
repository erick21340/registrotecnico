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

        private async Task<bool> Insertar(tecnicos tecnicos)
        {
            _contexto.Add(tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(tecnicos tecnicos)
        {
            _contexto.Update(tecnicos);
            var guardado = await _contexto.SaveChangesAsync() > 0;
            _contexto.tecnicos!.Entry(tecnicos).State = EntityState.Detached;
            return guardado;
        }

        public async Task<bool> Eliminar(tecnicos tecnicos)
        {
            var cantidad = await _contexto.tecnicos
                .Where(c => c.TecnicosId == tecnicos.TecnicosId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
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
            if (!await Existe(tecnicos.TecnicosId))
            {
                return await Insertar (tecnicos);
            }
            else
            {
                return await Modificar(tecnicos);
            }
        }
    }
}
