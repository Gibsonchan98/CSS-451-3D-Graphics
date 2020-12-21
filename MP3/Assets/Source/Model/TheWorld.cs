using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    AimLine line;
    public GameObject lineSegment;
    public GameObject P1,P2;
    public GameObject ThePlane;

    private GameObject mPrefab;
    TravellingBall newObject;
    Vector3 velocity = Vector3.zero;
    float D = 0;

    // Start is called before the first frame update
    void Start()
    {
        line = lineSegment.GetComponent<AimLine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if clicked on left wall
    public void MoveLeftPointer(Vector3 pos) {
        line.MoveToNewPositionL(pos);
    }


    //if clicked on right wall
    public void MoveRightPointer(Vector3 pos) {
        line.MoveToNewPositionR(pos);
    }

    public void SetMovement(float time) {
        ComputeVelocity();
        newObject.SetSpeed(time, D, velocity);
    }

    public void setSpan(float lifespan) {
        newObject.SetLife(lifespan);
    }

    public GameObject CreateObject(float timer, float lifetime) { 

        GameObject sphere = Instantiate(Resources.Load("TravellingBall")) as GameObject;

        //Just to set up correct position at center of endpoint
        sphere.transform.position = P1.transform.position;

        newObject = sphere.GetComponent<TravellingBall>();

        setVectors();
        setSpan(lifetime);
        setBarrier();
        SetMovement(timer);
        

        return sphere;
    }

    public void setVectors() {
        Vector3 pos = ThePlane.transform.localPosition;
        Vector3 n = -ThePlane.transform.forward;
        Vector3 size = ThePlane.transform.localScale;
        newObject.SetVectors(n, pos,size);
    }

    private void ComputeVelocity()
    {
        velocity = P2.transform.localPosition - P1.transform.localPosition;
        D = velocity.magnitude;
        velocity.Normalize();

    }


    public GameObject ThisPlane() {
        return ThePlane; 
    }

    public void setBarrier() {
        newObject.setBarrier(ThePlane);
    }
}
