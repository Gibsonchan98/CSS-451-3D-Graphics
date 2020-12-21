using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithEcho1 : MonoBehaviour
{
    public Slider TheSlider = null;
    public Text TheEcho = null;
    public Text TheLabel = null;

    public delegate void SliderCallbackDelegate(float v);      // defined a new data type
    private SliderCallbackDelegate mCallBack = null;           // private instance of the data type

    private bool active = false;    // Ben: I added this value, since I was getting a stack
                                    // overflow every time I set the value.

    // Use this for initialization
    void Start()
    {
        Debug.Assert(TheSlider != null);
        Debug.Assert(TheEcho != null);
        Debug.Assert(TheLabel != null);

        TheSlider.onValueChanged.AddListener(SliderValueChange);
    }

    public void SetSliderListener(SliderCallbackDelegate listener)
    {
        mCallBack = listener;
    }

    // GUI element changes the object
    void SliderValueChange(float v)
    {
        TheEcho.text = v.ToString("0.0000");
        // Debug.Log("SliderValueChange: " + v);
        if (mCallBack != null && !active)
        {
            active = true;
            mCallBack(v);
            active = false;
        }
    }

    public float GetSliderValue() { return TheSlider.value; }
    public void SetSliderLabel(string l) { TheLabel.text = l; }
    public void SetSliderValue(float v) { TheSlider.value = v; SliderValueChange(v); }
    public void InitSliderRange(float min, float max, float v)
    {
        TheSlider.minValue = min;
        TheSlider.maxValue = max;
        SetSliderValue(v);
    }
}
