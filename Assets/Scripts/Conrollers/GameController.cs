using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI txtHealth;
    GameObject audio;

    private void Start()
    {
        audio = GameObject.Find("AudioManager");
        AudioManager.instance.Play("GameMusic");
    }

    public void UpdateTxt(float health)
    {
        txtHealth.text = "HEALTH" + health.ToString();
    }   
}
