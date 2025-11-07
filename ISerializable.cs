namespace AppConsole
{
    interface ISerializable<T>
    {
        string Serialize(T obj);
        T Deserialize(string obj);
    }
}