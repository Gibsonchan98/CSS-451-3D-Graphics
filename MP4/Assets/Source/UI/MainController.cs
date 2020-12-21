 using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    // reference to all UI elements in the Canvas
    public Button resetB = null;

    public Camera MainCamera = null;
    public TheWorld TheWorld = null;
    public SceneNodeControl NodeControl = null;
   
    public LookAtControl LAControl = null;
    public CameraControl CamControl = null;
    

    Vector3 delta = Vector3.zero;
    Vector3 mouseDownPos = Vector3.zero;

    void Awake()
    {
        Debug.Assert(NodeControl != null);
        NodeControl.TheRoot = TheWorld.TheRoot;
       
    }

    // Use this for initialization
    void Start()
    {
        Debug.Assert(MainCamera != null);
        Debug.Assert(TheWorld != null);
        LAControl.LookAt = TheWorld.LookAt.transform;
        CamControl.LookAtPosition = TheWorld.LookAt.transform;
        Button btn = resetB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        TheWorld.setAxisLocation(NodeControl.getSelected(), NodeControl.getRot());

    }

    // Update is called once per frame
    void Update()
    {
        ProcessMouseEvents();
        TheWorld.setAxisLocation(NodeControl.getSelected(), NodeControl.getRot());
    }

    
    void ProcessMouseEvents() {
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
                Vector3 nDelta = new Vector3(delta.x/10, delta.y/10, 0);
                CamControl.camTrack(nDelta);
            }
        }

        if (Input.GetKeyDown(KeyCode.R) == true) {
            SceneManager.LoadScene("MP4");
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("MP4");
    }
}
