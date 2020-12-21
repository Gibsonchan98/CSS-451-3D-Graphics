using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XformControl : MonoBehaviour {
    public Toggle T, R, S;
    public SliderWithEcho1 X, Y, Z;
    public Text ObjectName;

    private bool lockX = false;
    private bool lockY = false;
    private bool lockZ = false;

    public Plane mSelected;
    private Vector3 mPreviousSliderValues = Vector3.zero;

    public float xPos, yPos;
    public float xScal, yScal;
    public float rotation;

	// Use this for initialization
	void Start () {
        xPos = 0f;
        yPos = 0f;
        xScal = 1f;
        yScal = 1f;
        rotation = 0f;


        T.onValueChanged.AddListener(SetToTranslation);
        R.onValueChanged.AddListener(SetToRotation);
        S.onValueChanged.AddListener(SetToScaling);
        X.SetSliderListener(XValueChanged);
        Y.SetSliderListener(YValueChanged);
        Z.SetSliderListener(ZValueChanged);

        T.isOn = true;
        R.isOn = false;
        S.isOn = false;
        SetToTranslation(true);

        X.SetSliderValue(xPos);
        Y.SetSliderValue(yPos);
        Z.SetSliderValue(0);

	}
	
    //---------------------------------------------------------------------------------
    // Initialize slider bars to specific function
    void SetToTranslation(bool v)
    {
        //Vector3 p = ReadObjectXfrom();
        //mPreviousSliderValues = p;
        X.InitSliderRange(-20, 20, xPos);
        Y.InitSliderRange(-20, 20, yPos);
        Z.InitSliderRange(-20, 20, 0);
        lockZ = true;
        lockX = false;
        lockY = false;
    }

    void SetToScaling(bool v)
    {
        //Vector3 s = ReadObjectXfrom();
        //mPreviousSliderValues = s;
        X.InitSliderRange(0.1f, 20, xScal);
        Y.InitSliderRange(0.1f, 20, yScal);
        Z.InitSliderRange(0.1f, 20, 0);
        lockX = false;
        lockY = false;
        lockZ = true;
    }

    void SetToRotation(bool v)
    {
        //Vector3 r = ReadObjectXfrom();
        //mPreviousSliderValues = r;
        X.InitSliderRange(-180, 180, 0);
        Y.InitSliderRange(-180, 180, 0);
        Z.InitSliderRange(-180, 180, rotation);
        //mPreviousSliderValues = r;
        lockX = true;
        lockY = true;
        lockZ = false;
    }
    //---------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------
    // resopond to sldier bar value changes
    void XValueChanged(float v)
    {
        if (lockX) {
            X.SetSliderValue(0);
        } else {

            if (T.isOn) {
                xPos = v;
            } else if (S.isOn) {
                xScal = v;
            }
            /*
            Vector3 p = ReadObjectXfrom();
            // if not in rotation, next two lines of work would be wasted
                float dx = v - mPreviousSliderValues.x;
                mPreviousSliderValues.x = v;
                Quaternion q = Quaternion.AngleAxis(dx, Vector3.right);
            p.x = v;
            UISetObjectXform(ref p, ref q);*/
            
            mSelected.SetUVMatrixTransform(Matrix3x3Helpers.CreateTRS(new Vector2(xPos, yPos), rotation, new Vector2(xScal, yScal)));
            mSelected.ApplyUVTransform();
        }
    }
    
    void YValueChanged(float v)
    {
        if (lockY) {
            Y.SetSliderValue(0);
        } else {

            if (T.isOn) {
                yPos = v;
            } else if (S.isOn) {
                yScal = v;
            }

            /*
            Vector3 p = ReadObjectXfrom();
                // if not in rotation, next two lines of work would be wasted
                float dy = v - mPreviousSliderValues.y;
                mPreviousSliderValues.y = v;
                Quaternion q = Quaternion.AngleAxis(dy, Vector3.up);
            p.y = v;        
            UISetObjectXform(ref p, ref q);
            */
            mSelected.SetUVMatrixTransform(Matrix3x3Helpers.CreateTRS(new Vector2(xPos, yPos), rotation, new Vector2(xScal, yScal)));
            mSelected.ApplyUVTransform();
        }
    }

    void ZValueChanged(float v)
    {
        if (lockZ) {
            Z.SetSliderValue(0);
        }  else {

            if (R.isOn) {
                rotation = v;
            }

            /*
            Vector3 p = //ReadObjectXfrom();
                // if not in rotation, next two lines of work would be wasterd
                float dz = v - mPreviousSliderValues.z;
                mPreviousSliderValues.z = v;
                Quaternion q = Quaternion.AngleAxis(dz, Vector3.forward);
            p.z = v;
            */
            mSelected.SetUVMatrixTransform(Matrix3x3Helpers.CreateTRS(new Vector2(xPos, yPos), rotation, new Vector2(xScal, yScal)));
            mSelected.ApplyUVTransform();
            //UISetObjectXform(ref p, ref q);
        }
    }
    //---------------------------------------------------------------------------------

    // new object selected
    public void SetSelectedObject(Plane xform)
    {
        mSelected = xform;
        mPreviousSliderValues = Vector3.zero;
        if (xform != null)
            ObjectName.text = "Selected:" + xform.name;
        else
            ObjectName.text = "Selected: none";
        ObjectSetUI();
    }

    public void ObjectSetUI()
    {
        Vector3 p = new Vector3(xPos, yPos, 0); //ReadObjectXfrom();
        X.SetSliderValue(p.x);  // do not need to call back for this comes from the object
        Y.SetSliderValue(p.y);
        Z.SetSliderValue(p.z);
    }

    /*
    private Vector3 ReadObjectXfrom()
    {
        Vector3 p;
        
        if (T.isOn)
        {
            if (mSelected != null)
                p = mSelected.localPosition;
            else
                p = Vector3.zero;
        }
        else if (S.isOn)
        {
            if (mSelected != null)
                p = mSelected.localScale;
            else
                p = Vector3.one;
        }
        else
        {
            p = Vector3.zero;
        }
        return p;
    }*/

    /*
    private void UISetObjectXform(ref Vector3 p, ref Quaternion q)
    {
        if (mSelected == null)
            return;

        if (T.isOn)
        {
            mSelected.localPosition = p;
        }
        else if (S.isOn)
        {
            mSelected.localScale = p;
        } else
        {
            mSelected.localRotation *= q;
        }
    }
    */
}