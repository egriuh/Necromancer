using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private int health;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth(int healthToAdd)
    {
        // Update health text
        if (!gameOver)
        {
            health += healthToAdd;
            healthText.text = "Health: " + health;
            if (health <= 0)
            {
                GameOver();
                gameOver = true;
            }
        }
    }

    public void RestartGame()
    {
        // Restart Button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
