using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCScript : MonoBehaviour
{
    GameObject aObj;
    ObjBScript aScript;
    // Start is called before the first frame update
    void Start()
    {
        aObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        aObj.transform.position = new Vector3(1, 0, 0);
        aObj.AddComponent<ObjBScript>();
        aScript = GameObject.Find("ObjB").GetComponent<ObjBScript>();
    }
}
