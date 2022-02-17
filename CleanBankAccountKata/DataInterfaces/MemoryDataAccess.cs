using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    class MemoryDataAccess<TObject, TKey> : IDataAccess<TObject, TKey>
    {
        private Dictionary<TKey, TObject> keyValues = new Dictionary<TKey, TObject>();
        private Func<TObject, TKey> keyFunc;

        public MemoryDataAccess(Func<TObject, TKey> keyFunc)
        {
            this.keyFunc = keyFunc;
        }

        public int Count => keyValues.Count;

        public void Save(TObject objectToSave)
        {
            TKey key = keyFunc(objectToSave);
            if (keyValues.ContainsKey(key))
                keyValues[key] = objectToSave;
            else
                keyValues.Add(key, objectToSave);
        }

        public TObject Load(TKey key)
        {
            if (keyValues.ContainsKey(key))
                return keyValues[key];
            return default(TObject);
        }
    }
}
