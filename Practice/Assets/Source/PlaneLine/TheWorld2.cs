using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld2 : MonoBehaviour
{
    public GameObject ThePlane;
    public GameObject P1, P2; // Ball direction
    public GameObject PlaneNormal; //Normal vector of plane cylinder
    public GameObject Pt;
    public GameObject DistV;
    public GameObject TheSphere;
    // Start is called before the first frame update
    void Start()
    {
        P1.GetComponent<Renderer>().material.color = Color.black;
        P2.GetComponent<Renderer>().material.color = Color.black;
        Pt.GetComponent<Renderer>().material.color = Color.red;
    }

    float kNormakSize = 5f;
    float kVerySmall = .0001f;
    float radius; 
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(P1.transform.localPosition, P2.transform.localPosition, Color.black);

        //plane and normal vector
        Vector3 n = -ThePlane.transform.forward;
        Vector3 center = ThePlane.transform.localPosition;
        float d = Vector3.Dot(n, center); //D = P dot n 

        Vector3 V = P2.transform.localPosition - P1.transform.localPosition; //velocity
        V.Normalize(); //get direction

        //intersection distant,
        float denom = Vector3.Dot(n, V);
        if (Mathf.Abs(denom) < kVerySmall)
        {
            Pt.GetComponent<Renderer>().enabled = false;
        }
        else {
            Pt.GetComponent<Renderer>().enabled = true;
        }

        //intersection distant 
        float t1 = (d - Vector3.Dot(n, P1.transform.localPosition)) / denom; //Distance traveled from P1 to Plabe
        Pt.transform.localPosition = P1.transform.localPosition + t1 * V;

        //normal 
        PlaneNormal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, n);
        PlaneNormal.transform.localPosition = ThePlane.transform.localPosition + (kNormakSize * PlaneNormal.transform.up);

        Vector3 dist= (ThePlane.transform.localPosition - Pt.transform.localPosition);

      //  DistV.transform.localRotation = Quaternion.FromToRotation(Vector3.up, dist);
       // DistV.transform.localPosition = ThePlane.transform.localPosition + (kNormakSize * PlaneNormal.transform.up);

        Debug.DrawLine(ThePlane.transform.localPosition, Pt.transform.localPosition, Color.blue);

        radius = TheSphere.transform.localScale.x * 0.5f;  //The plane.scale * .5f;

        float distMag = dist.magnitude;
        if (distMag < ThePlane.transform.localScale.y * .5f) {
            Debug.Log("It is in");
        }
       // DistV.transform.localScale.y = distMag; 
    }
}
