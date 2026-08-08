using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Visão Inicial")]
    public float initialRotationY = 180f; // Direção horizontal inicial (gira em torno do próprio eixo)
    public float initialRotationX = 0f;   // Inclinação vertical inicial (olhar para cima/baixo)

    [Header("Sensibilidade do Giro (Pan)")]
    public float sensitivity = 0.1f;

    [Header("Configurações de Zoom")]
    public float zoomSpeed = 5f;
    public float minFOV = 30f;
    public float maxFOV = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null) cam = Camera.main;

        // Aplica a rotação inicial configurada
        rotationX = initialRotationY;
        rotationY = initialRotationX;
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }

    void Update()
    {
        // --- GIRO DA CÂMERA (PAN) ---
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();

            rotationX += delta.x * sensitivity;
            rotationY -= delta.y * sensitivity;

            rotationY = Mathf.Clamp(rotationY, -85f, 85f);

            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
        }

        // --- ZOOM VIA SCROLL DO MOUSE ---
        if (Mouse.current != null && cam != null)
        {
            float scroll = Mouse.current.scroll.ReadValue().y;

            if (Mathf.Abs(scroll) > 0.01f)
            {
                cam.fieldOfView -= Mathf.Sign(scroll) * zoomSpeed;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
            }
        }
    }
}