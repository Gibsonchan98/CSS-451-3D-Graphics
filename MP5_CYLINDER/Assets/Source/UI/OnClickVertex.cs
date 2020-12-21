using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickVertex: MonoBehaviour
{
    Color[] colors = new Color[] { Color.white, Color.red, Color.green, Color.blue };
    private int currentColor, length;
    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0; //White
        length = colors.Length;
        GetComponent<Renderer>().material.color = colors[currentColor];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                currentColor = (currentColor + 1) % length;
                GetComponent<Renderer>().material.color = colors[currentColor];
                
            }
        }
    }
}
