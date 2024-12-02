using UnityEngine;
using System.Collections.Generic;

public class TrapManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int trapCount;

    [Header("References")]
    [SerializeField] GameObject[] trapPrefabs;
    [SerializeField] List<Transform> trapSpawnPoints = new List<Transform>();

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void Start()
    {
        SetupTrap();
    }

    void SetupTrap()
    {
        for (int i = 0; i < trapCount; i++)
        {
            Transform spawnPoint = trapSpawnPoints.GetRandom();
            trapSpawnPoints.Remove(spawnPoint);
            Instantiate(trapPrefabs.GetRandom(), spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnValidate()
    {
        if(trapCount > trapSpawnPoints.Count) trapCount = trapSpawnPoints.Count;
    }
}