using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawn : MonoBehaviour
{
    public List<GameObject> coin1;
    public List<GameObject> coin2;
    private float randomPosZ;
    private float posX;
    private float posY = -9.3f;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        spawnCoin1();
        spawnCoin2();
    }
    //Coin spawn function for first part of path
    public void spawnCoin1()
    {
        float[] pos = { 1.6f, 2.6f, 3.6f };
        for (int i = 0; i < coin1.Count; i++)
        {
            coin1[i].gameObject.SetActive(true);
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 3 + (i * -7);
            coin1[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
    //Coin spawn function for second part of path
    public void spawnCoin2()
    {
        float[] pos = { 1.6f, 2.6f, 3.6f };
        for (int i = 0; i < coin2.Count; i++)
        {
            coin2[i].gameObject.SetActive(true);
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 49 + (i * -7);
            coin2[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
}
