using UnityEngine;

public class GemCollectible : MonoBehaviour
{
    public static int gemCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gemCount++;
            GemCount.Instance.UpdateGemCount(gemCount);
            Destroy(gameObject);
        }
    }
}
