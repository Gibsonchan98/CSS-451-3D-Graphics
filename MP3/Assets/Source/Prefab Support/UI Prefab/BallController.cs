using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SliderWithEcho I, S, L;
    float t = 80;

    private GameObject mCurrentSphere;
    float interval = 4f;
    float lifeSpan = 10f;
    // Start is called before the first frame update
    void Start()
    {
        S.SetSliderListener(ValuChangedS);
        I.SetSliderListener(ValueChangedI);
        L.SetSliderListener(ValueChangedL);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setCurrentObject(GameObject obj) {
        mCurrentSphere = obj;
    }

    public float GetInterval() {
        return interval;
    }

    public float GetTime()
    {
        return t;
    }

    private void ValuChangedS(float newT)
    {
        t = 120 / newT * 10;
    }

    void ValueChangedI(float inter) {
        interval = inter;
    }

    void ValueChangedL(float life) {
        lifeSpan = life;
    }


    public float LifeSpanTime() {
        return lifeSpan;
    }
}
