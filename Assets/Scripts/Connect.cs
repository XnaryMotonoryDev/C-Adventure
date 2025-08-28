using UnityEngine;

public class ConnectCommand : MonoBehaviour, ICommand
{
    private GameObject _target;

    public ConnectCommand(GameObject target)
    {
        _target = target;
    }

    public void Execute()
    {
        
    }
}