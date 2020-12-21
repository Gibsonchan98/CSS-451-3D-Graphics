using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderwithEcho : MonoBehaviour
{
    public Slider theSlider;
    public Text theEcho;
    public Text TheLable;

    public delegate void SliderCallbackDelegate(float v);
    private SliderCallbackDelegate mCallBack; 
    // Start is called before the first frame update
    void Start()
    {
        theSlider.onValueChanged.AddListener(SliderValueChange);
    }

    public void SetSlideListeners(SliderCallbackDelegate listener) {
        mCallBack = listener;
    }

    void SliderValueChange(float v) {
        theEcho.text = v.ToString("0.0000");
        if (mCallBack != null) {
            mCallBack(v);
        }
    }

    public float GetSliderValue() {

        return theSlider.value;
    }

    public void SetSliderLabel(string l) {
        TheLable.text = l;
    }

    public void SetSliderValue(float v)
    {
        theSlider.value = v;
        SliderValueChange(v);

    }

    public void InitSliderRange(float min, float max, float v) {
        theSlider.minValue = min;
        theSlider.maxValue = max;
        SetSliderValue(v);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
