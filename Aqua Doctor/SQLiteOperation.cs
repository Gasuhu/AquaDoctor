
using SQLite;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Aqua_Doctor
{
    class SQLiteOperation : IDisposable
    {
        private static readonly ConcurrentDictionary<string, object> LockDictionary;
        private readonly object _lockObject;

        private readonly SQLiteConnection _context;
        static SQLiteOperation()
        {
            LockDictionary = new ConcurrentDictionary<string, object>();
        }

        public SQLiteOperation(string dbPath)
        {
            _lockObject = LockDictionary.GetOrAdd(dbPath, _lock => new object());

            lock (_lockObject)
            {
                _context = new SQLiteConnection(dbPath);
            }
        }



        public void Insert<T>(T data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.Insert(data);
            }

        }

        public void InsertAll<T>(List<T> data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.InsertAll(data);
            }
        }

        public void Update<T>(T data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.Update(data);
            }
        }

        public void UpdateAll<T>(List<T> data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.UpdateAll(data);
            }
        }

        public void InsertOrUpdate<T>(T data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.InsertOrReplace(data);
            }
        }

        public void Delete<T>(T data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.Delete(data);
            }
        }


        public void DeleteAll<T>(List<T> data) where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                _context.DeleteAll<T>();
            }
        }

        public List<T> Get<T>() where T : class, new()
        {
            lock (_lockObject)
            {
                _context.CreateTable<T>();
                return _context.Table<T>().ToList();
 
            }
        }


        public void Dispose() => GC.SuppressFinalize(this);




    }


   
}
