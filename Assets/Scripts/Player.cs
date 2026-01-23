using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Capturar el input del jugador usando detección directa de teclas
        movement.x = 0f;
        movement.y = 0f;

        if (Input.GetKey(KeyCode.W)) movement.y = 1f;
        if (Input.GetKey(KeyCode.S)) movement.y = -1f;
        if (Input.GetKey(KeyCode.A)) movement.x = -1f;
        if (Input.GetKey(KeyCode.D)) movement.x = 1f;

        // Normalizar el vector para evitar movimiento más rápido en diagonal
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
    }

    void FixedUpdate()
    {
        // Mover al jugador usando física
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
