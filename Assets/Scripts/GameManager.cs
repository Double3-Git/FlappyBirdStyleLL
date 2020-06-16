using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject gameOverText;
    public Text scoreText;

    [Header("Game settings")]
    public float scrollSpeed = -1.5f;
    public bool gameOver = false;

    // Make it singleton
    [HideInInspector]
    public static GameManager instance;

    // Some private things
    private int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver) return;
        score++;
        scoreText.text = $"Score: {score}";
    }

    public void BirdDied()
    {
        // Show GameOver text
        gameOverText.SetActive(true);
        gameOver = true;
    }

}
