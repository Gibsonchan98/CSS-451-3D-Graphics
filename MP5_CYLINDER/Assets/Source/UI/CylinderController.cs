using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderController : MonoBehaviour
{
    public SliderWithEcho rot, reso, M, N, elong;
    CylinderMesh Cylinder = null;

    // Start is called before the first frame update
    void Start()
    {
        rot.SetSliderListener(setRotation);
        reso.SetSliderListener(setResolution);
        M.SetSliderListener(AlterM);
        N.SetSliderListener(AlterN);
        elong.SetSliderListener(Elongate);
    }

    public void setObject(CylinderMesh obj) {
        Cylinder = obj;
    }

    void setRotation(float val)
    {
        Cylinder.setRotation(val);
    }

    void setResolution(float value){
        Cylinder.ResetMesh();
        Cylinder.ResolutionChange((int)value - 1);
    }

    void AlterM(float value){
        Cylinder.ResetMesh();
        Cylinder.AlterM((int)value - 1);
    }

    void AlterN(float value) {
        Cylinder.ResetMesh();
        Cylinder.AlterN((int)value - 1);
    }

    void Elongate(float value) {
        Cylinder.ResetMesh();
        Cylinder.Elongate((int)value);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //show vertices and normals
            foreach (Transform child in Cylinder.gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else {
            foreach (Transform child in Cylinder.gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
