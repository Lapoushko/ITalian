using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniVirus : Actor
{
    public float speedRotate;
    [Header ("Parameters Stay")]    
    float t;
    public float amp = 2f;
    public float freq = 2;
    public float offset;
    Vector3 startPos;
    
    [Header ("Follow")]
    public float speedx;
    public float forceUp;
    public GameObject target;
    public bool isFollower = false;
    public float distance;

    private new void Start()
    {
        base.Start();
        target = GameObject.Find("Player");
        startPos = transform.position;
    }

    private void Update()
    {
        if (target)
        {
            if (isFollower &&
                (gameObject.transform.position.x - distance <= target.transform.position.x
                && gameObject.transform.position.x + distance >= target.transform.position.x))
            {
                MoveFly(forceUp, speedx, target);
            }
            else
            {
                t = t + Time.deltaTime;
                offset = amp * Mathf.Sin(t * freq);
                transform.position = startPos + new Vector3(0, offset, 0);
            }
        }
        transform.Rotate(new Vector3(0f, 0f, speedRotate * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GetDamage(damageReceived);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletThird") 
            || collision.gameObject.CompareTag("BulletFirst")
            || collision.gameObject.CompareTag("BulletSecond")) GetDamage(1);
    }
}
