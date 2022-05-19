using UnityEngine;

public class Virus : Actor
{

    private SpriteRenderer sprite;

    [Header ("CalculateDistance")]
    public  float distance;
    public float maxDistance;
    public float minDistance;


    private new void Start()
    {
        base.Start();
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x >= maxDistance)
        {
            speed = -speed;
            sr.flipX = true;
        }
        if (transform.position.x < minDistance)
        {
            speed = -speed;
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GetDamage(damageReceived);
                break;           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletSecond")) GetDamage(1);
        else if (collision.gameObject.CompareTag("BulletThird") || collision.gameObject.CompareTag("BulletFirst")) Debug.Log("No!");
    }
}
