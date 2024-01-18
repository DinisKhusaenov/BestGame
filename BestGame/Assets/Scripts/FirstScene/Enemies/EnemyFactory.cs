using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string SmallSkeletonConfig = "SmallSkeletonConfig";
    private const string LargeSkeletonConfig = "LargeSkeletonConfig";
    private const string MagicianConfig = "MagicianConfig";
    private const string FlyingEyeConfig = "FlyingEyeConfig";

    private const string ConfigsPath = "EnemyConfigs";

    private EnemyConfig _smallSkeleton, _largeSkeleton, _magician, _flyingEye;

    private DiContainer _container;

    public EnemyFactory (DiContainer container)
    {
        _container = container;
        Load();
    }

    public Enemy Get(EnemyType enemyType)
    {
        EnemyConfig config = GetConfig(enemyType);
        Enemy instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
        instance.Initialize(config);
        return instance;
    }

    private EnemyConfig GetConfig(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.SmallSkeleton:
                return _smallSkeleton;

            case EnemyType.LargeSkeleton:
                return _largeSkeleton;

            case EnemyType.Magician:
                return _magician;

            case EnemyType.FlyingEye:
                return _flyingEye;

            default:
                throw new ArgumentException(nameof(enemyType));
        }
    }

    private void Load()
    {
        _smallSkeleton = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, SmallSkeletonConfig));
        _largeSkeleton = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, LargeSkeletonConfig));
        _magician = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, MagicianConfig));
        _flyingEye = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, FlyingEyeConfig));
    }
}
