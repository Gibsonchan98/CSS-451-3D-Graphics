using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class MainControl : MonoBehaviour
{
    public Camera MainCamera = null;
    public TheWorld TheWorld;
    public Dropdown dropdown;
    public SliderBehavior Xslider;
    public SliderBehavior Yslider;
    public SliderBehavior Zslider;
    public Text Label;

    public Toggle SToggle;
    public Toggle RToggle;
    public Toggle TToggle;

    private bool state;
    // Update is called once per frame

    void Start()
    {
        //dropdown = transform.GetComponent<Dropdown>();

        Xslider.SetSliderListener(NewXValue);
        Yslider.SetSliderListener(NewYValue);
        Zslider.SetSliderListener(NewZValue);

        TToggle.isOn = true;
        Xslider.InitSlider(-10, 10, 0);
        Yslider.InitSlider(-10, 10, 0);
        Zslider.InitSlider(-10, 10, 0);

    }
    void Update()
    {
        
        MouseAction();
        dropdownSelect();
        dropdown.value = 0;
               
    }

    void MouseAction()
    {
       
        GameObject selectedObj;

        if (Input.GetMouseButtonDown(0))
        {
            //Code from class example2.Week2 from CSS451
            RaycastHit hitInfo = new RaycastHit();

            bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, 1);

            if (hit)
            {
                selectedObj = hitInfo.transform.gameObject;
                TheWorld.SelectedObject(ref selectedObj , hitInfo.point);
                if (selectedObj.tag != "Family") {
                    InitEmptyToggles();
                }
             
            }
            
            UpdateName();           
        }

        if (TheWorld.isSelected())
        {
            if (SToggle.isOn)
            {
                Xslider.InitSlider(1, 5, TheWorld.GetSelectedSize().x);
                Yslider.InitSlider(1, 5, TheWorld.GetSelectedSize().y);
                Zslider.InitSlider(1, 5, TheWorld.GetSelectedSize().z);
            }
            else if (TToggle.isOn)
            {
                Xslider.InitSlider(-10, 10, TheWorld.GetSelectedPostion().x * -1);
                Yslider.InitSlider(-10, 10, TheWorld.GetSelectedPostion().y);
                Zslider.InitSlider(-10, 10, TheWorld.GetSelectedPostion().z);
            }
            else if (RToggle.isOn)
            {
                Xslider.InitSlider(-180, 180, TheWorld.GetRotationX());
                Yslider.InitSlider(-180, 180, TheWorld.GetRotationY());
                Zslider.InitSlider(-180, 180, TheWorld.GetRotationZ());
            }
        }


    }

    void NewXValue(float x) {
        if (TToggle.isOn) {
            TheWorld.SetSelectedPostion(x, Yslider.GetSliderValue(), Zslider.GetSliderValue());
        }
        if (SToggle.isOn)
        {
            TheWorld.ResizeSelected(x, Yslider.GetSliderValue(), Zslider.GetSliderValue());
        }
        if (RToggle.isOn)
        {
            TheWorld.RotateSelected(x, 'x');
        }

    }

    void NewYValue(float y)
    {
        if (TToggle.isOn) {
            TheWorld.SetSelectedPostion(Xslider.GetSliderValue(), y, Zslider.GetSliderValue());
        }
        if (SToggle.isOn) {
            TheWorld.ResizeSelected(Xslider.GetSliderValue(), y, Zslider.GetSliderValue());
        }
        if (RToggle.isOn)
        {
            TheWorld.RotateSelected(y, 'y');
        }
    }


    void NewZValue(float z)
    {
        if (TToggle.isOn) {
            TheWorld.SetSelectedPostion(Xslider.GetSliderValue(), Yslider.GetSliderValue(), z);
        }
        if (SToggle.isOn)
        {
            TheWorld.ResizeSelected(Xslider.GetSliderValue(), Yslider.GetSliderValue(),z);
        }
        if (RToggle.isOn) {
            TheWorld.RotateSelected(z, 'z');
        }

    }

    public void InitEmptyToggles() {
            if (SToggle.isOn)
            {
                Xslider.InitSlider(1, 5, 1);
                Yslider.InitSlider(1, 5, 1);
                Zslider.InitSlider(1, 5, 1);
            }
            else if (TToggle.isOn)
            {
                Xslider.InitSlider(-10, 10, 0);
                Yslider.InitSlider(-10, 10, 0);
                Zslider.InitSlider(-10, 10, 0);
            }
            else if (RToggle.isOn)
            {
                Xslider.InitSlider(-180, 180, 0);
                Yslider.InitSlider(-180, 180, 0);
                Zslider.InitSlider(-180, 180, 0);
            }
    }

    public void UpdateName() {
        Label.text = "Selected: " + TheWorld.SelectedName();
    }

    public void dropdownSelect() {
        TheWorld.Create(dropdown.value);
    }

}
