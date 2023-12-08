using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ������
    public float jumpForce = 10f; // ���� ������
    private bool isGrounded; // ���������� �������� ���������������

    private Rigidbody2D rb;
    private Collider2D coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // �������� ���������������
        isGrounded = Physics2D.IsTouchingLayers(coll, LayerMask.GetMask("Ground"));

        Move();
        Jump();
    }

    private void Move()
    {
        // �������� -/+
        float horizontalInput = Input.GetAxis("Horizontal");

        // ������ ��������
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // ��������� �������� � Rb
        rb.velocity = movement;

    }

    private void Jump()
    {
        // ������ ������ ������ ��� ��� � �� ����� �� �����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ���� ������ �� ���������
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}