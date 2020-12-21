using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithPlane : MonoBehaviour
{
    public GameObject ThePlane = null;
    public GameObject Normal;

    float Size = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Normal = Instantiate(Resources.Load("NormalLine")) as GameObject;
        //turn off shadows
        transform.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        GameObject temp = transform.GetChild(0).gameObject; 
        temp.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 n = -ThePlane.transform.forward;
        Vector3 center = ThePlane.transform.localPosition;
        float d = Vector3.Dot(n, center);

        Normal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, n);
        Normal.transform.localPosition = ThePlane.transform.localPosition + (Size * Normal.transform.up);
    }
}
