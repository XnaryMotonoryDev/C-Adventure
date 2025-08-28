using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Camera interCam;
    [SerializeField] private LayerMask interMask;
    
    [SerializeField, Range(1, 10)] private float interDistance = 5f;

    private void Update()
    {
        CheckInteract();
    }

    private void CheckInteract()
    {
        Ray ray = new Ray(interCam.transform.position, interCam.transform.forward);
        RaycastHit hit;

        var isHit = Physics.Raycast(ray, out hit, interDistance, interMask);

        if (isHit)
        {
            if (Input.GetKeyDown(KeyCode.E))
                hit.transform.GetComponent<IInterectable>().Interact();
        }

    }
}