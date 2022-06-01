using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isBossCanMoving;

    [Header("Contents")]
    public GameObject Healths;
    public GameObject GunsInterface;
    public string SelectedMenu;
    public GameObject ContentGuns;
    public GameObject ContentVirus_1;
    public GameObject ContentVirus_2;

    [Header("Questions")]
    public GameObject QuestionPanel;
    public GameObject[] QuestionArray;
    public int indexQuestion;

    private void Start()
    {
       // audio = GameObject.Find("AudioManager");
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
            Healths.SetActive(true);
            GunsInterface.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            textbook.gameObject.SetActive(true);
            Healths.SetActive(false);
            GunsInterface.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void TransformPlayer(GameObject player)
    {
        player.transform.position = controllsPoints[indexControllPoints].transform.position;
    }

    public void OnNextChangeContent(string ButtonNext)
    {
        switch (ButtonNext)
        {
            case "ContentGuns":
                if (SelectedMenu == "ContentVirus_1") { ContentVirus_1.SetActive(false); } else if (SelectedMenu == "ContentVirus_2") { ContentVirus_2.SetActive(false); }
                ContentGuns.SetActive(true);
                break;
            case "ContentVirus_1":
                if (SelectedMenu == "ContentGuns") { ContentGuns.SetActive(false); } else if (SelectedMenu == "ContentVirus_2") { ContentVirus_2.SetActive(false); }
                ContentVirus_1.SetActive(true);
                break;
            case "ContentVirus_2":
                if (SelectedMenu == "ContentGuns") { ContentGuns.SetActive(false); } else if (SelectedMenu == "ContentVirus_1") { ContentVirus_1.SetActive(false); }
                ContentVirus_2.SetActive(true);
                break;
        }
        SelectedMenu = ButtonNext;
        AudioManager.instance.Play("ButtonMenu");
    }

    public void UnlockQuestionPanel()
    {
        QuestionPanel.SetActive(true);
    }

    public void AnswerQuestion(bool isTrue)
    {
        if (!isTrue)
        {
            QuestionArray[0].SetActive(true);
            QuestionArray[1].SetActive(false);
            QuestionArray[2].SetActive(false);
            indexQuestion = 0;
        } else
        {
            QuestionArray[indexQuestion].SetActive(false);
            indexQuestion++;
            if (indexQuestion > QuestionArray.Length) SceneManager.LoadScene(nextLevel);
            
            QuestionArray[indexQuestion].SetActive(true);
        }
    }
}
