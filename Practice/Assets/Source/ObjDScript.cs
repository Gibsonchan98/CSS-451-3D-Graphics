using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjDScript : MonoBehaviour
{
    public Slider slider; 
    GameObject aObj;
    ObjAScript aScript;

    private float previousValue;
    // Start is called before the first frame update
    void Start()
    {
        aObj = GameObject.Find("ObjA");
        aScript = aObj.GetComponent<ObjAScript>();

        slider.onValueChanged.AddListener(rotateWSlider);
        this.previousValue = this.slider.value;
    }

    private void Update()
    {
        
    }

    void rotateWSlider(float value) {
        Vector3 temp = transform.localScale;
        temp.y = 3;
        transform.localScale = new Vector3(value,temp.y, temp.z);


        //translate in x
      /*  Vector3 temp = transform.position;
        temp.x = value;
        transform.position = temp;*/

        /*float delta = value - previousValue;
        transform.Rotate(Vector3.up * delta);
        this.previousValue = value;*/
    }

}
