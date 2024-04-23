using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;

    private int score;
    private bool isGameOver;
    // referencia de lectura publica y modificado privado
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Esta Instance se refiere a una nueva
            Destroy(Instance);
        }
        else
        {
            // this hace referencia al objeto de la clase
            Instance = this;
        }
    }

    private void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void ResetGame()
    {
        int numScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(numScene);
    }

    public void AddScore(int points)
    {
        score += points;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = $"Score: {score}";
    }

    public void StopGame()
    {
        StopScroll();
        StopSpawn();
        GameOverPanel();
    }

    private void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }

    private void StopSpawn()
    {
        // Busqueda y parada del objeto con el script Spawn
        Spawner[] spawners = FindObjectsOfType<Spawner>();

        foreach (Spawner spawn in spawners)
        {
            spawn.StopSpawn();
        }
    }

    private void StopScroll()
    {
        // Busqueda de los objetos con el script Scroll
        Scroll[] scrollingObjets = FindObjectsOfType<Scroll>();

        // Parar el scroll
        foreach (Scroll scrollingObject in scrollingObjets)
        {
            scrollingObject.StopScroll();
        }
    }
}
