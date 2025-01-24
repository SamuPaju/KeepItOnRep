using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Start sequence")]
    [SerializeField]
    GameObject[] lights;
    [SerializeField] GameObject matchstick;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject centralDot;
    [SerializeField] Fireplace fireplace;
    [SerializeField] GameObject decAxe;
    [SerializeField] GameObject startScreen;
    [SerializeField] AudioSource backgroundAudio;


    [Header("GameOver")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI timerTextGameOver;
    [SerializeField] GameObject taskUI;

    [Header("Victory")]
    [SerializeField] GameObject victoryScreen;
    [SerializeField] TextMeshProUGUI timerTextVictory;

    [Header("Credits")]
    [SerializeField] GameObject credits;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartSetUp();
    }

    void Update()
    {
        // Check if player wants to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver(false);
        }
    }
    /// <summary>
    /// End the game and setup and display Game Over screen
    /// </summary>
    /// <param name="youWin"></param>
    public void GameOver(bool youWin)
    {
        Cursor.lockState = CursorLockMode.None;
        backgroundAudio.Stop();
        taskUI.SetActive(false);
        cameraController.disableLook();
        playerController.disableMove();
        float totalTime = Timer.instance.TimerOff();
        float mins = Mathf.FloorToInt(totalTime / 60);
        float s = Mathf.FloorToInt(totalTime % 60);
        if (youWin)
        {
            victoryScreen.SetActive(true);
            timerTextVictory.text = "Your time: " + mins.ToString() + " min " + s.ToString() + " seconds";
        }
        else
        {
            gameOverScreen.SetActive(true);
            timerTextGameOver.text = "Your time: " + mins.ToString() + " min " + s.ToString() + " seconds";
        }
    }
    /// <summary>
    /// Restart the game by loading the same scene
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Exit the game
    /// </summary>
    public void Exit()
    {
#if UNITY_EDITOR
    // If running in the Unity Editor, stop play mode
    UnityEditor.EditorApplication.isPlaying = false;
#else
    // If running as a built application, quit the game
    Application.Quit();
#endif
    }
    /// <summary>
    /// Set credits active
    /// </summary>
    public void Credits()
    {
        credits.SetActive(true);
    }
    /// <summary>
    /// Set necessary things for start screen
    /// </summary>
    void StartSetUp()
    {
        centralDot.SetActive(false);
        fireplace.disableTimer();
        player.SetActive(false);
        camera2.SetActive(true);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
    }
    /// <summary>
    /// End start sequence and start gameplay
    /// </summary>
    public void StartSequenceEnd()
    {
        Timer.instance.timerOn();
        centralDot.SetActive(true);
        fireplace.activateTimer();
        player.SetActive(true);
        camera2.SetActive(false);
        decAxe.SetActive(false);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);
        }
        backgroundAudio.Play();
    }
    /// <summary>
    /// Start the beginnig cinematic
    /// </summary>
    public void StartButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startScreen.SetActive(false);
        matchstick.GetComponent<Animator>().SetTrigger("Start");
        matchstick.GetComponent<AudioSource>().Play();
    }
}
