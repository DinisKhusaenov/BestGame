using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private static int _coins;

    public static void AddCoin()
    {
        _coins++;
    }
}
