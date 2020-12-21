using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisFrame : MonoBehaviour
{
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = transform.GetComponent<Renderer>().material.color;
    }

    public void SetSelected() {
        transform.GetComponent<Renderer>().material.color = new Color(.5f, .3f, .7f, 0.5f);
    }

    public void UnSelect() {
        transform.GetComponent<Renderer>().material.color = color;
    }
}
