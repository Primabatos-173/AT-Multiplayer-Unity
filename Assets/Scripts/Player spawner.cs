using UnityEngine;
using Fusion;
using System.Collections;
using System.Collections.Generic;

public class Playerspawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerprefab;
    [SerializeField] private Transform[] spawnpoints;
    public void PlayerJoined(PlayerRef player)
    {
        if(player == Runner.LocalPlayer)
        {
          var index = player.AsIndex % spawnpoints.Length;
          Runner.Spawn(playerprefab, spawnpoints[index].position, Quaternion.identity, player);
        }
    }
}
