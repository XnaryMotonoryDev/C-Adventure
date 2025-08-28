using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _playerCamera;

    [SerializeField] private Transform player;

    [SerializeField, Range(0, 10)] private float sensitivity = 5f;

    private float _rotationX, _rotationY;

    private void Start() => _playerCamera = GetComponent<Camera>();

    private void Update() => CameraMove();

    private void CameraMove()
    {
        _rotationX += Input.GetAxis("Mouse X") * sensitivity;
        _rotationY += Input.GetAxis("Mouse Y") * sensitivity;

        _rotationY = Mathf.Clamp(_rotationY, -90, 90);

        _playerCamera.transform.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0);
        player.transform.rotation = Quaternion.Euler(0, _rotationX, 0);
    }
}
