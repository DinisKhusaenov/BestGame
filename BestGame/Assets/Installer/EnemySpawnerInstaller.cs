using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller 
{
    [SerializeField] private List<Transform> _smallSkeletonSpawnPoints;
    [SerializeField] private List<Transform> _largeSkeletonSpawnPoints;
    [SerializeField] private List<Transform> _magicianSpawnPoints;
    [SerializeField] private List<Transform> _flyingSpawnPoints;

    public override void InstallBindings()
    {
        BindEnemyFactory();
        BindEnemySpawner();
    }

    private void BindEnemySpawner()
    {
        Container.Bind<EnemySpawner>().AsSingle().WithArguments(_smallSkeletonSpawnPoints, _largeSkeletonSpawnPoints, _magicianSpawnPoints, _flyingSpawnPoints);
    }

    private void BindEnemyFactory()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
