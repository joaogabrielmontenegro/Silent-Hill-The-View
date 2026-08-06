using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float mouseSensitivity = 150f;
    [SerializeField] private float keyboardSensitivity = 100f;

    [Header("Configurações de Zoom")]
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float minZoom = 20f; // Visão aproximada
    [SerializeField] private float maxZoom = 90f; // Visão normal (Field of View padrão)

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera cam;

    void Start()
    {
        // Instancia a referência do componente Camera que está neste mesmo objeto
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // --- 1. ROTAÇÃO (PAN) VIA TECLADO E MOUSE ---

        // Captura o input do teclado (Setas ou WASD)
        float hKeyboard = Input.GetAxis("Horizontal") * keyboardSensitivity * Time.deltaTime;
        float vKeyboard = Input.GetAxis("Vertical") * keyboardSensitivity * Time.deltaTime;

        float mouseX = 0f;
        float mouseY = 0f;

        // O botão 0 é o clique esquerdo. Só roda a câmera com o mouse se estiver clicando e arrastando.
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        // Acumula os valores de entrada nos eixos
        yRotation += mouseX + hKeyboard;
        xRotation -= (mouseY + vKeyboard);

        // Trava o eixo X (vertical) para o jogador não quebrar o pescoço dando 360º para cima
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplica a rotação matemática ao Transform da Câmera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


        // --- 2. ZOOM VIA SCROLL DO MOUSE ---

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            cam.fieldOfView -= scroll * zoomSpeed;
            // Trava o Field of View para a tela não virar do avesso
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        }
    }
}