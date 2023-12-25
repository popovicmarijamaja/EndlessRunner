using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject enviromentMoving1;
    public GameObject enviromentMoving2;
    public GameObject youLostMenu;
    private Animator anim;
    public GameObject backToGame;
    private bool death_;
    // Start is called before the first frame update
    void Start()
    {
        death_ = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player touch front of the rock
        if (other.gameObject.tag == "rock")
        {
            youLostMenu.SetActive(true);
            transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            gameObject.GetComponent<coinCollect>().pauseOrEndGame = true;
            anim.SetBool("death", true);
            death_ = true;
            enviromentMoving1.gameObject.GetComponent<enviromentMoving>().enabled = false;
            enviromentMoving2.gameObject.GetComponent<enviromentMoving>().enabled = false;
        }
    }
    //Play again button function
    public void playAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //Pause button function
    public void pause()
    {
        //Checking if player is not already dead
        if (death_ == false)
        {
            enviromentMoving1.gameObject.GetComponent<enviromentMoving>().enabled = false;
            enviromentMoving2.gameObject.GetComponent<enviromentMoving>().enabled = false;
            gameObject.GetComponent<coinCollect>().pauseOrEndGame = true;
            anim.enabled = false;
            backToGame.gameObject.SetActive(true);
        }
    }
    //Back button function
    public void back()
    {
        enviromentMoving1.gameObject.GetComponent<enviromentMoving>().enabled = true;
        enviromentMoving2.gameObject.GetComponent<enviromentMoving>().enabled = true;
        gameObject.GetComponent<coinCollect>().pauseOrEndGame = false;
        gameObject.GetComponent<coinCollect>().StartCoroutine("scoreByRunning");
        anim.enabled = true;
        backToGame.gameObject.SetActive(false);
    }
    //Quit button function
    public void quit()
    {
        Application.Quit();
    }
}
