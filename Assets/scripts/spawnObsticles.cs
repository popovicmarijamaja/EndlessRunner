using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObsticles : MonoBehaviour
{
    public List<GameObject> rock1;
    public List<GameObject> rock2;
    private float randomPosZ;
    private float posX;
    private float posY = -0.5f;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        spawnRock1();
        spawnRock2();
    }
    //Obsticle spawn function for first part of path
    public void spawnRock1()
    {
        float[] pos = { -0.5f, 0.5f, 1.7f };
        for (int i = 0; i < rock1.Count; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 0 + (i * -7);
            rock1[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
    //Obsticle spawn function for second part of path
    public void spawnRock2()
    {
        float[] pos = { -0.5f, 0.5f, 1.7f };
        for (int i = 0; i < rock2.Count; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 4 + (i * -7);
            rock2[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
}
