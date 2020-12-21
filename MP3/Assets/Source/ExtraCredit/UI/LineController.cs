using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public Toggle A, B, C;

    public Text ObjectName;

    private GameObject LineA; 
    private GameObject LineB;
    private GameObject LineC;

    // Start is called before the first frame update
    void Start()
    {
        A.onValueChanged.AddListener(SetLineA);
        B.onValueChanged.AddListener(SetLineB);
        C.onValueChanged.AddListener(SetLineC);

        A.isOn = false;
        B.isOn = false;
        C.isOn = true;
        SetLineC(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLines(GameObject LA, GameObject LB, GameObject LC) {
        LineA = LA;
        LineB = LB;
        LineC = LC;
    }

    void SetLineA(bool v) {
        LineA.SetActive(true);
        LineB.SetActive(false);
        LineC.SetActive(false);
        LineA.GetComponent<Renderer>().enabled = true;
        LineB.GetComponent<Renderer>().enabled = false;
        LineC.GetComponent<Renderer>().enabled = false;
    }

    void SetLineB(bool v)
    {
        LineA.SetActive(false);
        LineB.SetActive(true);
        LineC.SetActive(false);
        LineA.GetComponent<Renderer>().enabled = false;
        LineB.GetComponent<Renderer>().enabled = true;
        LineC.GetComponent<Renderer>().enabled = false;
    }

    void SetLineC(bool v)
    {
        LineA.SetActive(false);
        LineB.SetActive(false);
        LineC.SetActive(true);
        LineA.GetComponent<Renderer>().enabled = false;
        LineB.GetComponent<Renderer>().enabled = false;
        LineC.GetComponent<Renderer>().enabled = true;
    }

    public float WhichToggle() {
        if (B.isOn)
        {
            return 2;
        }
        else if (C.isOn) {
            return 3;            
        }
        return 1;
    }
}
