using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld2 : MonoBehaviour
{
    AimLine line;
    Aimline2 line2;
    Aimline3 line3;
    BigLine bLine;
    public GameObject lineSegment;
    public GameObject BigLine;
    public GameObject P1, P2;
    public GameObject ThePlane;


    TravellerExtra newObject;
    Vector3 velocity = Vector3.zero;
    float D = 0;

    // Start is called before the first frame update
    void Start()
    {
        bLine = BigLine.GetComponent<BigLine>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if clicked on left wall
    public void MoveLeftPointer(Vector3 pos)
    {
        if (P1.name == "LineEndPtL2")
        {
            line2.MoveToNewPositionL(pos);
        }
        if (P1.name == "LineEndPtL3")
        {
            line3.MoveToNewPositionL(pos);
        }
        else
        {
            line.MoveToNewPositionL(pos);
        }
    }


    //if clicked on right wall
    public void MoveRightPointer(Vector3 pos)
    {

        if (P1.name == "LineEndPtL2")
        {
            line2.MoveToNewPositionR(pos);
        }
        if (P1.name == "LineEndPtL3")
        {
            line3.MoveToNewPositionR(pos);
        }
        else
        {
            line.MoveToNewPositionR(pos);
        }
    }

    //if clicked on back
    public void MoveBackPointer(Vector3 pos)
    {
        bLine.MoveToNewPositionB(pos);
    }


    //if clicked on floor
    public void MoveFloorPointer(Vector3 pos)
    {
        bLine.MoveToNewPositionF(pos);
    }

    public void SetMovement(float time)
    {
        ComputeVelocity();
        newObject.SetSpeed(time, D, velocity);
        newObject.setPoints(bLine.BigP1(), bLine.BigP2());
    }

    public void setSpan(float lifespan)
    {
        newObject.SetLife(lifespan);
    }

    public GameObject CreateObject(float timer, float lifetime)
    {

        GameObject sphere = Instantiate(Resources.Load("Travelling2")) as GameObject;

        //Just to set up correct position at center of endpoint
        sphere.transform.position = P1.transform.position;

        newObject = sphere.GetComponent<TravellerExtra>();


        setVectors();
        setSpan(lifetime);
        setBarrier();
        SetMovement(timer);


        return sphere;
    }

    public void setVectors()
    {
        Vector3 pos = ThePlane.transform.localPosition;
        Vector3 n = -ThePlane.transform.forward;
        Vector3 size = ThePlane.transform.localScale;
        newObject.SetVectors(n, pos, size);
    }

    private void ComputeVelocity()
    {
        velocity = P2.transform.localPosition - P1.transform.localPosition;
        D = velocity.magnitude;
        velocity.Normalize();

    }


    public GameObject ThisPlane()
    {
        return ThePlane;
    }

    public void setBarrier()
    {
        
        newObject.setBarrier(ThePlane);
    }

    public void SetLineSegment(GameObject PA, GameObject PB, GameObject l) {
        P1 = PA;
        P2 = PB;
        lineSegment = l;

        if (PA.name == "LineEndPtL2") {
            line2 = lineSegment.GetComponent<Aimline2>();
        }
        if (PA.name == "LineEndPtL3")
        {
            line3 = lineSegment.GetComponent<Aimline3>();
        }
        else {
            line = lineSegment.GetComponent<AimLine>();
        }
    }
}
