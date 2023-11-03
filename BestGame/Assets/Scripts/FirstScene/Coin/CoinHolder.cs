using System;

public class CoinHolder : Singleton<CoinHolder>
{
    private int _coins;
    private SaveLoadManager _saveLoadManager;
    private PlayerData _playerData;

    public int Coins => _coins;

    public void AddCoin(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _coins += value;
        SaveCoins();
    }

    public void SpendMoney(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _coins -= value;
        SaveCoins();
    }

    private void Start()
    {
        _saveLoadManager = new SaveLoadManager();
        LoadCoins();
    }

    private void LoadCoins()
    {
        _coins = _saveLoadManager.Load().coins;
    }

    private void SaveCoins()
    {
        _playerData.coins = _coins;
        _saveLoadManager.Save(_playerData);
    }
}
