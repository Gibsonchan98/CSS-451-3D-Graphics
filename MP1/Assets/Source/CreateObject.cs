using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CreateObject : MonoBehaviour
{
    public Dropdown m_Dropdown;
    Vector3 shapePosition;
    private GameObject myPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown = transform.GetComponent<Dropdown>();

        Debug.Assert(m_Dropdown != null);


        CreateShape(m_Dropdown);

        //call function
        m_Dropdown.onValueChanged.AddListener(delegate
        {
            CreateShape(m_Dropdown);
        });
    }

    // Update is called once per frame
    void Update()
    { 

    }

    void CreateShape(Dropdown option) {
        int value = option.value;

        //if first option.value = cube
        if (value == 1) {
            myPrefab = Instantiate(Resources.Load("MyCube")) as GameObject;
            shapePosition = GameObject.Find("CreationTarget").transform.position;
            shapePosition.y = 0.6f;
            myPrefab.transform.position = shapePosition; 
        }

        //sphere
        if (value == 2)
        {
            myPrefab = Instantiate(Resources.Load("MySphere")) as GameObject;
            shapePosition = GameObject.Find("CreationTarget").transform.position;
            shapePosition.y = 0.6f;
            myPrefab.transform.position = shapePosition;
        }

        //cylinder
        if (value == 3)
        {
            myPrefab = Instantiate(Resources.Load("MyCylinder")) as GameObject;
            shapePosition = GameObject.Find("CreationTarget").transform.position;
            shapePosition.y = 2.1f;
            myPrefab.transform.position = shapePosition;
        }

        if (value == 4)
        {
            myPrefab = Instantiate(Resources.Load("MyDinky")) as GameObject;
            shapePosition = GameObject.Find("CreationTarget").transform.position;
            shapePosition.y = 0;
            myPrefab.transform.position = shapePosition;
        }

        if (value == 5)
        {
            myPrefab = Instantiate(Resources.Load("MyCar")) as GameObject;
            shapePosition = new Vector3(0,1.3f,0);
            myPrefab.transform.position = shapePosition;
        }

        //Go back to default
        option.value = 0; 
    }
}
