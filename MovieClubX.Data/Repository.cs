using Microsoft.EntityFrameworkCore.Storage;
using MovieClubX.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace MovieClubX.Data
{
    public class Repository<T> where T : class, IIdEntity
    {
        MovieClubContext ctx;
        public Repository(MovieClubContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task CreateAsync(T item)
        {
            ctx.Set<T>().Add(item);
            await ctx.SaveChangesAsync();
        }
        public async Task CreateManyAsync(IEnumerable<T> items)
        {
            ctx.Set<T>().AddRange(items);
            await ctx.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var item = GetById(id);
            ctx.Set<T>().Remove(item);
            await ctx.SaveChangesAsync();
        }
        public T GetById(string id)
        {
            return ctx.Set<T>().First(i => i.Id == id);
        }
        public IEnumerable<T> GetAll()
        {
            return ctx.Set<T>();

        }

        public async Task UpdateAsync(T item)
        {
            var toUpdate=GetById(item.Id);
            foreach (var props in typeof(T).GetProperties())
            {
                props.SetValue(toUpdate,props.GetValue(item));
            }
            ctx.Set<T>().Update(toUpdate);
            await ctx.SaveChangesAsync();
        }
    }
}
