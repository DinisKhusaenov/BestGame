using UnityEngine;

public class FireballSpawner
{
    private FireballFactory _factory;

    public FireballSpawner(FireballFactory factory)
    {
        _factory = factory;
    }

    public void Spawn(int direction, Transform spawnPosition, float attackTime)
    {
        Fireball fireball = _factory.Get();
        fireball.transform.position = spawnPosition.position;
        fireball.Launch(direction, attackTime);
    }
}
