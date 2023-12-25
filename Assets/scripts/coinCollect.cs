using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCollect : MonoBehaviour
{
    private int numberOfCollectedCoin;
    public TextMeshProUGUI score;
    private int scoreMadeByRunning;
    public AudioSource coinSound;
    public int finalScore;
    public bool pauseOrEndGame;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = 0;
        scoreMadeByRunning = 0;
        numberOfCollectedCoin = 0;
        StartCoroutine(scoreByRunning());
        pauseOrEndGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Final score
        finalScore = numberOfCollectedCoin + scoreMadeByRunning;
        score.text = "SCORE: " + finalScore;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Score made by collecting coin
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);
            coinSound.Play();
            numberOfCollectedCoin = numberOfCollectedCoin + 20;
        }
    }
    //Score made by running counter
    public IEnumerator scoreByRunning()
    {
        while (pauseOrEndGame == false)
        {
            yield return new WaitForSeconds(0.25f);
            scoreMadeByRunning = scoreMadeByRunning + 2;
        }
    }
}
