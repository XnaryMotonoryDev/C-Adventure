public interface IInteractable
{
    int GetID();
    string GetInfo();
}

public interface IUse
{
    void OnUse();
}

public interface IConnect
{
    void OnConnection();
}

public interface IFind
{
    void OnFind();
}