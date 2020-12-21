using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld2Helper : MonoBehaviour
{
    public GameObject Aimline1;
    public GameObject Aimline2;
    public GameObject Aimline3;

    public GameObject P1, P2;
    public GameObject lineSegment;

    public GameObject P3, P4;
    public GameObject lineSegment2;

    public GameObject P5, P6;
    public GameObject lineSegment3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SetLineAObject() {
        return Aimline1;
    }

    public GameObject SetLineBObject()
    {
        return Aimline2;
    }

    public GameObject SetLineCObject()
    {
        return Aimline3;
    }

    public GameObject SetLineSegment(float v) {
        if (v == 1)
        {
            return lineSegment;
        }
        else if (v == 2) {
            return lineSegment2;
        } 
        return lineSegment3;
    }

    public GameObject SetP1(float v)
    {
        if (v == 1)
        {
            return P1;
        }
        else if (v == 2)
        {
            return P3;
        }
        return P5;
    }

    public GameObject SetP2(float v)
    {
        if (v == 1)
        {
            return P2;
        }
        else if (v == 2)
        {
            return P4;
        }
        return P6;
    }

}
