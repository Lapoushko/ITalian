using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textObject;
    public List<string> allTexts;
    public int index = 0;
    public string text;
    public float speed;
    float startSpeed;
    GameController controller;    

    public void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<GameController>();
        controller.isActivateDialog = true;
        var random = Random.Range(6, 10);
        AudioManager.instance.Play(AudioManager.instance.sounds[random].name);
        startSpeed = speed;
        text = allTexts[index];
        textObject.text = "";
        StartCoroutine(TextCoroutine());
        
    }

    // Update is called once per frame
    IEnumerator TextCoroutine()
    {      
        foreach(char symbol in text)
        {           
            textObject.text += symbol;
            yield return new WaitForSeconds(speed);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (index < allTexts.Count - 1)
            {
                index++;
                speed = 0;
                Invoke("StartNewText",0.27f);                
            }
            else CloseDialog();
        }
    }

    public void StartNewText()
    {
        var random = Random.Range(6, 10);
        AudioManager.instance.Play(AudioManager.instance.sounds[random].name);
        speed = startSpeed;
        text = allTexts[index];
        textObject.text = "";       
        StartCoroutine(TextCoroutine());
    }

    public void SetText(List<string> newText)
    {
        allTexts = newText;
        index = 0;    
    }

    void CloseDialog()
    {
        gameObject.SetActive(false);
        index = 0;
        controller.isActivateDialog = false;
    }
}
