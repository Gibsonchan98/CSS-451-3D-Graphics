using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class MainController : MonoBehaviour
{
    public Camera MainCamera = null;
    public World TheWorld = null;
    public Dropdown dropdown = null;
    public UIHandler PlaneHandler = null;
    public CylinderController CylinderControl = null;
    public GameObject UICylinder = null;
    public GameObject UIPlanar = null;
    public Button resetB = null;

    CylinderMesh Cylinder = null;
    Plane Planar = null;
    Transform AxisFrame;

    private float camePos = -2.6f;
    private float camePos2 = -10f;
    private void Awake()
    {
        //set planar
        Planar = TheWorld.GetPlane();
        //initialize planar
        Planar.gameObject.SetActive(true);

        PlaneHandler.setObject(TheWorld.GetPlane());
        Vector3 pos = MainCamera.transform.localPosition;
        pos.z = camePos;
        pos.y = 2f;
        MainCamera.transform.localPosition = pos;
    }
    private void Start()
    {
        AxisFrame = TheWorld.AxisFrame.transform;
        //set cylinder 
        Cylinder = TheWorld.GetCylinder();
        CylinderControl.setObject(TheWorld.GetCylinder());
        Cylinder.gameObject.SetActive(false);

        dropdown.onValueChanged.AddListener(PolyShape);
        dropdown.value = 0;

        //set UI presentation
        UICylinder.SetActive(false);
        UIPlanar.SetActive(true);

        AxisFrame.gameObject.SetActive(false);
    }
    void PolyShape(int index){
        if (index == 0)  //plane
        {
            Vector3 pos = MainCamera.transform.localPosition;
            pos.z = camePos;
            pos.y = 2f;
            MainCamera.transform.localPosition = pos;
            Cylinder.gameObject.SetActive(false);
            UICylinder.SetActive(false);
            UIPlanar.SetActive(true);
            Planar.gameObject.SetActive(true);       
        }
        else  //CYLINDER
        {
            Vector3 pos = MainCamera.transform.localPosition;
            pos.z = camePos2;
            MainCamera.transform.localPosition = pos;
            Planar.gameObject.SetActive(false);
            UICylinder.SetActive(true);
            UIPlanar.SetActive(false);
            Cylinder.gameObject.SetActive(true);
            
        }
    
        //tried to fix the double check in the dropdown but it is being a pain
        dropdown.value = index;
    }

    void Update()
    {
        if (Cylinder.gameObject.activeSelf == true)
        {
            MouseClickEvents_Cylinder();
        }

        else if (Planar.gameObject.activeSelf == true)
        {
            MouseClickEvents_Planar();
        }

        //quit app
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //reset app
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MP5");
        }
    }

}
