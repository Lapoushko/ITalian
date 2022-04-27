using UnityEngine;

public class Virus : Actor
{

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public  float distance;
    public float maxDistance;
    public float minDistance;


    private new void Start()
    {
        base.Start();
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x > maxDistance)
            speed = -speed;
        if (transform.position.x < minDistance)
            speed = -speed;
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


}
