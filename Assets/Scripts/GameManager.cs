using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public int score;
    public List<GameObject> targets;
    public TextMeshProUGUI livesText;
    public Slider soundSlider;
    public int lives;
    public GameObject pausePanel;
    public bool gameOver = true;
    float spawnRate=1.0f;
    AudioSource audioSource;
    bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindAnyObjectByType<Camera>().GetComponent<AudioSource>();
        soundSlider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!gameOver)
        {
            if (!gamePaused)
            {
                Time.timeScale = 0;
                gamePaused = true;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                gamePaused = false;
                pausePanel.SetActive(false);
            }
        }
    }
    IEnumerator SpawnTargets()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score : " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        gameOver = false;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        titleScreen.SetActive(false);
        soundSlider.gameObject.SetActive(false);
    }
    public void AdjustVolume()
    {
        audioSource.volume = soundSlider.value;
    }
}
