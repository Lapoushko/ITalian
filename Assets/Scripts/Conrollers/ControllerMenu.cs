using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("FirstLevel");
        AudioManager.instance.Play("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("???? ?????????");
        Application.Quit();
    }
}
