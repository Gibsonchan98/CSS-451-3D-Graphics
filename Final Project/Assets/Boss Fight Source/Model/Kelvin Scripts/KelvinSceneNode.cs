using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinSceneNode : MonoBehaviour
{
    protected Matrix4x4 mCombinedParentXform;

    public Vector3 NodeOrigin = Vector3.zero;
    public List<KelvinNodePrimitive> PrimitiveList;

    public GameObject InvisibleProjectile;

    // Use this for initialization
    protected void Start()
    {
        InitializeSceneNode();
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
            KelvinSceneNode cn = child.GetComponent<KelvinSceneNode>();
            if (cn != null)
            {
                cn.CompositeXform(ref mCombinedParentXform);
            }
        }

        // disenminate to primitives
        foreach (KelvinNodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref mCombinedParentXform);
        }
    }

    public Matrix4x4 GetMatrix()
    {
        return mCombinedParentXform;
    }

    public KelvinNodePrimitive GetChild()
    {
        return PrimitiveList[0];
    }

    public void SetChild(KelvinNodePrimitive child)
    {
        PrimitiveList.Insert(0, child);
        foreach (KelvinNodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref mCombinedParentXform);
        }
    }
}
