using UnityEngine;

public class FlyMonster : Actor
{
    public float speedx;
    public float forceUp;
    public GameObject target;
    GameController controller;
    public bool isBoss;

    private new void Start()
    {
        base.Start();
        controller = GameObject.Find("Controller").GetComponent<GameController>();
        target = GameObject.Find("Player");
        this.health = base.maxHealth;
    }

    public void Update()
    {
        if (target)
        {
            if (!isBoss || (isBoss && controller.isBossCanMoving))
            {
                if (target.transform.position.x >= transform.position.x + 2f) rb.velocity = new Vector2(speedx, rb.velocity.y);
                else if (target.transform.position.x <= transform.position.x - 2f) rb.velocity = new Vector2(-speedx, rb.velocity.y);

                if (target.transform.position.y < transform.position.y) rb.AddForce(Vector2.down * Time.deltaTime * forceUp);
                else if (target.transform.position.y > transform.position.y) rb.AddForce(Vector2.up * Time.deltaTime * forceUp);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GetDamage(damageReceived);
                if (health <= 0 && isBoss)
                    controller.countDeadFlyMonster++;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletThird"))
        {
            GetDamage(1);
            if (health <= 0 && isBoss)
                controller.countDeadFlyMonster++;
        }
        else if (collision.gameObject.CompareTag("BulletFirst") || collision.gameObject.CompareTag("BulletSecond")) Debug.Log("No!");
    }
}
