using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{
    HealthHearts healthController;

    public new void Start()
    {
        base.Start();
        this.health = base.maxHealth;
        healthController = GameObject.Find("HealthController").GetComponent<HealthHearts>();
    }

    private void LateUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void FixedUpdate()
    {
        //this.Move(0);
        if (Input.GetKey(KeyCode.D))
            this.Move(1,false);
        if (Input.GetKey(KeyCode.A))
            this.Move(-1,true);
        if (Input.GetKey(KeyCode.Space)) this.Jump();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return;
        if (Input.GetKey(KeyCode.Z)) this.GetDamage(10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                GetDamage(damageReceived);
                break;
        }        
        healthController.UpdateHealth(maxHealth, health);
    }
}
