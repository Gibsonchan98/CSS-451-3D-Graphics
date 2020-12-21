using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour
{

    public Slider sliderObject;
    public Text theEcho;

    public delegate void SliderCallBackDelegate(float v);
    private SliderCallBackDelegate mCallBack = null;

    // Start is called before the first frame update
    void Start()
    {
        sliderObject.onValueChanged.AddListener(SliderValueChange);
    }
    public void SetSliderListener(SliderCallBackDelegate listener) {
        mCallBack = listener;
    }

    public float GetSliderValue() {
        return sliderObject.value;
    }

    public void SetSliderValue(float v) {
        sliderObject.value = v;
        SliderValueChange(v);
    }

    public void InitSlider(float min, float max, float v) {
        sliderObject.minValue = min;
        sliderObject.maxValue = max;
        SetSliderValue(v);
    }

    void SliderValueChange(float v) {
        theEcho.text = v.ToString("0.0000");
        if (mCallBack != null) {
            mCallBack(v);
        }
    }

}
