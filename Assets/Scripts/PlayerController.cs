using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость игрока
    public float jumpForce = 10f; // Сила прыжка
    private bool isGrounded; // Переменная проверки соприкосновения

    private Rigidbody2D rb;
    private Collider2D coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Проверка соприкосновений
        isGrounded = Physics2D.IsTouchingLayers(coll, LayerMask.GetMask("Ground"));

        Move();
        Jump();
    }

    private void Move()
    {
        // Горизонт -/+
        float horizontalInput = Input.GetAxis("Horizontal");

        // Вектор движения
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Применяес движение к Rb
        rb.velocity = movement;

    }

    private void Jump()
    {
        // Нажата кнопка прыжка или нет и на земле ли игрок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Сила прыжка по вертикали
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}