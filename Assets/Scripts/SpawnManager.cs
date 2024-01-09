using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject coinPrefab;
    private const float PosY = 0.5f;
    private const int NumberOfRock = 11;
    private const int NumberOfCoin = 11;
    private const float DistanceBetweenRock = -7.5f;
    private const float DistanceBetweenCoin = -7.5f;
    private const float FirstDistanceRock = -35;
    private const float FirstDistanceCoin = -31.4f;
    private bool isRockSpawned;
    private bool isCoinSpawned;
    private readonly List<GameObject> SpawnedRocks = new();
    private readonly List<GameObject> SpawnedCoins = new();
    private void Start()
    {
        SpawnRock();
        SpawnCoin();
    }
    public void SpawnRock()
    {
        float randomPosZ;
        float posX;
        int randomIndex;
        float[] pos = { -0.5f, 0.5f, 1.6f };
        for (int i = 0; i < NumberOfRock; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            if (isRockSpawned)
            {
                SpawnedRocks[i].transform.position = new Vector3(SpawnedRocks[i].transform.position.x, SpawnedRocks[i].transform.position.y, randomPosZ);
            }
            else
            {
                posX = FirstDistanceRock + (i * DistanceBetweenRock);
                GameObject obj = Instantiate(rockPrefab, new Vector3(posX, PosY, randomPosZ), Quaternion.Euler(-90, 0, 0), transform.parent);
                SpawnedRocks.Add(obj);
            }
        }
        isRockSpawned = true;

    }
    public void SpawnCoin()
    {
        float randomPosZ;
        float posX;
        int randomIndex;
        float[] pos = { -1f, 0f, 1f };
        for (int i = 0; i < NumberOfCoin; i++)
        {
            randomIndex = Random.Range(0, 3);
            randomPosZ = pos[randomIndex];
            if (isCoinSpawned)
            {
                SpawnedCoins[i].SetActive(true);
                SpawnedCoins[i].transform.position = new Vector3(SpawnedCoins[i].transform.position.x, SpawnedCoins[i].transform.position.y, randomPosZ);
            }
            else
            {
                posX = FirstDistanceCoin + (i * DistanceBetweenCoin);
                GameObject obj = Instantiate(coinPrefab, new Vector3(posX, PosY, randomPosZ), Quaternion.Euler(-90, 0, 0), transform.parent);
                SpawnedCoins.Add(obj);
            }
        }
        isCoinSpawned = true;

    }
}
