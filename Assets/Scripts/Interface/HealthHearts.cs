using UnityEngine;
using UnityEngine.UI;

public class HealthHearts : MonoBehaviour
{
    public Image[] hearts;

    public void UpdateHealth(float maxHealth, float health)
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;              
            }
            else hearts[i].enabled = false;
        }
    }
}
