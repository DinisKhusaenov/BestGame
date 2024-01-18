using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _smallSkeletonSpawnPoints;
    [SerializeField] private List<Transform> _largeSkeletonSpawnPoints;
    [SerializeField] private List<Transform> _magicianSpawnPoints;
    [SerializeField] private List<Transform> _flyingEyeSpawnPoints;

    public List<Transform> SmallSkeletonSpawnPoints => _smallSkeletonSpawnPoints;
    public List<Transform> LargeSkeletonSpawnPoints => _largeSkeletonSpawnPoints;
    public List<Transform> MagicianSpawnPoints => _magicianSpawnPoints;
    public List<Transform> FlyingEyeSpawnpoints => _flyingEyeSpawnPoints;
}
