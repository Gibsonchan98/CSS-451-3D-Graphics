using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public partial class MainController : MonoBehaviour
{
    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;
    Vector3 newPosition = Vector3.zero;
    Transform selected = null;
    Transform axis = null;

    void MouseClickEvents_Cylinder()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Drag Event 
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();

                mouseDownPos = Input.mousePosition;
                delta = Vector3.zero;

                if (!(EventSystem.current.IsPointerOverGameObject()))
                {
                    bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo);
                    if (hit)
                    {
                        if (hitInfo.transform.gameObject.tag == "Vertice")
                        {
                            TheWorld.unSelect(AxisFrame);
                            selected = hitInfo.transform;
                            axis = null;
                            AxisFrame.gameObject.SetActive(true);
                            AxisFrame.transform.position = selected.transform.position;
                            TheWorld.SelectVertice(selected);
                        }
                        else if (hitInfo.transform.gameObject.tag == "AxisFrame")
                        {
                            axis = hitInfo.transform;
                            TheWorld.unSelect(AxisFrame);
                            TheWorld.MarkSelected(axis);
                            TheWorld.SelectVertice(selected);
                        }
                        else
                        {
                            axis = null;
                            //set oject to original color
                            //TheWorld.unSelectVertice(selected);
                            selected = null;
                            AxisFrame.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                       // TheWorld.unSelectVertice(selected);
                        axis = null;
                        selected = null;
                        AxisFrame.gameObject.SetActive(false);
                    }
                }
                else
                {
                    TheWorld.unSelectVertice(selected);
                    axis = null;
                    selected = null;
                    AxisFrame.gameObject.SetActive(false);
                }
            }
            if (Input.GetMouseButton(0) && axis != null && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
            {
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;

                if (selected != null)
                {
                    newPosition = selected.transform.localPosition;
                }

                string name = axis.name;

                switch (name)
                {
                    case "X":
                        newPosition.x -= delta.x / 300;
                        break;
                    case "Y":
                        newPosition.y -= delta.y / 300;
                        break;
                    case "Z":
                        //must be x because it is a cylinder and cam only has x and y
                        newPosition.x -= delta.x / 300;
                        break;
                }

                if (selected != null)
                {
                    selected.localPosition = new Vector3(newPosition.x * Mathf.Cos(0), newPosition.y, newPosition.x * Mathf.Sin(0));

                    //change specific layer of cylinder
                    Cylinder.setMani(true);
                    Cylinder.LayerManipulation(newPosition, int.Parse(selected.name));

                    AxisFrame.position = selected.position;
                }
            }
        }
       TheWorld.unSelectVertice(selected);
    }

    void MouseClickEvents_Planar()
    {
        if (Input.GetKey(KeyCode.LeftControl)) {
            //Drag Event 
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();

                mouseDownPos = Input.mousePosition;
                delta = Vector3.zero;

                if (!(EventSystem.current.IsPointerOverGameObject()))
                {
                    bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo);
                    if (hit)
                    {
                        if (hitInfo.transform.gameObject.tag == "Vertice")
                        {
                            TheWorld.unSelect(AxisFrame);
                            selected = hitInfo.transform;
                            axis = null;
                            AxisFrame.gameObject.SetActive(true);
                            AxisFrame.transform.position = selected.transform.position;
                            TheWorld.SelectVertice(selected);
                        }
                        else if (hitInfo.transform.gameObject.tag == "AxisFrame")
                        {
                            axis = hitInfo.transform;
                            TheWorld.unSelect(AxisFrame);
                            TheWorld.MarkSelected(axis);
                        }
                        else
                        {
                            axis = null;
                            //set oject to original color
                            TheWorld.unSelectVertice(selected);
                            selected = null;
                            AxisFrame.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        axis = null;
                        TheWorld.unSelectVertice(selected);
                        selected = null;
                        AxisFrame.gameObject.SetActive(false);
                    }
                }
                else
                {
                    axis = null;
                    TheWorld.unSelectVertice(selected);
                    selected = null;
                    AxisFrame.gameObject.SetActive(false);
                }
            }
            if (Input.GetMouseButton(0) && axis != null && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
            {
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;

                if (selected != null) {
                    newPosition = selected.transform.localPosition;
                }

                string name = axis.name;

                switch (name)
                {
                    case "X":
                        newPosition.x -= delta.x / 100;
                        break;
                    case "Y":
                        newPosition.y -= delta.y / 100;
                        break;
                    case "Z":
                        newPosition.z -= delta.x / 100;
                        break;
                }

                if (selected != null)
                {
                    selected.localPosition = newPosition;
                    AxisFrame.position = selected.position;
                }
            }


        }
        TheWorld.unSelectVertice(selected);
    }
}