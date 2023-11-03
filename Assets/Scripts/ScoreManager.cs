using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score;
    public int highScore;
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score); // "score" is our key, score is value stored in key
    }
    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 2;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore")) 
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
