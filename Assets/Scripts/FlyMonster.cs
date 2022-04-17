using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonster : Actor
{
    public float speedx;
    public float forceUp;
    public GameObject target;

    private new void Start()
    {
        base.Start();
        target = GameObject.Find("Player");
        this.health = base.startHealth;
    }

    public void Update()
    {
        MoveFly(forceUp, speedx, target);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GetDamage(20);
                break;
        }

    }
}
