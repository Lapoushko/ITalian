using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI txtHealth;

    public void UpdateTxt(float health)
    {
        txtHealth.text = "HEALTH" + health.ToString();
    }   
}
