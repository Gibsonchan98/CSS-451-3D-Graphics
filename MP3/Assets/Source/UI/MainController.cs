using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Camera MainCamera;
    public TheWorld TheWorld;
    public XFormControl PlaneControl;
    public GameObject g;
    public GameObject Traveller;
    public BallController SControl;

    private float interval = 4f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Set Plane to be controlled by XForm
        g = TheWorld.ThisPlane();
        PlaneControl.SetSelectedObject(g);
    }

    // Update is called once per frame
    void Update()
    {
        MouseAction();
        TimeControl();
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

 

    public void MouseAction()
    {
       // GameObject objectS;
        Vector3 hitpoint;

        if (Input.GetMouseButton(0)) //Mouse Drag
        {
            
            RaycastHit hitInfo = new RaycastHit();
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("RightWall")))
                {
                    hitpoint = hitInfo.point;

                        TheWorld.MoveRightPointer(hitpoint);
                }
                else if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("LeftWall")))
                {
                    hitpoint = hitInfo.point;

                        TheWorld.MoveLeftPointer(hitpoint);             
                }
               
            }               
        }
       // else if (Input.GetMouseButtonUp(0)) { 
            
        //}

    }

    public void TimeControl() {
        timer += Time.deltaTime;
        interval = SControl.GetInterval();
        if (timer >= interval)
        {
            timer = 0f;
            Traveller = TheWorld.CreateObject(SControl.GetTime(), SControl.LifeSpanTime());
        }
    }
}
