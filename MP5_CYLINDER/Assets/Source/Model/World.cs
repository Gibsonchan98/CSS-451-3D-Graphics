using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * WORLD CLASS
 * 
 * The purpose of the world class is to store global variables
 * used by the user, such as the show vertices boolean value
 * or the selected object.
 */

public class World : MonoBehaviour
{
    public CylinderMesh TheCylinder;
    public Plane ThePlanar;
    public GameObject AxisFrame;

    AxisFrame axis; 
    GameObject selectedObj = null;
    bool showVertices = false;

    Color color;

    void Start()
    {
        AxisFrame.gameObject.transform.GetComponent<Renderer>().material.color = new Color(.2f, .8f, .7f, 0.5f);
    }

    // ================== SETTERS ================== \\
    void SetShowVertices(bool input)
    {
        showVertices = input;
    }

    void SetSelectedObject(GameObject selectedObj)
    {
        this.selectedObj = selectedObj;
    }

    // ================== GETTERS ================== \\
    bool GetShowVertices()
    {
        return showVertices;
    }

    bool SelectedObjectExist()
    {
        if (selectedObj == null)
        {
            return true;
        }
        return false;
    }

    public Plane GetPlane() {
        return ThePlanar;
    }

    public CylinderMesh GetCylinder()
    {
        return TheCylinder;
    }

    public Transform GetAxis() {
        return AxisFrame.transform;
    }

    public void MarkSelected(Transform obj)
    {
        axis = obj.gameObject.GetComponent<AxisFrame>();
        axis.SetSelected();
    }

    public void unSelect(Transform obj)
    {
        //go through all axis 
        foreach (Transform child in obj.transform)
        {
            axis = child.gameObject.GetComponent<AxisFrame>();
            axis.UnSelect();
        }
       
    }

    public void SelectVertice(Transform vert){
        vert.gameObject.transform.GetComponent<Renderer>().material.color = new Color(.2f, .8f, .7f, 0.5f);
    }

    public void unSelectVertice(Transform vert)
    {
        vert.gameObject.transform.GetComponent<Renderer>().material.color = Color.white;
    }
}
