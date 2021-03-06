using UnityEngine;

public class Actor : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    public int damageReceived = 1;

    public float maxSpeed = 20f;
    public float speed = 0f;
    bool moving = true;

    public string nameActor;    

    [Header ("Jump")]
    public float jumpForce = 100f;
    public bool isGrounded = true;
    public float groundRadius;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    [Header ("Conrollers")]
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    GameController gameController;

    public void Start()
    {        
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        this.health = maxHealth;
        this.nameActor = gameObject.name;
    }

    public void Move(int dirrection, bool isLeft)
    {
        this.moving = true;
        this.rb.velocity = new Vector2(this.maxSpeed * dirrection, this.rb.velocity.y);
        this.sr.flipX = isLeft;        
    }    

    public Rigidbody2D GetRb()
    {
        return this.rb;
    }

    public void Jump()
    {
        if (this.isGrounded)
        {
            this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0.0f);
            this.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.Play("Jump");
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (this.health <= 0)
        {
            AudioManager.instance.Play("Hit");
            GameObject.Destroy(gameObject);
        }
    }
    
    public void MoveFly(float forceUp, float speedx, GameObject target)
    {
        if (target)
        {
            if (target.transform.position.x >= transform.position.x + 2f) rb.velocity = new Vector2(speedx, rb.velocity.y);
            else if (target.transform.position.x <= transform.position.x - 2f) rb.velocity = new Vector2(-speedx, rb.velocity.y);

            if (target.transform.position.y < transform.position.y) rb.AddForce(Vector2.down * Time.deltaTime * forceUp);
            else if (target.transform.position.y > transform.position.y) rb.AddForce(Vector2.up * Time.deltaTime * forceUp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (nameActor != "Player")
        //{
        //    if ()
        //}
    }
}
