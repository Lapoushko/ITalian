using TMPro;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public string nextLevel;

    public TextMeshProUGUI txtHealth;
    GameObject audio;
    public GameObject textbook;

    public Transform[] controllsPoints;
    public int indexControllPoints;

    public GameObject dialog;
    public bool isActivateDialog;

    private void Start()
    {
        audio = GameObject.Find("AudioManager");
        AudioManager.instance.Play("GameMusic");
    }

    private void Update()
    {
        if (!isActivateDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextbookOpen();
                AudioManager.instance.Play("Menu");
            }
        }
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

    public void TransformPlayer(GameObject player)
    {
        player.transform.position = controllsPoints[indexControllPoints].transform.position;
    }
}
