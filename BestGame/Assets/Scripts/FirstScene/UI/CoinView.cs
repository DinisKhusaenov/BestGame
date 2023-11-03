using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private TMP_Text _cointText;
    [SerializeField] private CoinHolder _coinHolder;

    private void OnEnable()
    {
        Coin.OnCoinsChanged += ChangeText;
    }

    private void OnDisable()
    {
        Coin.OnCoinsChanged -= ChangeText;
    }

    private void Start()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        _cointText.text = _coinHolder.Coins.ToString();
    }
}
