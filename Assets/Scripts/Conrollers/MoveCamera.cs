using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float dumping;
    public Vector2 offset = new Vector2(2f, 1f);
    bool isLeft;
    Transform player;
    int lastX;
    

    [Header("Border")]
    Camera cam;
    public bool isBorder = false;
    public float camMinX;
    public float camMaxX;

    public float camMinY;
    public float camMaxY;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
        cam = Camera.main;
    }

    public void FindPlayer(bool isLeft)
    {
        player = GameObject.Find("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (isLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        } else
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 camPosition = cam.transform.position;
            camPosition.x = Mathf.Clamp(camPosition.x, camMinX, camMaxX);
            camPosition.y = Mathf.Clamp(camPosition.y, camMinY, camMaxY);

            cam.transform.position = camPosition;

            Vector3 targetPos = player.position;
            var currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            var target = new Vector3();
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);

        }
    }
}
