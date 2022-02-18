using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBankAccountKata.DataInterfaces
{
    public class DataAccessFactory<TObject, TKey>
    {
        public static IDataAccess<TObject, TKey> Get(Func<TObject, TKey> keyFunc)
        {
            return new MemoryDataAccess<TObject, TKey>(keyFunc);
        }
    }
}
