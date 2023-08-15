using H3_ORM___Database_first.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Database_first.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        public LibraryManagementDataBaseFirstContext _context;
        public GenericRepository(LibraryManagementDataBaseFirstContext context)
        {
            _context = context;
        }

        public virtual T Add(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public virtual T Delete(object id)
        {
            // Trying to find the entity by using the generic find method in Entity Framework
            T model = _context.Find<T>(id);
            if (model == null)
            {
                throw new KeyNotFoundException($"Could not find model of type {typeof(T).Name} key: {id}");
            }

            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public virtual T[] GetAll()
        {
            return _context.Set<T>().ToArray();
        }

        public virtual T GetById(object id)
        {
            // Trying to find the entity by using the generic find method in Entity Framework
            T model = _context.Find<T>(id);
            if (model == null)
            {
                throw new KeyNotFoundException($"Could not find model of type {typeof(T).Name} key: {id}");
            }
            return  model;
        }

        public virtual T Update(T modelChanges)
        {
            _context.Attach<T>(modelChanges);
            _context.Entry<T>(modelChanges).State = EntityState.Modified;
            _context.SaveChanges();
            return modelChanges;
        }
    }
}
