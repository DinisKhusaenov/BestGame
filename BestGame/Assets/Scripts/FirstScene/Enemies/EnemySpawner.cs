using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    private List<Transform> _smallSkeletonSpawnPoints;
    private List<Transform> _largeSkeletonSpawnPoints;
    private List<Transform> _magicianSpawnPoints;
    private List<Transform> _flyingSpawnPoints;
    private EnemyFactory _enemyFactory;

    public EnemySpawner(List<Transform> smallSkeletonSpawnPoints, List<Transform> largeSkeletonSpawnPoints, List<Transform> magicianSpawnPoints, List<Transform> flyingSpawnPoints, EnemyFactory enemyFactory)
    {
        _smallSkeletonSpawnPoints = smallSkeletonSpawnPoints;
        _largeSkeletonSpawnPoints = largeSkeletonSpawnPoints;
        _magicianSpawnPoints = magicianSpawnPoints;
        _flyingSpawnPoints = flyingSpawnPoints;
        _enemyFactory = enemyFactory;
    }

    public void Spawn()
    {
        SpawnSmallSkeleton();
        SpawnLargeSkeleton();
        SpawnMagician();
        SpawnFlyingEye();
    }

    private void SpawnSmallSkeleton()
    {
        for (int i = 0; i < _smallSkeletonSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.SmallSkeleton);
            enemy.transform.position = _smallSkeletonSpawnPoints[i].transform.position;
        }
    }

    private void SpawnLargeSkeleton()
    {
        for (int i = 0; i < _largeSkeletonSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.LargeSkeleton);
            enemy.transform.position = _largeSkeletonSpawnPoints[i].transform.position;
        }
    }

    private void SpawnMagician()
    {
        for (int i = 0; i < _magicianSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.Magician);
            enemy.transform.position = _magicianSpawnPoints[i].transform.position;
        }
    }

    private void SpawnFlyingEye()
    {
        for (int i = 0; i < _flyingSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.FlyingEye);
            enemy.transform.position = _flyingSpawnPoints[i].transform.position;
        }
    }
}
