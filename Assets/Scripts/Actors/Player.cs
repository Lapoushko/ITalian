using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{
    HealthHearts healthController;
    GameController gameControl;
    public Gun[] weaponScript;
    private int rotate = 1;

    public GameObject[] guns;

    public int indexGun = 0;
    int indexPoints = 0;

    public new void Start()
    {
        base.Start();
        this.health = base.maxHealth;
        healthController = GameObject.Find("HealthController").GetComponent<HealthHearts>();
        gameControl = GameObject.Find("Controller").GetComponent<GameController>();
        indexGun = 0;
        guns[0].SetActive(true);
        guns[1].SetActive(false);
        guns[2].SetActive(false);
        this.weaponScript[indexGun].Rotate(rotate);
    }

    private void LateUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void FixedUpdate()
    {
        //this.Move(0);
        if (!gameControl.isActivateDialog)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotate = 1;
                this.Move(rotate, false);
                this.weaponScript[indexGun].Rotate(rotate);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rotate = -1;
                this.Move(rotate, true);
                this.weaponScript[indexGun].Rotate(rotate);
            }
            if (Input.GetKey(KeyCode.Space)) this.Jump();
            if (Input.GetKey(KeyCode.Mouse0))
                this.Fire(rotate);
            ChangeWeapon();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                return;
            this.StopMoving();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                GetDamage(damageReceived);
                break;
            case "Trap":
                GetDamage(damageReceived);
                gameControl.TransformPlayer(gameObject);
                break;            
        }
        healthController.UpdateHealth(maxHealth, health);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DownBorder":
                GetDamage(damageReceived);
                gameControl.TransformPlayer(gameObject);
                break;
        }
    }

    protected void Fire(int rotate)
    {
        if (!this.weaponScript[indexGun].ready)
            return;
        this.weaponScript[indexGun].Fire(rotate);
        this.rb.AddForce((Vector2)(-this.guns[indexGun].transform.up));
    }

    void ChangeWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            indexGun = 0;
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            this.weaponScript[indexGun].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            indexGun = 1;
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
            this.weaponScript[indexGun].Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            indexGun = 2;
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
            this.weaponScript[indexGun].Rotate(rotate);
        }
    }
}