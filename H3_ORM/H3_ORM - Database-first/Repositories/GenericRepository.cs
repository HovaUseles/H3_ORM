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
        private LibraryManagementDatabaseFirstContext _context;
        public GenericRepository()
        {
            _context = new LibraryManagementDatabaseFirstContext();
        }

        public T Add(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public T Delete(object id)
        {
            T model = _context.Find<T>(id);
            if (model == null)
            {
                throw new KeyNotFoundException($"Could not find model of type {typeof(T).Name} key: {id}");
            }

            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public T[] GetAll()
        {
            return _context.Set<T>().ToArray();
        }

        public T GetById(object id)
        {
            return _context.Find<T>(id);
        }

        public T Update(T modelChanges)
        {
            _context.Attach(modelChanges);
            _context.Entry(modelChanges).State = EntityState.Modified;
            _context.SaveChanges();
            return modelChanges;
        }
    }
}
