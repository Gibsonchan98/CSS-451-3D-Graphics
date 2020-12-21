using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtControl : MonoBehaviour
{
    public Transform LookAt;
    public SliderWithEcho X, Y, Z;

    private Vector3 mPreviousSliderValues = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        X.SetSliderListener(XChanged);
        Y.SetSliderListener(YChanged);
        Z.SetSliderListener(ZChanged);
    }
    void XChanged(float n)
    {
        Vector3 p = ReadObjectXform();
        mPreviousSliderValues.x = n;
        p.x = n;
        UISetObjectXform(ref p);
    }

    void YChanged(float n)
    {
        Vector3 p = ReadObjectXform();
        mPreviousSliderValues.y = n;
        p.y = n;
        UISetObjectXform(ref p);
    }

    void ZChanged(float n)
    {
        Vector3 p = ReadObjectXform();
        mPreviousSliderValues.z = n;
        p.z = n;
        UISetObjectXform(ref p);
    }
    // Update is called once per frame
    void Update()
    {
         
        Debug.Log(LookAt.name);
        
    }

    Vector3 ReadObjectXform() {
        Vector3 p;
        p = LookAt.localPosition;
        return p;
    }

    void UISetObjectXform(ref Vector3 p) {
        LookAt.localPosition = p;
    }
}
