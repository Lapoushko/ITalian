using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Actor
{
    HealthHearts healthController;
    GameController gameControl;
    public Gun[] weaponScript;
    private int rotate = 1;

    public GameObject[] guns;

    public int indexGun = 0;
    int indexPoints = 0;

    private Animator anim;

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
        anim = GetComponent<Animator>();       
    }

    private void LateUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (health <= 0) SceneManager.LoadScene(0);
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
                ChangeAnimation(rotate, indexGun + 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rotate = -1;
                this.Move(rotate, true);
                this.weaponScript[indexGun].Rotate(rotate);
                ChangeAnimation(rotate, indexGun + 1);
            }
            if (Input.GetKey(KeyCode.Space)) this.Jump();
            if (Input.GetKey(KeyCode.Mouse0))
                this.Fire(rotate);           
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                return;
            ChangeWeapon();
            StopMoving(indexGun + 1);
        }
        
    }

    protected void StopMoving(int numberGun)
    {
        anim.SetBool("isRunning", false);
        anim.SetInteger("gun", numberGun);
    }

    public void ChangeAnimation(int dirrection, int numberGun)
    {
        anim.SetBool("isRunning", true);
        anim.SetInteger("gun", numberGun);
        if (dirrection == 0)
            StopMoving(numberGun);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                GetDamage(damageReceived);
                AudioManager.instance.Play("Hit");
                break;
            case "Trap":
                GetDamage(damageReceived);
                gameControl.TransformPlayer(gameObject);
                AudioManager.instance.Play("Hit");
                break;
            case "EnemyRunVirus":
                GetDamage(damageReceived);
                gameControl.TransformPlayer(gameObject);
                AudioManager.instance.Play("Hit");
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
                AudioManager.instance.Play("Hit");
                break;
            case "HealthKit":
                health = maxHealth;
                break;
            case "Finish":
                if (gameControl.QuestionArray.Length == 0) SceneManager.LoadScene(gameControl.nextLevel);
                gameControl.UnlockQuestionPanel();
                break;
            case "BulletEnemy":
                GetDamage(1);
                break;
        }
        healthController.UpdateHealth(maxHealth, health);
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
           // anim.SetInteger("gun", 1);
            this.weaponScript[indexGun].Rotate(rotate);            
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            indexGun = 1;
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
            this.weaponScript[indexGun].Rotate(rotate);
            //anim.SetInteger("gun", 2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            indexGun = 2;
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
           // anim.SetInteger("gun", 3);
            this.weaponScript[indexGun].Rotate(rotate);
        }
    }
}