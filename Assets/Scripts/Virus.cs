using UnityEngine;

public class Virus : Actor
{
    private SpriteRenderer sprite;
    Vector3 startPos;
    Vector3 endPos;
    public float speed;
    public float distance;
    private Vector3 dir;

    private new void Start()
    {
        base.Start();
        startPos = transform.position;
        endPos = new Vector2(transform.position.x + distance, transform.position.y);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }
}
