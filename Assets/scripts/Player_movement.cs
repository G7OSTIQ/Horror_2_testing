using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))] //so this are used for character movement this is requird for new updated issue

public class Player_movement : MonoBehaviour
{

    [SerializeField] private float speed = 5f;  //Serializedfield is there so that we can see it from the inprector and unity
    [SerializeField] private float mouseSensitivity = 0.1f; //how fast the camera turns when the mouse moves
    [SerializeField] private float maxLookAngle = 80f; //how far the player can look up and down

    private CharacterController controller;
    private Transform cameraTransform;

    private Vector2 input; //vector2 is for x and y and vector3 is zxy
    private Vector2 lookInput; //how much the mouse moved
    private float cameraPitch = 0f; //the current up and down angle of the camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform; //finds the camera inside the player

        //hides the mouse and keeps it in the middle of the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Move();
    }

    private void Look()
    {
        //left and right turns the whole player
        transform.Rotate(0f, lookInput.x * mouseSensitivity, 0f);

        //up and down only tilts the camera, Clamp stops it from flipping over
        cameraPitch -= lookInput.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    private void Move()
    {
        //transform.right and transform.forward make WASD follow where the player is facing
        Vector3 movement = transform.right * input.x + transform.forward * input.y;
        controller.Move(movement * Time.deltaTime);
    }

    //recive by da playerinput componet (aka from the player componet list) when WASD is pressed.
    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>() * speed;
    }

    //recive by da playerinput componet when the mouse moves.
    private void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
