using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public Camera MainCamera;
    public Transform LookAtPosition;
    float minD = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookAtPoint();
    }

    public void cameraTumble(Vector3 delta)
    {
        //line up
        Quaternion t = Quaternion.AngleAxis(delta.x / 20, transform.up);
        Quaternion p = Quaternion.AngleAxis(delta.y / 20, transform.right);
        Quaternion q = t * p;

        //rotate camera 
        Matrix4x4 r = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);
        transform.localPosition = newCameraPos;
        if (Mathf.Abs(Vector3.Dot(newCameraPos.normalized, Vector3.up)) > .4f) // this is about 45-degrees
        {

        }

        LookAtPoint();
    }

    void LookAtPoint()
    {
        Vector3 p = transform.position - LookAtPosition.position;
        transform.forward = -1 * p; //camera view direction
    }

    public void cameraZoom(float delta)
    {
        Vector3 v = LookAtPosition.localPosition - transform.localPosition;
        float dist = v.magnitude; //distance between camera and lookAt
        //check if camera will surpass lookat 
        if (dist >= minD)
        {
            dist -= delta;
        }
        else
        {
            dist = minD;
        }

        transform.localPosition = LookAtPosition.localPosition - dist * v.normalized;

    }

    public void camTrack(Vector3 delta)
    {
        Vector3 d = delta.x * .15f * transform.right + delta.y * .15f * transform.up; 
        LookAtPosition.localPosition += d;
        transform.localPosition += d;
    }
}
