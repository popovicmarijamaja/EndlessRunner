using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private const string RockTag = "rock";
    private const string CoinTag = "coin";
    private const string NewSectionTag = "newSection";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(RockTag))
        {
            GameManager.Instance.GameOver();
        }
        if (other.gameObject.CompareTag(CoinTag))
        {
            GameManager.Instance.CoinCollect();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag(NewSectionTag))
        {
            GameManager.Instance.SpawnNewSection();
        }
    }
}
