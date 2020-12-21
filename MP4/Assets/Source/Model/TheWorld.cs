using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class TheWorld : MonoBehaviour
{
    public SceneNode TheRoot;
    public GameObject LookAt;
    public AxisFrame AxisFrame;
    private void Start()
    {

    }

    private void Update()
    {
        Matrix4x4 i = Matrix4x4.identity;
        TheRoot.CompositeXform(ref i);
    }

    public void setAxisLocation(SceneNode node, Transform node2) {
        AxisFrame.SetLocation(node.GetMatrix(), node2);
    }
}
