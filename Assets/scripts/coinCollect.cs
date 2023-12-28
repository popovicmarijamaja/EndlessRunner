using System.Collections;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    private int coinScore;
    [SerializeField] TextMeshProUGUI scoreText;
    private int runningScore;
    [SerializeField] AudioSource coinSound;
    private int totalScore;
    public bool IsGameStopped;
    void Start()
    {
        totalScore = 0;
        runningScore = 0;
        coinScore = 0;
        StartCoroutine(ScoreByRunning());
        IsGameStopped = false;
    }
    void Update()
    {
        //Final score
        totalScore = coinScore + runningScore;
        scoreText.text = "SCORE: " + totalScore;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Score made by collecting coin
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            coinSound.Play();
            coinScore += 20;
        }
    }
    //Score made by running counter
    public IEnumerator ScoreByRunning()
    {
        while (IsGameStopped == false)
        {
            yield return new WaitForSeconds(0.25f);
            runningScore += 2;
        }
    }
}
