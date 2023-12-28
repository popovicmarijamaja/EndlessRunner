using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> coinList1;
    [SerializeField] List<GameObject> coinList2;
    private float randomPosZ;
    private float posX;
    private float posY;
    private int randomIndex;
    void Start()
    {
        posY = -9.3f;
        SpawnCoin1();
        SpawnCoin2();
    }
    //Coin spawn function for the first part of the path
    public void SpawnCoin1()
    {
        float[] pos = { 1.6f, 2.6f, 3.6f };
        for (int i = 0; i < coinList1.Count; i++)
        {
            coinList1[i].SetActive(true);
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 3 + (i * -7);
            coinList1[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
    //Coin spawn function for the second part of the path
    public void SpawnCoin2()
    {
        float[] pos = { 1.6f, 2.6f, 3.6f };
        for (int i = 0; i < coinList2.Count; i++)
        {
            coinList2[i].SetActive(true);
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 49 + (i * -7);
            coinList2[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
}
