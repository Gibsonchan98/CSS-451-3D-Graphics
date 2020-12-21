using UnityEngine;
using System.Collections;

public class CameraManipulation : MonoBehaviour
{
    public Camera MainCamera = null;
    public CameraMovement CamControl = null;


    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            //scroll zoom
            if (Input.mouseScrollDelta.y != 0)
            { //2D vector where x is ignored
                CamControl.cameraZoom(Input.mouseScrollDelta.y);
            }

            // tumble
            if (Input.GetMouseButtonDown(0))
            {
                mouseDownPos = Input.mousePosition;
                delta = Vector3.zero;
            }
            if (Input.GetMouseButton(0))
            {
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;
                CamControl.cameraTumble(delta);
                //CamControl.cameraTumble(delta.y, transform.right);
            }
        }

        //right Alt
        else if (Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDownPos = Input.mousePosition;
                delta = Vector3.zero;
            }
            if (Input.GetMouseButton(0))
            {
                delta = mouseDownPos - Input.mousePosition;
                mouseDownPos = Input.mousePosition;
                Vector3 nDelta = new Vector3(delta.x / 10, delta.y / 10, 0);
                CamControl.camTrack(nDelta);
            }
        }
    }

}