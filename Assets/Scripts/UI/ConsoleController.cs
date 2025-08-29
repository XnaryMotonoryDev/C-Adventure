using UnityEngine;

public class ConsoleController : Pause
{
    [SerializeField] private GameObject console;
    [SerializeField] private KeyCode consoleKey = KeyCode.T;

    private bool _isShow;

    void Update()
    {
        if (Input.GetKeyDown(consoleKey))
            _isShow = !_isShow;

        console.SetActive(_isShow);
        GamePause(_isShow);

    }
}
