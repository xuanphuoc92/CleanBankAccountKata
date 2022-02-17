using CleanBankAccountKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    class MemoryDataAccess<TObject, TKey>
    {
        private Dictionary<TKey, TObject> keyValues = new Dictionary<TKey, TObject>();
        private Func<TObject, TKey> keyFunc;

        public MemoryDataAccess(Func<TObject, TKey> keyFunc)
        {
            this.keyFunc = keyFunc;
        }

        internal int Count => keyValues.Count;

        internal void Save(TObject objectToSave)
        {
            TKey key = keyFunc(objectToSave);
            if (keyValues.ContainsKey(key))
                keyValues[key] = objectToSave;
            else
                keyValues.Add(key, objectToSave);
        }

        internal TObject Load(TKey key)
        {
            if (keyValues.ContainsKey(key))
                return keyValues[key];
            return default(TObject);
        }
    }
}
