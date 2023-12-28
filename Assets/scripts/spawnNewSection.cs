using UnityEngine;

public class SpawnNewSection : MonoBehaviour
{
    [SerializeField] GameObject environment1;
    [SerializeField] GameObject environment2;
    [SerializeField] GameObject spawnObsticlesManager;
    [SerializeField] GameObject spawnCoinManager;
    private int turnCounter;
    void Start()
    {
        //Order of environments counter
        turnCounter = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        //If player went through new section trigger and counter number is even
        if (other.gameObject.CompareTag("newSection") && turnCounter%2==0)
        {
            //New spawn cycle of second environment ROCK
            spawnObsticlesManager.GetComponent<SpawnObsticles>().SpawnRock2();
            //New spawn cycle of second environment COIN
            spawnCoinManager.GetComponent<CoinSpawn>().SpawnCoin2();
            //Spawn of second environment infront of player
            environment2.transform.position = new Vector3(-28.12f, 9.76f, -2.61f);
            turnCounter++;
        }
        //If player went through new section trigger and counter number is uneven
        else if (other.gameObject.CompareTag("newSection") && turnCounter % 2 != 0)
        {
            //New spawn cycle of first environment ROCK
            spawnObsticlesManager.GetComponent<SpawnObsticles>().SpawnRock1();
            //New spawn cycle of first environment COIN
            spawnCoinManager.GetComponent<CoinSpawn>().SpawnCoin1();
            //Spawn of first environment infront of player
            environment1.transform.position = new Vector3(-28.12f, 9.76f, -2.61f);
            turnCounter++;
        }
    }
}
