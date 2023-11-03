using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool gameOver;

	void Start () 
    {
        gameOver = false;		
	}

    public void GameStart()
    {
        UIManager.Instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); // only start spawning new platforms when game starts
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        ScoreManager.Instance.StopScore();
        gameOver = true;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
