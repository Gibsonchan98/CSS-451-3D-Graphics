using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraFeatures : MonoBehaviour
{
    public Text description;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //move camera
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        if (Camera.current != null) {
            Camera.current.transform.Translate(new Vector3(inputX, 0.0f, inputZ));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            description.text = " ";
           printFamily();
        }
    }

    void printFamily() {
        foreach (GameObject go in Object.FindObjectsOfType(typeof(GameObject))){
            if (go.transform.parent == null) {
                printRecursive(go.transform);
            }
        }
    }

    void printRecursive(Transform trans) {
        int children = trans.childCount;
        if (trans.tag == "Family") {
            Debug.Log(trans.name + " has " + children);
            description.text += trans.name + " has " + children + "leaf(ves)\n";
        }
        

        for (int child = 0; child < children; child++) {
            printRecursive(trans.GetChild(child));
        }
    }
}
