using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private GameObject _tractorBeam;
    [SerializeField] private Transform _rotateContainer;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _acceleration = 20;
    [SerializeField] private float _rotateSpeed = 10;
    private Vector2 _direction;
    private InputAction _moveAction;
    private InputAction _enableTractorAction;
    private InputAction _swapTractorAction;
    private Rigidbody2D _rb;
    private Vector2 _rightTarget;
    public float beamAtraction;
    public static PlayerControler instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
        _enableTractorAction = GetComponent<PlayerInput>().actions.FindAction("EnableTractor");
        _swapTractorAction = GetComponent<PlayerInput>().actions.FindAction("SwapTractor");
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _tractorBeam.SetActive(_enableTractorAction.ReadValue<float>() > .5f);
        beamAtraction = _swapTractorAction.ReadValue<float>() > .5f ? -1 : 1;
        Move();
    }

    private void Move()
    {
        _direction = Vector2.Lerp(_direction, _moveAction.ReadValue<Vector2>(), Time.fixedDeltaTime * _acceleration);
        _rb.MovePosition(_rb.position + (_direction * _moveSpeed * Time.fixedDeltaTime));
        _rotateContainer.right = Vector2.Lerp(_rotateContainer.right, _rightTarget, Time.fixedDeltaTime * _rotateSpeed);
    }

    private void OnLook(InputValue value)
    {
        Vector2 newRight = value.Get<Vector2>().normalized;
        if (newRight == Vector2.zero) return;
        _rightTarget = newRight;
    }
}
