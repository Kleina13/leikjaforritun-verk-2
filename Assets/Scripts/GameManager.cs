using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   

    bool gameHasEnded = false;
    public GameObject FinishPanel;
    public PlayerMovement movement;
    public int scoreValue;

    void Start()
    {
        scoreValue = 0;
    }

    void Update()
    {
        if(scoreValue == 5)
        {
            CompleteLevel();
            scoreValue += 1;
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            scoreValue += 1;
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("VICTORY");
        FinishPanel.SetActive(true);
        movement.enabled = false;   
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("GAME OVER");
            gameHasEnded = true;
            Invoke("Restart", 1.5f);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
