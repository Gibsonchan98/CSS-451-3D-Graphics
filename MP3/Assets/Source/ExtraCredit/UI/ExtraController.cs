using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtraController : MonoBehaviour
{
    public Camera ExtraCamera;
    public TheWorld2 TheWorld;
    public TheWorld2Helper Helper;
    public LineController LControl;
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
        LControl.SetLines(Helper.SetLineAObject(), Helper.SetLineBObject(), Helper.SetLineCObject());

        //set initial line
        GameObject a, b, c;
        a = Helper.SetLineSegment(2);
        b = Helper.SetP1(2);
        c = Helper.SetP2(2);
        TheWorld.SetLineSegment(b, c, a);
    }

    // Update is called once per frame
    void Update()
    {
        MouseAction();
        TimeControl();
        SetLine();
    }



    public void MouseAction()
    {
        // GameObject objectS;
        Vector3 hitpoint;

        if (Input.GetMouseButton(0)) //Mouse Drag
        {

            RaycastHit hitInfo = new RaycastHit();
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ExtraCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("RightWall")))
                {
                    hitpoint = hitInfo.point;

                    TheWorld.MoveRightPointer(hitpoint);
                }
                else if (Physics.Raycast(ExtraCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("LeftWall")))
                {
                    hitpoint = hitInfo.point;

                    TheWorld.MoveLeftPointer(hitpoint);
                }
                else if (Physics.Raycast(ExtraCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("BackWall")))
                {
                    hitpoint = hitInfo.point;
                    Debug.Log(hitpoint);

                    TheWorld.MoveBackPointer(hitpoint);
                }
                else if (Physics.Raycast(ExtraCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("Floor")))
                {
                    hitpoint = hitInfo.point;

                    TheWorld.MoveFloorPointer(hitpoint);
                }

            }
        }
        // else if (Input.GetMouseButtonUp(0)) { 

        //}

    }

    public void TimeControl()
    {
        timer += Time.deltaTime;
        interval = SControl.GetInterval();
        if (timer >= interval)
        {
            timer = 0f;
            Traveller = TheWorld.CreateObject(SControl.GetTime(), SControl.LifeSpanTime());
        }
    }

    public void SetLine() {
        float value = LControl.WhichToggle();
        GameObject a, b, c;
        a = Helper.SetLineSegment(value);
        b = Helper.SetP1(value);
        c = Helper.SetP2(value);
        TheWorld.SetLineSegment(b, c, a);   
    }
}
