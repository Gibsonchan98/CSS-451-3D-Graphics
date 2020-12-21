using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLine : MonoBehaviour
{
    public Transform P1, P2;

    private float LineWidth = 3f; //radius 1.5
    // Start is called before the first frame update
    void Start()
    {
        //set initial locations
        P1.localPosition = new Vector3(-5f, 0, 14.75f); //back
        P2.localPosition = new Vector3(-11.05f, -4.8f, 2); //floor
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V = P2.localPosition - P1.localPosition;
        float len = V.magnitude;

        transform.localPosition = P1.localPosition + 0.5f * V; //sets it in the middle
        transform.localScale = new Vector3(LineWidth, len * 0.5f, LineWidth);
        transform.localRotation = Quaternion.FromToRotation(Vector3.up, V);
    }

    //move Back Endpoint
    public void MoveToNewPositionB(Vector3 hitpoint)
    {
        Vector3 temp = hitpoint;
        temp.z = 14.75f; //always stay on back wall
        //Check if in bound
        if (hitpoint.y > 10.98f)
        {
            temp.y = 10.98f;
        }
        else if (hitpoint.y < -3.91f)
        {
            temp.y = -3.91f;
        }

        if (hitpoint.x < -56f)
        {
            temp.x = -19f;
        }
        else if (hitpoint.x > -39) {
            
            temp.x = 11.54f;
        }

        temp.x = temp.x/2.8f;
        P1.localPosition = temp;

    }

    //move Floor Endpoint
    public void MoveToNewPositionF(Vector3 hitpoint)
    {
        Vector3 temp = hitpoint;
        //always stay on floor
        temp.y = -4.8f;
        //Check if in bound
        Debug.Log(hitpoint.x);
        if (hitpoint.x > -40f)
        {
            temp.x = 11.34f;
        }
        else if (hitpoint.x < -70)
        {
            temp.x = -20f;
        }

        else if (hitpoint.z > 13.58f)
        {
            temp.z = 13.98f;
        }
        else if (hitpoint.z < -13f)
        {
            temp.z = -13f;
        }

        temp.x = temp.x/2.8f;
        P2.localPosition = temp;
    }

    public Vector3 BigP1() {
        return P1.localPosition; 
    }

    public Vector3 BigP2()
    {
        return P2.localPosition;
    }

}
