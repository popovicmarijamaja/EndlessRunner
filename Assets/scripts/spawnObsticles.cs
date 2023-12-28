using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticles : MonoBehaviour
{
    [SerializeField] List<GameObject> rockList1;
    [SerializeField] List<GameObject> rockList2;
    private float randomPosZ;
    private float posX;
    private float posY;
    private int randomIndex;
    void Start()
    {
        posY = -0.5f;
        SpawnRock1();
        SpawnRock2();
    }
    //Obsticle spawn function for first part of path
    public void SpawnRock1()
    {
        float[] pos = { -0.5f, 0.5f, 1.7f };
        for (int i = 0; i < rockList1.Count; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 0 + (i * -7);
            rockList1[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
    //Obsticle spawn function for second part of path
    public void SpawnRock2()
    {
        float[] pos = { -0.5f, 0.5f, 1.7f };
        for (int i = 0; i < rockList2.Count; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            posX = 4 + (i * -7);
            rockList2[i].transform.localPosition = new Vector3(posX, posY, randomPosZ);
        }
    }
}
