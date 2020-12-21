using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CylinderMesh : MonoBehaviour
{
    GameObject[] mControllers;

    void InitControllers(Vector3[] v)
    {
        mControllers = new GameObject[v.Length];
        for (int i = 0; i < v.Length; i++)
        {
            mControllers[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mControllers[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            mControllers[i].transform.localPosition = v[i];
            mControllers[i].transform.parent = this.transform;
            //Edge vertices on cylinder
            if (i % (N + 1) == 0)
            {
                mControllers[i].GetComponent<Renderer>().material.color = Color.white;
                mControllers[i].tag = "Vertice";
                //Set name to identify cylinder layer 
                mControllers[i].name = i.ToString();
            }
            else
                mControllers[i].GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
