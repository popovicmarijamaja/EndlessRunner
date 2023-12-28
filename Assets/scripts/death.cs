using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject environment1;
    [SerializeField] GameObject environment2;
    [SerializeField] GameObject youLostMenu;
    private Animator anim;
    [SerializeField] GameObject pauseMenu;
    private bool isDead;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player touch front of the rock
        if (other.gameObject.CompareTag("rock"))
        {
            youLostMenu.SetActive(true);
            transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            gameObject.GetComponent<CoinCollect>().IsGameStopped = true;
            anim.SetBool("death", true);
            isDead = true;
            environment1.GetComponent<EnvironmentMoving>().enabled = false;
            environment2.GetComponent<EnvironmentMoving>().enabled = false;
        }
    }
    //Start game again, "yes" button function
    public void YesButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PauseButton()
    {
        if (isDead == false)
        {
            environment1.GetComponent<EnvironmentMoving>().enabled = false;
            environment2.GetComponent<EnvironmentMoving>().enabled = false;
            gameObject.GetComponent<CoinCollect>().IsGameStopped = true;
            anim.enabled = false;
            pauseMenu.SetActive(true);
        }
    }
    public void BackButton()
    {
        environment1.GetComponent<EnvironmentMoving>().enabled = true;
        environment2.GetComponent<EnvironmentMoving>().enabled = true;
        gameObject.GetComponent<CoinCollect>().IsGameStopped = false;
        CoinCollect coinCollector = gameObject.GetComponent<CoinCollect>();
        if (coinCollector != null)
        {
            coinCollector.StartCoroutine(coinCollector.ScoreByRunning());
        }
        anim.enabled = true;
        pauseMenu.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
