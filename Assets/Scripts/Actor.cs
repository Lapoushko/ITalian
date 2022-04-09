using UnityEngine;

public class Actor : MonoBehaviour
{
    public float health = 0f;
    public float startHealth = 100f;

    public float maxSpeed = 20f;
    public float speed = 0f;
    bool moving = true;

    [Header ("Jump")]
    public float jumpForce = 100f;
    public bool isGrounded = true;
    public float groundRadius;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    [Header ("Conrollers")]
    Rigidbody2D rb;
    SpriteRenderer sr;
    GameController gameController;

    public void Start()
    {        
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        this.health = startHealth;
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void LateUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    public void Move(int dirrection, bool isLeft)
    {
        this.moving = true;
        this.rb.velocity = new Vector2(this.maxSpeed * dirrection, this.rb.velocity.y);
        this.sr.flipX = isLeft;
        if (dirrection == 0)
            StopMoving();
    }

    protected void StopMoving()
    {
        this.moving = false;
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
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (this.health < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
