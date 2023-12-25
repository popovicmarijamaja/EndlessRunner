using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNewSection : MonoBehaviour
{
    public GameObject enviroment1;
    public GameObject enviroment2;
    public GameObject spawnObsticlesManager;
    public GameObject spawnCoinManager;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        //Order of environments counter
        count = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        //If player went through new section trigger and counter number is even
        if (other.gameObject.CompareTag("newSection") && count%2==0)
        {
            //New spawn cycle of second environment ROCK
            spawnObsticlesManager.gameObject.GetComponent<spawnObsticles>().spawnRock2();
            //New spawn cycle of second environment COIN
            spawnCoinManager.gameObject.GetComponent<coinSpawn>().spawnCoin2();
            //Spawn of second environment infront of player
            enviroment2.transform.position = new Vector3(-28.12f, 9.76f, -2.61f);
            count++;
        }
        //If player went through new section trigger and counter number is uneven
        else if (other.gameObject.CompareTag("newSection") && count % 2 != 0)
        {
            //New spawn cycle of first environment ROCK
            spawnObsticlesManager.gameObject.GetComponent<spawnObsticles>().spawnRock1();
            //New spawn cycle of first environment COIN
            spawnCoinManager.gameObject.GetComponent<coinSpawn>().spawnCoin1();
            //Spawn of first environment infront of player
            enviroment1.transform.position = new Vector3(-28.12f, 9.76f, -2.61f);
            count++;
        }
    }
}
