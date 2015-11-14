namespace Chance.Storage
{
    interface IStore<T> where T : IStorable
    {
        T get(int id);
        bool put(T storable);
    }
}
