using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MyBaseController
{
    private SpawnPointScript spawnPoint;
    private GameObject enemy;

    protected override void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<SpawnPointScript>();
        enemy = GameObject.Find("EnemyBot");
    }

    public void SpawnBot()
    {
        enemy = Instantiate(spawnPoint.Bot, spawnPoint.transform.position, spawnPoint.transform.rotation);
        spawnPoint.GetNavMeshAgent.Warp(spawnPoint.transform.position);
    }

    public GameObject GetBot
    {
        get { return enemy; }
    }
}
