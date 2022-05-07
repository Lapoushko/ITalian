using TMPro;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI txtHealth;
    GameObject audio;
    public GameObject textbook;

    private void Start()
    {
        audio = GameObject.Find("AudioManager");
        AudioManager.instance.Play("GameMusic");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TextbookOpen();
    }

    public void TextbookOpen()
    {
        if (textbook.gameObject.activeSelf)
        {
            textbook.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            textbook.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

}
