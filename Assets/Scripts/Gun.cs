using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speedBullet;
    public float damage;

    public Transform shotPosition;

    public GameObject bullet;
    public GameObject enemyBullet;

    public bool ready;
    public float fireRate;

    void Fire()
    {
        if (!this.ready) return;
        this.SpawnBullet();
        this.ready = false;
        this.Invoke("GetReady", fireRate);
    }   

    void GetReady()
    {
        this.ready = true;
    }

    void SpawnBullet()
    {
        GameObject gameObject = (this.transform.parent.name == "Player") ?
            Instantiate<GameObject>(this.bullet, this.shotPosition.transform.position, this.transform.rotation) :
            Instantiate<GameObject>(this.enemyBullet, this.shotPosition.transform.position, this.transform.rotation);
        gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2)(this.transform.up * this.speedBullet);
        if (this.transform.parent.name == "Player")
        {

        }
        else
        {

        }
        
    }
}
