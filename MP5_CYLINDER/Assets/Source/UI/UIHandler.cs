using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  This is a basic UI handler for the plane. This is mostly to
 *  hook up the slider to some kind of plane changer.
 */
public class UIHandler : MonoBehaviour
{
    public SliderWithEcho1 m, n;
    public Plane mainObj;
    public XformControl sliders = null;

    // Start is called before the first frame update
    public void setObject(Plane obj)
    {
        mainObj = obj;
    }
    void Start()
    {
        SliderInitialization();
        m.SetSliderListener(SliderMChange);
        n.SetSliderListener(SliderNChange);
        sliders.SetSelectedObject(mainObj);
    }



    void SliderInitialization() {
        m.InitSliderRange(1, 40, 1);
        n.InitSliderRange(1, 40, 1);
    }

    void SliderMChange(float input) {
        int tempVal = Mathf.RoundToInt(input);
        m.SetSliderValue(tempVal);
        mainObj.ChangeResolution(Mathf.RoundToInt(n.GetSliderValue()), tempVal);
    }

    void SliderNChange(float input) {
        int tempVal = Mathf.RoundToInt(input);
        n.SetSliderValue(tempVal);
        mainObj.ChangeResolution(tempVal, Mathf.RoundToInt(m.GetSliderValue()));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            mainObj.show();
        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            mainObj.hide();
        }
    }
}
