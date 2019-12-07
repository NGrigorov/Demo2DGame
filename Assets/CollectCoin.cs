using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public TextMeshProUGUI tmpScore;
    private int Coins = 0;
    // Start is called before the first frame update
    void setCoins()
    {
        tmpScore.text = Coins.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            Coins++;
            setCoins();
            
        }
    }
}
