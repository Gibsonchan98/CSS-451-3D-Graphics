using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{
    public GameObject shadowW;
    Vector3 P1, P2; //bigline endpoints
    Vector3 V1, Va, Ph; //mDir, Pa-P1, projected position

    float distant = 0;
    float Vmag = 0;
    Vector3 velocity = Vector3.zero;


    float radiusB = 1.5f;
    float  d;

    Vector3 nB;
    // Start is called before the first frame update
    void Start()
    {
        //turn off shadows
        shadowW = Instantiate(Resources.Load("WhiteShadow")) as GameObject;
        shadowW.GetComponent<Renderer>().enabled = false;
        shadowW.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    public void setVelocity(Vector3 velo){
        velocity = velo;
    }

    // Update is called once per frame
    void Update()
    {
        V1 = P1 - P2;
        Vmag = V1.magnitude;
        V1.Normalize();

        Va = transform.localPosition - P1;
        d = Vector3.Dot(Va, V1);

        Ph = P1 + d * V1;

        //if within cylinder length 
        if (d > 0 && d < Vmag) {
            distant = Mathf.Sqrt(Va.sqrMagnitude - d * d); //perpendicular length
            if (distant < 10)
            {
                //show shadow
                Ph = P1 + d * V1;
                Vector3 Pc = Ph + distant * (transform.localPosition - Ph).normalized;
                shadowW.transform.localPosition = Pc;
                shadowW.GetComponent<Renderer>().enabled = true;
                nB = transform.localPosition - Ph;
                if (nB.magnitude < radiusB) {
                    velocity = 2 * Vector3.Dot(-velocity, nB) * nB - (-velocity);
                }
            }
            else {
                shadowW.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    public Vector3 NewVelocity() {
        return velocity;
    }

    public void setPoints(Vector3 A, Vector3 B) {
        P1 = A;
        P2 = B;
    }
}
