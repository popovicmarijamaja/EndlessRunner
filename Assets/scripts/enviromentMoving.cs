using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviromentMoving : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Environment and path is moving
        transform.position += new Vector3(4, 0, 0) * Time.deltaTime;
    }
}
