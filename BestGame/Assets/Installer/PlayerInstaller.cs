using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private GroundChecker _groundChecker;

    public override void InstallBindings()
    {
        BindConfig();
        BindGroundChecker();
        BindPlayer();
    }

    private void BindGroundChecker()
    {
        Container.Bind<GroundChecker>().FromInstance(_groundChecker).AsSingle();
    }

    private void BindConfig()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>().AsSingle();
    }
}
