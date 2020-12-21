using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheWorld : MonoBehaviour
{
    ObjectBehavior obj = null;
    private Vector3 positionD;

    public void SelectedObject(ref GameObject shape, Vector3 position) {
        Release();
        if (shape.tag == "Family")
        {
            obj = shape.GetComponent<ObjectBehavior>();
            SelectedColor();
        }
        else {
            obj = null;
        }
    }

    public bool isSelected() {
            return obj.transform.gameObject != null;
    }

    public void Release() {
        if (obj != null) {
            obj.Unmarked();
            obj = null;
        }
    }

    public Vector3 GetSelectedPostion() {
        if (obj != null)
            return obj.GetPosition();
        else
            return Vector3.zero;
    }

    public Vector3 GetSelectedSize() {
        return obj.GetSize();
    }

    public float GetRotationX() {
        return obj.GetRotateX();
    }

    public float GetRotationY()
    {
        return obj.GetRotateY();
    }

    public float GetRotationZ()
    {
        return obj.GetRotateZ();
    }


    private void SelectedColor() {
        obj.SetColor();
    }

    public void SetSelectedPostion(float x, float y, float z) {
        if (obj != null) {
            obj.SetPosition(x, y, z);
        }
    }

    public void ResizeSelected(float x, float y, float z) {
        if (obj != null) {
            obj.SetScale(x, y, z);
        }
    }

    public void RotateSelected(float v, char dir) {
        if (obj != null) {
            obj.rotate(v, dir);
        }
    }

    

    public void Create(float type) {   
        if (obj == null)
        {
            Debug.Log("Here");
            GameObject shape = null;
            if (type == 1)
            {
                shape = Instantiate(Resources.Load("Cube")) as GameObject;
                shape.transform.position = positionD;
                Debug.Log(shape.name);
                
            }
            else if (type == 2)
            {
                shape = Instantiate(Resources.Load("Sphere")) as GameObject;
                shape.transform.position = positionD;
                Debug.Log(shape.name);
            }
            else if (type == 3)
            {
                shape = Instantiate(Resources.Load("Cylinder")) as GameObject;
                shape.transform.position = positionD;
                Debug.Log(shape.name);
            }

            shape.transform.SetParent(this.transform);
            shape.transform.tag = "Family";
        }
        else {
            CreateChild(type);
        }     
    }

    public string SelectedName() {
        if (obj != null)
        {
            return obj.GetName();
        }
        else {
            return "none";
        }
    }

    public void CreateChild(float type) {
        GameObject shape = null;
        if (type == 1)
        {
            shape = Instantiate(Resources.Load("Cube")) as GameObject;
                    
            Debug.Log(shape.name);
        }
        else if (type == 2)
        {
            shape = Instantiate(Resources.Load("Sphere")) as GameObject;
            Debug.Log(shape.name);
        }
        else if (type == 3)
        {
            shape = Instantiate(Resources.Load("Cylinder")) as GameObject;
            Debug.Log(shape.name);
        }
        MakeChild(shape);
        Vector3 temp = obj.transform.position;
        shape.transform.position = positionD;
        shape.transform.tag = "Family";
    }


    public void MakeChild(GameObject shape) {
        if (obj.HasChild())
        {
            Color childColor;
            Transform child = obj.gameObject.transform.GetChild(0);
            childColor = child.GetComponent<Renderer>().material.color;           
            shape.GetComponent<Renderer>().material.color = childColor;
            
        }
        else {
            shape.GetComponent<Renderer>().material.color = Color.white;
        }
        shape.transform.SetParent(obj.transform);
        Debug.Log("Parent of object is: " + shape.transform.parent);
    }


    // Start is called before the first frame update
    void Start()
    {
        positionD = new Vector3 (5.558167f, 1.906311f, 1.580078f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   
}
