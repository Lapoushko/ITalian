using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPoints : MonoBehaviour
{
    public int index;
    public Color color;
    public GameObject flashlight;
    SpriteRenderer flashlightColor;
    GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        flashlightColor = flashlight.GetComponent<SpriteRenderer>();
        controller = GameObject.Find("Controller").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flashlightColor.color = color;
            controller.indexControllPoints = index;
        }
    }


}
