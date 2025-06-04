using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter
{
    private int scoreCount = 0;
    public Text text;

    public void UpdateScore()
    {
        scoreCount++;
        text.text = scoreCount.ToString();
    }
}
