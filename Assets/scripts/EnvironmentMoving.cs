using UnityEngine;

public class EnvironmentMoving : MonoBehaviour
{
    void Update()
    {
        //Environment and path are moving
        transform.position += new Vector3(4, 0, 0) * Time.deltaTime;
    }
}
