using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float lerpTime;

    float minDst = 1.5f;
    public float distance;
    bool goend = false;
    Vector3 startPos;
    Vector3 endPos;
    private void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (goend)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, lerpTime * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPos) < minDst)
            {
                //lerpTime = Random.Range(4f, 7f);
                goend = !goend;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, lerpTime * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < minDst)
            {
                endPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                //lerpTime = Random.Range(4f, 7f);
                goend = !goend;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}