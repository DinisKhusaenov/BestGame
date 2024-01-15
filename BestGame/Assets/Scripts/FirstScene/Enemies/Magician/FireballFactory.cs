using Zenject;

public class FireballFactory
{
    private FireballConfig _config;
    private DiContainer _container;

    public FireballFactory(FireballConfig config, DiContainer container)
    {
        _config = config;
        _container = container;
    }

    public Fireball Get()
    {
        Fireball fireball = _container.InstantiatePrefabForComponent<Fireball>(_config.Prefab);
        fireball.Initialize(_config.Speed, _config.Damage, _config.DestroyTime);
        return fireball;
    }
}
