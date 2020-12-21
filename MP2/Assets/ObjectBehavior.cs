using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    Color color;

    private float previousValue;
    private float previousValueY;
    private float previousValueZ;

    void Start()
    {
        color = transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //OnMouseDown();
    }

    public void SetPosition(float x, float y, float z) {
        transform.localPosition = new Vector3(-1*x, y, z);
    }

    public void SetScale(float x, float y, float z)
    {
        transform.localScale = new Vector3(x, y, z);
    }

    public string GetName() {
        return transform.name;
    }

    public void Unmarked() {
        transform.GetComponent<Renderer>().material.color = color;
    }

    public bool HasChild() {
        return transform.childCount > 0;
    }

    public Color GetColor() {
        return color; 
    }
    public void SetColor() {
        transform.GetComponent<Renderer>().material.color = new Color(.5f, .3f, .7f, 0.5f);
    }
    public Vector3 GetPosition() {
        return transform.localPosition;
    }

    public Vector3 GetSize()
    {
        return transform.localScale;
    }

    public void rotate(float value, char direction)
    {      
        if (direction == 'y')
        {
            float angle = value - previousValueY;
            transform.Rotate(Vector3.up * angle);
            this.previousValueY = value;

        }
        else if (direction == 'x')
        {
            float angle = value - previousValue;
            transform.Rotate(Vector3.right * angle);
            this.previousValue = value;
        }
        else if (direction == 'z')
        {
            float angle = value - previousValueZ;
            transform.Rotate(Vector3.forward * angle);
            this.previousValueZ = value;
        }
    }

    public float GetRotateX() {
        return previousValue;
    }

    public float GetRotateY()
    {
        return previousValueY;
    }
    public float GetRotateZ()
    {
        return previousValueY;
    }


}
