using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int speedBullet;
    private float damage;

    public Transform shotPosition;

    public GameObject bullet;
    public GameObject enemyBullet;

    public bool ready;
    public float fireRate;

    public void Fire(int rotate)
    {
        if (!this.ready) return;
        this.SpawnBullet(rotate);
        this.ready = false;
        this.Invoke("GetReady", fireRate);
    }

    void GetReady()
    {
        this.ready = true;
    }

    void SpawnBullet(int rotate)
    {
        GameObject gj = (this.transform.parent.name == "Player") ?
            Instantiate<GameObject>(this.bullet, this.shotPosition.transform.position, this.transform.rotation) :
            Instantiate<GameObject>(this.enemyBullet, this.shotPosition.transform.position, this.transform.rotation);
        gj.GetComponent<Rigidbody2D>().velocity = (Vector2)(this.transform.right * this.speedBullet);        
        if (this.transform.parent.name == "Player")
        {
            AudioManager.instance.Play("Gun");
        }
        else
        {

        }
        ((Bullet)gj.GetComponent(typeof(Bullet))).SetDamage(this.damage);
    }

    public void Rotate(int rotate)
    {
        if (rotate == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (rotate == 1) transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
