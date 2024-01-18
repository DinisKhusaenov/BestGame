using UnityEngine;

public class EnemySpawner
{
    private EnemySpawnPoints _enemySpawnPoints;
    private EnemyFactory _enemyFactory;

    public EnemySpawner(EnemySpawnPoints spawnPoints, EnemyFactory enemyFactory)
    {
        _enemySpawnPoints = spawnPoints;
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
        for (int i = 0; i < _enemySpawnPoints.SmallSkeletonSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.SmallSkeleton);
            enemy.transform.position = _enemySpawnPoints.SmallSkeletonSpawnPoints[i].transform.position;
        }
    }

    private void SpawnLargeSkeleton()
    {
        for (int i = 0; i < _enemySpawnPoints.LargeSkeletonSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.LargeSkeleton);
            enemy.transform.position = _enemySpawnPoints.LargeSkeletonSpawnPoints[i].transform.position;
        }
    }

    private void SpawnMagician()
    {
        for (int i = 0; i < _enemySpawnPoints.MagicianSpawnPoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.Magician);
            enemy.transform.position = _enemySpawnPoints.MagicianSpawnPoints[i].transform.position;
        }
    }

    private void SpawnFlyingEye()
    {
        for (int i = 0; i < _enemySpawnPoints.FlyingEyeSpawnpoints.Count; i++)
        {
            Enemy enemy = _enemyFactory.Get(EnemyType.FlyingEye);
            enemy.transform.position = _enemySpawnPoints.FlyingEyeSpawnpoints[i].transform.position;
        }
    }
}
