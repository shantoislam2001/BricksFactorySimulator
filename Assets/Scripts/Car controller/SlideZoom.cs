using UnityEngine;
using UnityEngine.EventSystems;

public class SlideZoom : MonoBehaviour
{
    public Camera carCamera;
    public RectTransform slidingPanel;

    public float lookSpeed = 0.2f;
    public float minYAngle = -45f; // Minimum vertical rotation angle
    public float maxYAngle = 45f;  // Maximum vertical rotation angle

    private Vector2 lastTouchPosition;
    private float currentYRotation = 0f;

    void Start()
    {
        if (carCamera == null)
        {
            carCamera = Camera.main;
        }
    }

    void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 1 && IsTouchOverPanel())
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - lastTouchPosition;
                RotateCamera(delta);
                lastTouchPosition = touch.position;
            }
        }
    }

    private void RotateCamera(Vector2 delta)
    {
        float yRotation = delta.y * lookSpeed;
        currentYRotation = Mathf.Clamp(currentYRotation - yRotation, minYAngle, maxYAngle);

        carCamera.transform.localEulerAngles = new Vector3(currentYRotation, carCamera.transform.localEulerAngles.y + delta.x * lookSpeed, 0f);
    }

    private bool IsTouchOverPanel()
    {
        Touch touch = Input.GetTouch(0);
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = touch.position;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.transform.IsChildOf(slidingPanel))
                return true;
        }

        return false;
    }
}
