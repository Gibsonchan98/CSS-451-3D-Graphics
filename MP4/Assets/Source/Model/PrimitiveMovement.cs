using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveMovement : MonoBehaviour
{
    private const float kRotateDelta = 45; // per second
    Vector3 Dir;
    string Name;
    float max;
    void Start()
    {
        Name = gameObject.name;
        switch (Name)
        {
            case "SphereR": //if it is a sphere
                Dir = transform.up;
                max = 14;
                break;
            case "CubeR":  //if it is a cube
                Dir = transform.right;
                max = 90;
                break;
            default:        //if it is a capsule 
                Dir = transform.right;
                max = 180;
                break;
        }
     
            
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currRot = transform.localRotation.eulerAngles;

        switch (Name)
        {
            case "SphereR": //if it is a sphere
                if (Mathf.Abs(currRot.x) < max)
                {
                    Dir *= -1;
                }
                break;
            case "CubeR":  //if it is a cube
                if (Mathf.Abs(currRot.x) > max)
                {

                    Dir *= -1;
                }
                break;
            default:        //if it is a capsule 
                if (Mathf.Abs(currRot.y) > max)
                {
                    
                    Dir *= -1;
                }
                break;
        }

        //rotation
        
        Quaternion q = Quaternion.AngleAxis(kRotateDelta * Time.fixedDeltaTime, Dir);
        transform.localRotation = q * transform.localRotation;

    }
}
