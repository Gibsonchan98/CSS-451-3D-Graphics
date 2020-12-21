using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlane : MonoBehaviour
{
    public GameObject ThePlane;
    public GameObject ThePoint;
    public GameObject PlaneNormal;
    public GameObject Projected;
    // Start is called before the first frame update
    void Start()
    {
        ThePoint.GetComponent<Renderer>().material.color = Color.black;
        Projected.GetComponent<Renderer>().material.color = Color.red;
    }

    float kNormakSize = 5f;
    float kMaxProjectedSize = 10f;
    // Update is called once per frame
    void Update()
    {

        //plane and normal vector
        Vector3 n = -ThePlane.transform.forward;
        Vector3 center = ThePlane.transform.localPosition;
        Vector3 pt = center + kNormakSize * n;
        float d = Vector3.Dot(n, center); //D = P dot n 

        float h = Vector3.Dot(ThePoint.transform.localPosition, n) - d;  //perpendicular distance between point and plane
        Projected.transform.localPosition = ThePoint.transform.localPosition - (n * h);
        float s = h * .50f;
        if (s < 0) {
            s = .5f;
            //behind the plane

        }

        Projected.transform.localScale = new Vector3(s, s, s);
        Debug.DrawLine(Projected.transform.localPosition, ThePoint.transform.localPosition, Color.black);
        //intersection distant, how far Pt is from plane

        float size = h / 2;
        Vector3 scale = PlaneNormal.transform.localScale;
        scale.y = size;
        PlaneNormal.transform.localScale = scale;
        //normal 
        PlaneNormal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, n);
        PlaneNormal.transform.localPosition = ThePlane.transform.localPosition + (kNormakSize * PlaneNormal.transform.up);


        Debug.DrawLine(center, pt, Color.black);

    }
}
