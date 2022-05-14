using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{
    HealthHearts healthController;
    public Gun weaponScript;
    private int rotate = 1;

    public GameObject guns;

    public int index = 1;

    public new void Start()
    {
        base.Start();
        this.health = base.maxHealth;
        healthController = GameObject.Find("HealthController").GetComponent<HealthHearts>();
        this.weaponScript = this.guns.GetComponent(typeof(Gun)) as Gun;
    }

    private void LateUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void FixedUpdate()
    {
        //this.Move(0);
        if (Input.GetKey(KeyCode.D))
        {
            rotate = 1;
            this.Move(rotate, false);
            this.weaponScript.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotate = -1;
            this.Move(rotate, true);
            this.weaponScript.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Space)) this.Jump();
        if (Input.GetKey(KeyCode.Mouse0))
            this.Fire(rotate);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return;
        
        this.StopMoving();
        
        ChangeWeapon();
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

    protected void Fire(int rotate)
    {
        if (!this.weaponScript.ready)
            return;
        this.weaponScript.Fire(rotate);
        this.rb.AddForce((Vector2)(-this.guns.transform.up));
    }

    void ChangeWeapon()
    {
        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{
        //    index = 1;
        //}
        //else if (Input.GetKeyUp(KeyCode.Alpha2)) index = 2;
        //else if (Input.GetKeyUp(KeyCode.Alpha3)) index = 3;
        //this.weaponScript = this.guns[index].GetComponent(typeof(Gun)) as Gun;
    }
}
