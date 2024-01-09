using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject leftPos;
    [SerializeField] private GameObject centrePos;
    [SerializeField] private GameObject rightPos;
    private void Update()
    {
        //Defining in witch row player is moving
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position == centrePos.transform.position)
        {
            transform.position = rightPos.transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position == leftPos.transform.position)
        {
            transform.position = centrePos.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == centrePos.transform.position)
        {
            transform.position = leftPos.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == rightPos.transform.position)
        {
            transform.position = centrePos.transform.position;
        }
    }
}
