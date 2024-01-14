using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Player _prefab;
    [SerializeField] private Transform _spawnPosition;

    public override void InstallBindings()
    {
        BindConfig();
        BindHealth();
        BindPlayer();
    }

    private void BindHealth()
    {
        Container.BindInterfacesAndSelfTo<Health>().AsSingle();
    }

    private void BindConfig()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }

    private void BindPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_prefab, _spawnPosition.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }
}
