using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class KelvinMainController : MonoBehaviour
{
    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;
    Vector3 newPosition = Vector3.zero;
    Transform axis = null;
    void mouseEvents()
    {
        //Player shoots with left control
        if (Input.GetMouseButtonDown(0))
            World.shoot();

        /*
        if (Input.GetKey(KeyCode.M))
        {
            World.setAxisLocation();
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
                        if (hitInfo.transform.gameObject.tag == "AxisFrame")
                        {
                            axis = hitInfo.transform;
                        }
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;
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

                World.Move(newPosition);
            }
        }

        World.Unset();*/
    }


}
