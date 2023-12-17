using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static Vector2 viewDirection = Vector2.right;
    public float moveSpeed = 5f;
    public float dashForce = 30f;
    public float minJumpHeight = 2f;
    public float maxJumpHeight = 3f;
    public float maxJumpHoldTime = 1.0f;

    private bool isGrounded;
    private Player player;
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool isJumping = false;
    private float jumpStartTime;

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(coll, LayerMask.GetMask("Ground"));

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpStartTime = Time.time;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        {
            isJumping = true;
            jumpStartTime = Time.time;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        // Использование умений

        // Не хочу ебаться с тем, как это сделать красивее, полиморфизм идет НАХУЙ
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.CastSkill(player.skillSlots[0]);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.CastSkill(player.skillSlots[1]);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.CastSkill(player.skillSlots[2]);
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (isJumping)
        {
            Jump();
        }
        viewDirection = new Vector2(movement.x, 0).normalized;
    }

    void Jump()
    {
        if (Time.time - jumpStartTime < maxJumpHoldTime)
        {
            float jumpHeight = Mathf.Lerp(minJumpHeight, maxJumpHeight, Mathf.Clamp01((Time.time - jumpStartTime) / maxJumpHoldTime));
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        else
        {
            isJumping = false;
        if (Time.time - jumpStartTime < maxJumpHoldTime)
        {
            float jumpHeight = Mathf.Lerp(minJumpHeight, maxJumpHeight, Mathf.Clamp01((Time.time - jumpStartTime) / maxJumpHoldTime));
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    void Dash()
    {
        if (isGrounded)
        {
            rb.freezeRotation = false;
            rb.AddForce(Vector2.down * 15f, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x + dashForce, rb.velocity.y);
            rb.freezeRotation = true;
        }
    }
}
