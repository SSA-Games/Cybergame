using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSkillScript : Skill
{
    private double startTime; // ������ ������
    private double timeToLive = 0.7f; // ����� ����� ������

    Transform parent_transform;

    private BoxCollider2D skill_collider;
    public override void Start()
    {
        base.Start();
        startTime = Time.time;

        skill_collider = GetComponent<BoxCollider2D>();
        // ������ ���������� ��������� ������
        parent_transform = GetComponentInParent<Transform>();
        scale = new Vector3(3.6f, 1.6f, 1);
        initialPositionOffset = new Vector3(0.8f, 0.2f, 0);
        // ���������, � ����� ������� �� ��������� �������� �����
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < parent_transform.position.x)
        {
            initialPositionOffset.x *= -1;
        }
        transform.position = new Vector3(parent_transform.position.x + initialPositionOffset.x, parent_transform.position.y + initialPositionOffset.y, parent_transform.position.z + initialPositionOffset.z);
        transform.localScale = scale;
    }

    public void Update()
    {
        if (Time.time - startTime > timeToLive) // �������� �� ����� ����� ������
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            // ���� ����� �����, �������� ������ � ��� ������� � ��������� �� ���� �������.
            EnemyInstance enemy;
            collision.TryGetComponent<EnemyInstance>(out enemy);
            AffectTheTarget(enemy);
        }
    }
    protected override void AffectTheTarget(CharacterInstance character) // ���������� �������� � ����
    {
        character.Health -= Damage;
    }
}
