using UnityEngine;

public class EnvironmentCollision : MonoBehaviour
{
    [SerializeField] private GameObject child;
    private const string TurnEnvironmentOffTag = "turnEnvironmentOff";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TurnEnvironmentOffTag))
        {
            child.GetComponent<SpawnManager>().SpawnRock();
            child.GetComponent<SpawnManager>().SpawnCoin();
        }
    }
}
