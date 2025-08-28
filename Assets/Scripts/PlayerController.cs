using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IControllable
{
    private const float GRAVITY = -9.81f;

    private CharacterController _controller;
    private Vector3 _direction, _velocity;

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float checkRadius = 0.5f;

    private bool _isGround, _canJump;

    private void Start() => _controller = GetComponent<CharacterController>();

    private void Update()
    {
        _direction = GetDirection();
        _isGround = CheckGround();
        G.instance.DoGravity(ref _velocity, GRAVITY);

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;
        
        _controller.Move(_velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            _canJump = true;
    }

    private void FixedUpdate()
    {
        Move(_direction);

        if (_canJump)
        {
            Jump();
            _canJump = false;
        }
    }

    private Vector3 GetDirection()
    {
        var horMove = Input.GetAxis("Horizontal");
        var vertMove = Input.GetAxis("Vertical");

        var direction = new Vector3(horMove, 0, vertMove);
        direction = transform.TransformDirection(direction);
        return direction.normalized;
    }

    private bool CheckGround()
    {
        return Physics.CheckSphere(groundChecker.position, checkRadius, groundMask);
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
        _controller.Move(_direction * speed * Time.deltaTime);
    }

    public void Jump()
    {
        var jumpForce = Mathf.Sqrt(-2 * GRAVITY * jumpHeight);
        _velocity.y += jumpForce;
    }
}