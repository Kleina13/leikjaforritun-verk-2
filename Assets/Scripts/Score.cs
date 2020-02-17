
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public GameManager gameManager;

    void Update()
    {
        if(gameManager.scoreValue != 6)
        {
            scoreText.text = gameManager.scoreValue.ToString() + "00";
        }
        else
        {
            scoreText.text = "";
        }
    }
}
