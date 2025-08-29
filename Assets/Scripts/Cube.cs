using UnityEngine;

public class Cube : MonoBehaviour, IInteractable
{
    [SerializeField] private int id;

    private void Start()
    {
        ScannerManager.Instance.RegisterInteractable(this);
    }

    public int GetID() => id;
    
    public string GetInfo() => gameObject.name;
}