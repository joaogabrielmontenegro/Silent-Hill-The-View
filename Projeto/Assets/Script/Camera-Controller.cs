using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float mouseSensitivity = 150f;
    [SerializeField] private float keyboardSensitivity = 100f;

    [Header("Configurações de Zoom")]
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float minZoom = 20f;
    [SerializeField] private float maxZoom = 90f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
       
        float hKeyboard = Input.GetAxis("Horizontal") * keyboardSensitivity * Time.deltaTime;

        float mouseX = 0f;
        float mouseY = 0f;

       
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        
        yRotation += mouseX + hKeyboard;
        xRotation -= mouseY;

       
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

       
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            cam.fieldOfView -= scroll * zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        }
    }
}