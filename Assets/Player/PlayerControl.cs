using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    public static Vector2 ViewDirection = Vector2.right;
    public float moveSpeed = 5f;
    public float dashForce = 30f;
    public float minJumpHeight = 2f;
    public float maxJumpHeight = 3f;
    public float maxJumpHoldTime = 1.0f;

    private bool isGrounded;
    private bool isJumping = false;
    private float jumpStartTime;
    private float[] cooldowns = new float[] { 0, 0, 0 }; //Таймер кулдаунов

    private PlayerInstance player;
    private Rigidbody2D rb;
    private Collider2D coll;

    void Start()
    {
        player = GetComponent<PlayerInstance>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(coll, LayerMask.GetMask("Ground"));
        ViewDirection = GetViewDirection();


        // Если игрок занят, его передвижение отключено. Тут своя система управления
        if (player.Talking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.ContinueDialog();
            }
        }
        else // Если игрок не занят, обычная система управления:
        {
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

            if (Input.GetKeyDown(KeyCode.Q) && player.skillSlots[0] != null)
            {
                if (Time.time - cooldowns[0] > player.skillSlots[0].Cooldown)
                {
                    player.CastSkill(player.skillSlots[0]);
                    cooldowns[0] = Time.time;
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && player.skillSlots[1] != null)
            {
                if (Time.time - cooldowns[1] > player.skillSlots[1].Cooldown)
                {
                    player.CastSkill(player.skillSlots[1]);
                    cooldowns[1] = Time.time;
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && player.skillSlots[0] != null)
            {
                if (Time.time - cooldowns[2] > player.skillSlots[2].Cooldown)
                {
                    player.CastSkill(player.skillSlots[2]);
                    cooldowns[2] = Time.time;
                }
            }

            // Взаимодействие с окружающим миром (Предметы, магазин, NPC)

            if (Input.GetKeyDown(KeyCode.F))
            {
                player.Interact();
            }
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

    private Vector2 GetViewDirection()
    {
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= transform.position.x)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.left;
        }
    }
}
