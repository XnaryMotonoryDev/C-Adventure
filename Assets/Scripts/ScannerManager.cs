using System.Collections.Generic;
using UnityEngine;

public class ScannerManager : MonoBehaviour
{
    public static ScannerManager Instance;

    private Dictionary<int, IInteractable> _interactables = new Dictionary<int, IInteractable>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void RegisterInteractable(IInteractable interactable)
    {
        _interactables[interactable.GetID()] = interactable;
        Debug.Log($"Зарегеcтрирован новый объект: {_interactables[interactable.GetID()]}");
    }

    public List<int> GetAll() => new List<int>(_interactables.Keys);
}