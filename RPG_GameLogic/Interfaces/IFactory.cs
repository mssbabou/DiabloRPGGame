namespace RPG_GameLogic.Interfaces
{
    public interface IFactory<T>
    {
        T Create(string type);
    }
}