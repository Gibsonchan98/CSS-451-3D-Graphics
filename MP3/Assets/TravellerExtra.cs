using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellerExtra : MonoBehaviour
{
    public GameObject shadow;
    public GameObject Barrier;
    float t = 80;
    float D = 0;
    Vector3 velocity = Vector3.zero;
    float span = 10f;

    public GameObject shadowW;
    Vector3 P1, P2; //bigline endpoints
    Vector3 V1, Va, Ph; //mDir, Pa-P1, projected position

    float distant = 0;
    float Vmag = 0;

    float radiusB = 1.5f;
    float d;

    Vector3 nB;

    Vector3 V, N;
    float radius;
    float planeS;

    Vector3 center;
    Vector3 n;

    private void Start()
    {
        //turn off shadows
        shadow = Instantiate(Resources.Load("Shadow")) as GameObject;
        shadow.GetComponent<Renderer>().enabled = false;
        transform.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        shadow.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        shadowW = Instantiate(Resources.Load("WhiteShadow")) as GameObject;
        shadowW.GetComponent<Renderer>().enabled = false;
        shadowW.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

    }

    private void Update()
    {
        transform.localPosition += (D / t) * velocity;
        Destroy(gameObject, span);
        float d = Vector3.Dot(n, center); //D = P dot n 
        float denom = Vector3.Dot(n, velocity);
        N = -Barrier.transform.forward;
        N.Normalize();
        //intersection


        //intersection distant 
        float t1 = (d - Vector3.Dot(n, transform.localPosition)) / denom; //Distance traveled from P1 to Plane
        Vector3 tempPos = transform.localPosition + t1 * velocity;

        //distance between obj and center
        V = transform.position - center;

        //distance between hitpoint and center
        Vector3 dist = (center - tempPos);
        float distMag = dist.magnitude;

        //perpendicular distcance from point to plane
        float h = Vector3.Dot(transform.localPosition, n) - d;

        //set shadow to that position
        shadow.transform.localPosition = transform.localPosition - (n * h);
        shadow.transform.forward = n;

        //Get distance from shadow position to center of plane
        Vector3 check = shadow.transform.localPosition - center;
        float within = check.magnitude;

        float inFront = Vector3.Dot(N, V);
        //if in front of plane
        if (inFront > 0)
        {
            if (distMag < planeS)
            {
                //if it is moving towards from plane
                if (Vector3.Dot(velocity, N) < 0)
                {
                    if (t1 < .8f) //smallest value before it goes behind plane
                    { //if it hits point on plane
                        setNewVelocity();
                    }
                }

                if (distMag < radius)
                {
                    if (within < radius)
                    {

                        shadow.GetComponent<Renderer>().enabled = true;
                        float s = h * .50f;
                        if (s < 0)
                        {
                            shadow.GetComponent<Renderer>().enabled = false;
                        }

                    }
                    else
                    {
                        shadow.GetComponent<Renderer>().enabled = false;
                    }

                }
                else
                {
                    shadow.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                shadow.GetComponent<Renderer>().enabled = false;
            }

        }
        else
        {
            shadow.GetComponent<Renderer>().enabled = false;
        }

        //Big Line code 
        V1 = P1 - P2;
        Vmag = V1.magnitude;
        V1.Normalize();

        Va = transform.localPosition - P1;
        d = Vector3.Dot(Va, V1);

        Ph = P1 + d * V1;

        //if within cylinder length 
        if (d > 0 && d < Vmag)
        {
            distant = Mathf.Sqrt(Va.sqrMagnitude - d * d); //perpendicular length
            if (distant < 10)
            {
                //show shadow
                Ph = P1 + d * V1;
                Vector3 Pc = Ph + distant * (transform.localPosition - Ph).normalized;
                shadowW.transform.localPosition = Pc;
                shadowW.GetComponent<Renderer>().enabled = true;
                nB = transform.localPosition - Ph;
                if (nB.magnitude < radiusB)
                {
                    velocity = 2 * Vector3.Dot(-velocity, nB) * nB - (-velocity);
                }
            }
            else
            {
                shadowW.GetComponent<Renderer>().enabled = false;
            }
        }

    }

    public void SetLife(float lifeSpan)
    {
        span = lifeSpan;
    }

    public void SetSpeed(float t2, float D2, Vector3 velocity2)
    {
        D = D2;
        t = t2;
        velocity = velocity2;
    }

    public void SetVectors(Vector3 normal, Vector3 centerPos, Vector3 size)
    {
        n = normal;
        center = centerPos;
        radius = size.y * .5f;
        planeS = size.x - 5.8f;
    }

    public void setBarrier(GameObject plane)
    {
        Barrier = plane;
    }

    public void setNewVelocity()
    {
        Vector3 r = velocity - 2 * (Vector3.Dot(velocity, n)) * n;
        r.Normalize();
        velocity = r;
    }

    public void setPoints(Vector3 A, Vector3 B)
    {
        P1 = A;
        P2 = B;
    }
}
