using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialForDialog : MonoBehaviour
{
    public List<string> allTexts;
    public GameObject dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialog.SetActive(true);
            dialog.GetComponent<Dialog>().SetText(allTexts);
            dialog.GetComponent<Dialog>().Start();
            gameObject.SetActive(false);
        }
    }
}
