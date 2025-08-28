using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool SetMouse
    {
        set
        {
            Cursor.visible = value;
            Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public float SetGameTime { set => Time.timeScale = value; }

    public void GamePause(bool state)
    {
        SetMouse = state;
        SetGameTime = state ? 0 : 1;
        G.instance.FreezePlayer(state);
    }
}