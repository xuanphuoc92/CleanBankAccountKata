namespace CleanBankAccountKata.DataInterfaces
{
    public interface IDataAccess<TObject, TKey>
    {
        public int Count { get; }
        public TObject Load(TKey key);
        public void Save(TObject objectToSave);
    }
}