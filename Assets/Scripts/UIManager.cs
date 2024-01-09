using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject youLostMenu;
    [SerializeField] private GameObject mainMenu;
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
    public void PauseMenu()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Pause)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
    public void Play()
    {
        mainMenu.SetActive(false);
    }
    public void ScoreText()
    {
        scoreText.text = "SCORE: " + GameManager.Instance.totalScore;
    }
    public void YouLostMenu()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.GameOver)
        {
            youLostMenu.SetActive(true);
        }
        else
        {
            youLostMenu.SetActive(false);
        }
    }

    public void PlayButton()
    {
        GameManager.Instance.LoadGameplayScene();
    }
    public void QuitButton()
    {
        GameManager.Instance.Quit();
    }
    public void PauseButton()
    {
        GameManager.Instance.PauseGame();
    }
    public void BackButton()
    {
        GameManager.Instance.Play();
    }
}
