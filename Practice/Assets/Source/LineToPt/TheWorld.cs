using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheWorld : MonoBehaviour
{
    public Transform P1, P2;
    //public GameObject Projected;
    //public GameObject PA;

    private float lineWidth = 0.2f;
    //private float kMaxSize = 5f; 

    public float timer = 4;
    public float t = 4;
    private float counter = 0;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        P1.localPosition = Vector3.up;
        P2.localPosition = -Vector3.up;
 
    }


    public void setNewTimer(float inter)
    {
        timer = inter;
        t = inter;
        Debug.Log("Slider change: " + t);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = P2.localPosition - P1.localPosition;
        float len = v.magnitude;

        transform.localPosition = P1.localPosition + 0.5f * v;
        transform.localScale = new Vector3(lineWidth, len * 0.5f, lineWidth);
        transform.localRotation = Quaternion.FromToRotation(Vector3.up, v);
        Debug.Log(t);
        CreatePrefab();
        
       
        /*float distant = 0;
        Vector3 V = P2.transform.localPosition - P1.transform.localPosition; //(P0 - P1)
        float vMagnitude = V.magnitude;
        V /= vMagnitude; //normalize vector, get direction

        Vector3 VA = PA.transform.localPosition - P1.transform.localPosition;
        float d = Vector3.Dot(VA, V);

        if (d < 0)
        {
            distant = VA.magnitude;
        }
        else if (d > vMagnitude)
        {
            distant = (PA.transform.localPosition - P2.transform.localPosition).magnitude;
        }
        else {
            distant = Mathf.Sqrt(VA.sqrMagnitude - d * d);
        }

        float s = kMaxSize - (distant * kScaleFactor);
        Projected.transform.localScale = new Vector3(s, s, s);
        Projected.transform.localPosition = P1.transform.localPosition + d * V;

        Debug.DrawLine(P1.transform.localPosition, P2.transform.localPosition, Color.black);
        Debug.DrawLine(PA.transform.localPosition, Projected.transform.localPosition, Color.red); */
        
    }


 

    void CreatePrefab() {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Debug.Log("here is timer value:" + timer);
            GameObject cube = Instantiate(Resources.Load("ObjC")) as GameObject;
            timer = t;
        }

    }

}
