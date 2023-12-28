using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Defining rows
    private Vector3 rightPos = new (12, 0, 1);
    private Vector3 centrePos = new (12, 0, 0);
    private Vector3 leftPos = new (12, 0, -1);
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
