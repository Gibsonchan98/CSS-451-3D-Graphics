using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNode : MonoBehaviour
{
    protected Matrix4x4 mCombinedParentXform;

    public Vector3 NodeOrigin = Vector3.zero;
    public List<NodePrimitive> PrimitiveList;

    public Camera smallCam;

    // Use this for initialization
    protected void Start()
    {
        InitializeSceneNode();
        // Debug.Log("PrimitiveList:" + PrimitiveList.Count);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InitializeSceneNode()
    {
        mCombinedParentXform = Matrix4x4.identity;
    }

    // This must be called _BEFORE_ each draw!! 
    public void CompositeXform(ref Matrix4x4 parentXform)
    {
        Matrix4x4 orgT = Matrix4x4.Translate(NodeOrigin);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        mCombinedParentXform = parentXform * orgT * trs;

        // propagate to all children
        foreach (Transform child in transform)
        {
            SceneNode cn = child.GetComponent<SceneNode>();
            if (cn != null)
            {
                cn.CompositeXform(ref mCombinedParentXform);
            }
        }

        // disenminate to primitives
        foreach (NodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref mCombinedParentXform);
        }

        if (smallCam != null)
        {
            smallCam.transform.localPosition = new Vector3(mCombinedParentXform.GetColumn(3).x - .5f, mCombinedParentXform.GetColumn(3).y, mCombinedParentXform.GetColumn(3).z);
            //smallCam.transform.localPosition += (mCombinedParentXform.GetColumn(3).y - 6f) * Vector3.up;
            smallCam.transform.localRotation = Quaternion.FromToRotation(smallCam.transform.up, transform.up) * smallCam.transform.localRotation;
            smallCam.transform.localRotation = Quaternion.FromToRotation(smallCam.transform.right, transform.right) * smallCam.transform.localRotation;
        }

    }

    public Matrix4x4 GetMatrix() {
        return mCombinedParentXform;
    }
}
