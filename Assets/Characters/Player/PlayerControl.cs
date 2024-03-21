using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    public static Vector2 ViewDirection = Vector2.right;
    public float moveSpeed = 5f;

    private float[] cooldowns = new float[] { 0, 0, 0 }; //Таймер кулдаунов

    private PlayerInstance player;
    private DialogManager dm;
    private PauseControl pauseControl;
    private Collider2D coll;
    private SkillManager sm;

    void Awake()
    {
        dm = GameObject.Find("GameManager").GetComponent<DialogManager>();
        player = GetComponent<PlayerInstance>();
        coll = GetComponent<Collider2D>();
        sm = GetComponent<SkillManager>();
        pauseControl = GetComponent<PauseControl>();
    }

    void Update()
    {
        ViewDirection = GetViewDirection();

        // Если игрок занят, его передвижение отключено. Тут своя система управления
        if (player.InDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
            {
                dm.ContinueDialog();
            }
        }
        else if (pauseControl.IsPaused)
        {
            // Can't do anything!
        }
        else // Если игрок не занят, обычная система управления:
        {
            Move();
            // Использование умений

            if (Input.GetKeyDown(KeyCode.Q) && sm.GetSkillFromHotkey(0) != null)
            {
                if (Time.time - cooldowns[0] > sm.GetSkillFromHotkey(0).Cooldown)
                {
                    sm.CastSkill(0);
                    cooldowns[0] = Time.time;
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && sm.GetSkillFromHotkey(1) != null)
            {
                if (Time.time - cooldowns[1] > sm.GetSkillFromHotkey(1).Cooldown)
                {
                    sm.CastSkill(1);
                    cooldowns[1] = Time.time;
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && sm.GetSkillFromHotkey(2) != null)
            {
                if (Time.time - cooldowns[2] > sm.GetSkillFromHotkey(2).Cooldown)
                {
                    sm.CastSkill(2);
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
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0 || verticalInput != 0) // Когда есть команда двигаться
        {
            float p = Mathf.Sqrt(Mathf.Pow(horizontalInput, 2) + Mathf.Pow(verticalInput, 2));
            // Третья (Z) компонента используется для корректного отображения спрайтов
            Vector3 newPos = new Vector3(transform.position.x + horizontalInput * moveSpeed / p, transform.position.y + verticalInput * moveSpeed / p, transform.position.z + verticalInput * moveSpeed);
            transform.position = newPos;
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
