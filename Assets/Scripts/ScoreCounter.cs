using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour 
{
    private double scoreCount = 0;
    public TextMeshProUGUI text;

    public void UpdateScore()
    {
        scoreCount+=0.5;
        text.text = scoreCount.ToString();
    }
}
