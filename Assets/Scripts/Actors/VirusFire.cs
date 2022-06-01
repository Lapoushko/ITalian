using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusFire : Actor
{
    public bool isBoss;
    public float time;
    public float timeRespawn;
    public GameObject[] pointsSpawn;
    bool isCanReady = true;
    public GameObject player;
    public GameObject particleNewPos;
    public GameController controller;
    public Gun weaponScript;
    int rotate;

    public new void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        controller = GameObject.Find("Controller").GetComponent<GameController>();
        this.weaponScript.Rotate(rotate);
    }

    void Update()
    {
        if (player)
        {
            if (player.transform.position.x >= transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                rotate = -1;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rotate = 1;
            }

            if (controller.isBossCanMoving)
            {
                time += Time.deltaTime;
                if (time >= timeRespawn)
                {
                    NewPosition();
                }
                Fire(rotate);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletFirst"))
        {
            particleNewPos.transform.position = transform.position;
            Instantiate(particleNewPos);
            var rnd = Random.Range(0, pointsSpawn.Length - 1);
            transform.position = pointsSpawn[rnd].transform.position;
            time = 0;
            GetDamage(1);
        }
        else if (collision.gameObject.CompareTag("BulletSecond") || collision.gameObject.CompareTag("BulletThird")) Debug.Log("loh");
    }

    void NewPosition()
    {        
        var rnd = Random.Range(0, pointsSpawn.Length - 1);
        transform.position = pointsSpawn[rnd].transform.position;
        time = 0;
    }

    protected void Fire(int rotate)
    {
        if (!this.weaponScript.ready) { Debug.Log("333"); return; }
        this.weaponScript.Fire(rotate);
        this.weaponScript.Rotate(rotate);
        this.rb.AddForce((Vector2)(-this.gameObject.transform.up));
    }
}
