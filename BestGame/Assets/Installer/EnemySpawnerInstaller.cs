using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller 
{
    [SerializeField] EnemySpawnPoints _spawnPoints;

    public override void InstallBindings()
    {
        BindEnemyFactory();
        BindEnemySpawner();
    }

    private void BindEnemySpawner()
    {
        Container.Bind<EnemySpawner>().AsSingle().WithArguments(_spawnPoints);
    }

    private void BindEnemyFactory()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
