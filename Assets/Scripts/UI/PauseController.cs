using UnityEngine;

public class PauseController : Pause
{
    private bool _isPause;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _isPause = !_isPause;

        GamePause(_isPause);
    }
}