using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{
    HealthHearts healthController;
    public Gun[] weaponScript;
    private int rotate = 1;

    public GameObject[] guns;

    public int index = 0;

    public new void Start()
    {
        base.Start();
        this.health = base.maxHealth;
        healthController = GameObject.Find("HealthController").GetComponent<HealthHearts>();
        ChangeWeapon();
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
            this.weaponScript[index].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotate = -1;
            this.Move(rotate, true);
            this.weaponScript[index].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Space)) this.Jump();
        if (Input.GetKey(KeyCode.Mouse0))
            this.Fire(rotate);
        ChangeWeapon();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return;
        this.StopMoving();
        
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
        if (!this.weaponScript[index].ready)
            return;
        this.weaponScript[index].Fire(rotate);
        this.rb.AddForce((Vector2)(-this.guns[index].transform.up));
    }

    void ChangeWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            index = 0;
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            this.weaponScript[index].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            index = 1;
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
            this.weaponScript[index].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            index = 2;
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
            this.weaponScript[index].Rotate(rotate);
        }
    }
}