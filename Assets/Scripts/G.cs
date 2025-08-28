using UnityEngine;

public class G : MonoBehaviour
{
    public static G instance;

    [SerializeField] private MonoBehaviour[] scripts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public void DoGravity(ref Vector3 velocity, float gravity)
    {
        velocity.y += gravity * Time.deltaTime;
    }

    private void DisableScr(MonoBehaviour scr, bool state) => scr.enabled = !state;

    public void FreezePlayer(bool freeze)
    {
        foreach (var script in scripts)
        {
            DisableScr(script, freeze);
        }
    }
}
