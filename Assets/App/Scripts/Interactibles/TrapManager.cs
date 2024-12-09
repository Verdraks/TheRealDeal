using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class TrapManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int trapCount;

    [Header("References")]
    [SerializeField] GameObject[] trapPrefabs;
    [SerializeField] List<Transform> trapSpawnPoints = new ();

    private List<OnTriggerTrap> traps = new ();

    [Header("Input")]
    [SerializeField] private RSE_ResetLevel rseResetLevel;
    

    private void OnEnable() => rseResetLevel.action += ResetTraps;
    private void OnDisable() => rseResetLevel.action -= ResetTraps;

    private void Start() => SetupTrap();

    void SetupTrap()
    {
        for (int i = 0; i < trapCount; i++)
        {
            Transform spawnPoint = trapSpawnPoints.GetRandom();
            trapSpawnPoints.Remove(spawnPoint);
            traps.Add(Instantiate(trapPrefabs.GetRandom(), spawnPoint.position, Quaternion.identity).GetComponent<OnTriggerTrap>());
        }
    }

    private void ResetTraps()
    {
        foreach (var trap in traps)
        {
            trap.ResetTrap();
        }
    }
    
    private void OnValidate()
    {
        if(trapCount > trapSpawnPoints.Count) trapCount = trapSpawnPoints.Count;
    }
}