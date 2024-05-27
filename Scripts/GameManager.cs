using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float initialScrollSpeed;

    private int score;
    private float timer;
    private float scrollSpeed;

    private AudioSource audioSource;
    public AudioClip points;

    public static GameManager Instance { get; private set; }
    public GameObject dino;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;  
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        UpdateScore();
        UpdateSpeed();

        
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true); 
        
       
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

        
    }

    private void UpdateScore()
    {
        int scorePerSeconds = 10;


        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        scoreText.text = "Score: " + string.Format("{0:00000}", score);

        if (score % 100 == 0 && score > 0)
        {
            audioSource.PlayOneShot(points);
        }
    }

    public float GetScrollSpeed()
    {
    return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
    
    }

    
}
