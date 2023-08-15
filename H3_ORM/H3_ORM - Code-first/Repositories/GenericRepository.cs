using H3_ORM___Code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace H3_ORM___Code_first.Repositories;

internal class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private AppDbContext context;

    public GenericRepository(AppDbContext context)
    {
        this.context = context;
    }

    public T GetById(object id)
    {
        T? model = context.Find<T>(id);

        if (model == null)
            throw new KeyNotFoundException($"Could not find {id}");

        return model;
    }

    public T[] GetAll()
    {
        return context.Set<T>().ToArray();
    }

    public T Add(T model)
    {
        context.Add(model);
        context.SaveChanges();

        return model;
    }

    public T Update(T model)
    {
        context.Attach(model);
        context.Entry(model).State = EntityState.Modified;
        context.SaveChanges();

        return model;
    }

    public T Delete(T id)
    {
        T? model = context.Find<T>(id);

        if (model == null)
            throw new KeyNotFoundException($"Could not find {id}");

        context.Remove(model);
        context.SaveChanges();

        return model;
    }
}
