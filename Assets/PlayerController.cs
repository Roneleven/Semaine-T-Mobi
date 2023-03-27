using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector2 fingerDown;
    private Vector2 fingerUp;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        InputAction moveAction = new InputAction("Move", InputActionType.Value, "<Gamepad>/leftStick/x");
        moveAction.AddBinding("<Keyboard>/leftArrow");
        moveAction.AddBinding("<Keyboard>/rightArrow");
        moveAction.Enable();
        //moveAction.performed += OnMove;
    }

    private void Update()
    {
        // set movement direction based on horizontal input and move speed
        float horizontalInput = Gamepad.current != null ? Gamepad.current.leftStick.x.ReadValue() : 0f;
        moveDirection = new Vector3(horizontalInput * moveSpeed, 0f, moveSpeed);

        // move the player using the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        float horizontalInput = value.Get<float>();
        moveDirection = new Vector3(horizontalInput * moveSpeed, 0f, moveSpeed);
    }

    private void OnSwipe(InputAction.CallbackContext context)
    {
        fingerUp = context.ReadValue<Vector2>();
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        if (fingerUp.x < fingerDown.x)
        {
            // swipe left
            moveDirection = new Vector3(-moveSpeed, 0f, moveSpeed);
        }
        else if (fingerUp.x > fingerDown.x)
        {
            // swipe right
            moveDirection = new Vector3(moveSpeed, 0f, moveSpeed);
        }
    }

    public void OnPointerDown(InputValue value)
    {
        fingerDown = value.Get<Vector2>();
    }

    public void OnPointerUp(InputValue value)
    {
        fingerUp = value.Get<Vector2>();
        CheckSwipe();
    }
}
