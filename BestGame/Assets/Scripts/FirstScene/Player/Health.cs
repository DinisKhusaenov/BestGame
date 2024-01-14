using System;

public class Health : IHealthStat
{
    public event Action Died;

    public Health(PlayerConfig config)
    {
        MaxHealth = Value = config.MaxHealth;
    }

    public int MaxHealth { get; }
    public int Value { get; private set; }

    public void Reduce(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value -= value;

        if (Value < 0)
        {
            Value = 0;
            Died?.Invoke();
        }
    }

    public void Add(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value += value;

        if (Value > MaxHealth)
            Value = MaxHealth;
    }
}
