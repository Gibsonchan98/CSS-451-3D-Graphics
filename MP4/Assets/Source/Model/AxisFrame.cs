using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisFrame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLocation(Matrix4x4 parentXform, Transform node) {
        transform.localPosition = new Vector3(parentXform.GetColumn(3).x, parentXform.GetColumn(3).y, parentXform.GetColumn(3).z);
        transform.localRotation = Quaternion.FromToRotation(transform.up, node.up) * transform.localRotation;
        transform.localRotation = Quaternion.FromToRotation(transform.right, node.right) * transform.localRotation;
    }
}
