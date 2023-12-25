using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Defining rows
    private Vector3 rightPos = new Vector3(12, 0, 1);
    private Vector3 centrePos = new Vector3(12, 0, 0);
    private Vector3 leftPos = new Vector3(12, 0, -1);
    // Update is called once per frame
    void Update()
    {
        //Defining in witch row player is moving
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position == centrePos)
        {
            transform.position = rightPos;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position == leftPos)
        {
            transform.position = centrePos;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == centrePos)
        {
            transform.position = leftPos;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == rightPos)
        {
            transform.position = centrePos;
        }
    }
}
