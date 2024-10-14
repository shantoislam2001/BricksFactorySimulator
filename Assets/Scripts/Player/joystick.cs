using UnityEngine;
using UnityEngine.UI;

public class SlideAxisController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float lookSensitivity = 2f;  // Sensitivity of the look axis

    public Joystick joystick;  // Reference to the joystick
    public RectTransform slideAreaRect;  // Reference to the slide area UI element
    public float minVerticalAngle = -30f;  // Minimum vertical angle limit
    public float maxVerticalAngle = 60f;   // Maximum vertical angle limit

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 deltaTouchPosition;
    private bool isDragging = false;
    private int slideAxisTouchID = -1;  // Track the touch ID for the slide axis
    private float currentCameraVerticalAngle = 0f;  // Track current vertical angle

    void Update()
    {
        // Handle movement using joystick
        Vector3 moveDirection = transform.forward * joystick.Vertical + transform.right * joystick.Horizontal;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Handle touch input for slide axis
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && slideAxisTouchID == -1)
            {
                // Check if the touch is within the defined slide area (UI Panel)
                if (RectTransformUtility.RectangleContainsScreenPoint(slideAreaRect, touch.position))
                {
                    startTouchPosition = touch.position;
                    isDragging = true;
                    slideAxisTouchID = touch.fingerId;  // Track this touch ID
                }
            }

            if (touch.fingerId == slideAxisTouchID)
            {
                if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    currentTouchPosition = touch.position;
                    deltaTouchPosition = currentTouchPosition - startTouchPosition;

                    // Horizontal rotation for the player
                    float rotateHorizontal = deltaTouchPosition.x * lookSensitivity * Time.deltaTime;
                    transform.Rotate(0f, rotateHorizontal, 0f);

                    // Vertical rotation for the camera
                    float rotateVertical = -deltaTouchPosition.y * lookSensitivity * Time.deltaTime;

                    // Clamp the vertical angle to prevent over-rotation
                    currentCameraVerticalAngle = Mathf.Clamp(
                        currentCameraVerticalAngle + rotateVertical,
                        minVerticalAngle,
                        maxVerticalAngle
                    );

                    // Apply the clamped vertical rotation to the camera
                    Camera.main.transform.localEulerAngles = new Vector3(
                        currentCameraVerticalAngle,
                        Camera.main.transform.localEulerAngles.y,
                        0f
                    );

                    startTouchPosition = currentTouchPosition;
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isDragging = false;
                    slideAxisTouchID = -1;  // Reset the touch ID
                }
            }
        }
    }
}
