using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private bool gone;
    public float timeLife;
    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeLife) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gone)
        {
            this.Invoke("Reset", Time.deltaTime);
        }
        else
        {
            this.gone = true;
            if (other.gameObject.CompareTag("Player"))
            {
                Actor component = other.gameObject.GetComponent(typeof(Actor)) as Actor;
                if ((Object)component != (Object)null)
                {
                    component.GetDamage(this.damage);
                    component.GetRb().AddForce((Vector2)(this.transform.right * 500f));
                }
                Object.Destroy((Object)this.gameObject);
            }
            if (other.CompareTag(nameof(Bullet)))
            {
                this.gone = false;
                if ((double)this.transform.localScale.x > (double)other.transform.localScale.x)
                    return;
                Object.Destroy((Object)this.gameObject);
            }
            else
            {
                if (other.gameObject.CompareTag("Ground"))
                {
                    Object.Destroy((Object)this.gameObject);
                }
                Object.Destroy((Object)this.gameObject);
            }
        }
    }

    public void SetDamage(float f)
    {
        this.damage = f;
    }
    private void Reset()
    {
        this.gone = false;
    }
}
