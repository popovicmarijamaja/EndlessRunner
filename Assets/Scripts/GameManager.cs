using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject newSectionPos;
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }
    public GameState State;

    private int coinScore;
    private float runningScore;
    public int totalScore;
    private float runningScoreValue = 2;
    public const float SpeedIncreasing = 0.03f;
    private const string GameplayScene = "Gameplay";
    [SerializeField] private GameObject getReadyEnvironment;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CurrentState = GameState.MainMenu;
        MainMenu();
    }
    private void SetGameState(GameState state)
    {
        CurrentState = state;
    }
    private void Update()
    {
        totalScore = System.Convert.ToInt32(coinScore + runningScore);
        if (CurrentState == GameState.Playing)
        {
            runningScore += Time.deltaTime * runningScoreValue;
        }
        runningScoreValue += SpeedIncreasing * Time.deltaTime;
        UIManager.Instance.ScoreText();
    }
    public void MainMenu()
    {
        player.GetComponentInParent<PlayerMovement>().enabled = false;
        getReadyEnvironment.GetComponent<EnvironmentMoving>().enabled = false;
        for (int i = 0; i < ObjectPool.Instance.pooledObjects.Count; i++)
        {
            ObjectPool.Instance.pooledObjects[i].GetComponent<EnvironmentMoving>().enabled = false;
        }
        player.GetComponent<Animator>().enabled = false;
    }
    public void PauseGame()
    {
        if (CurrentState != GameState.GameOver)
        {
            SetGameState(GameState.Pause);
            player.GetComponentInParent<PlayerMovement>().enabled = false;
            getReadyEnvironment.GetComponent<EnvironmentMoving>().enabled = false;
            for(int i=0;i< ObjectPool.Instance.pooledObjects.Count; i++)
            {
                ObjectPool.Instance.pooledObjects[i].GetComponent<EnvironmentMoving>().enabled = false;
            }
            player.GetComponent<Animator>().enabled = false;
            UIManager.Instance.PauseMenu();
        }
    }
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        UIManager.Instance.YouLostMenu();
        player.GetComponentInParent<PlayerMovement>().enabled = false;
        getReadyEnvironment.GetComponent<EnvironmentMoving>().enabled = false;
        for (int i = 0; i < ObjectPool.Instance.pooledObjects.Count; i++)
        {
            ObjectPool.Instance.pooledObjects[i].GetComponent<EnvironmentMoving>().enabled = false;
        }
        player.GetComponent<Animator>().SetBool("death", true);
    }
    public void CoinCollect()
    {
        AudioManager.Instance.CoinSound();
        coinScore += 10;
    }
    public void SpawnNewSection()
    {
        GameObject environment = ObjectPool.Instance.GetPooledObject();
        if (environment != null)
        {
            environment.transform.position = newSectionPos.transform.position;
            environment.SetActive(true);
        }
        
    }
    public void Play()
    {
        SetGameState(GameState.Playing);
        player.GetComponentInParent<PlayerMovement>().enabled = true;
        getReadyEnvironment.GetComponent<EnvironmentMoving>().enabled = true;
        for (int i = 0; i < ObjectPool.Instance.pooledObjects.Count; i++)
        {
            ObjectPool.Instance.pooledObjects[i].GetComponent<EnvironmentMoving>().enabled = true;
        }
        player.GetComponent<Animator>().enabled = true;
        UIManager.Instance.PauseMenu();
        UIManager.Instance.Play();
        AudioManager.Instance.BackgroundMusic();
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(GameplayScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        GameOver
    }
}
