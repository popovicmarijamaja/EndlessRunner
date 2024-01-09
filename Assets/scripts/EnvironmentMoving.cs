using UnityEngine;

public class EnvironmentMoving : MonoBehaviour
{
    private static float Speed;
    private const string TurnEnvironmentOffTag = "turnEnvironmentOff";
    private void Start()
    {
        Speed = 4;
    }
    private void Update()
    {
        //Environment is moving
        transform.position += Time.deltaTime * Speed * Vector3.right;
        Speed += GameManager.SpeedIncreasing * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TurnEnvironmentOffTag))
        {
            gameObject.SetActive(false);
        }
    }
}
