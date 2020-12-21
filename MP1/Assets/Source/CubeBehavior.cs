using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    Vector3 speed;
    float mDir = 1;
    public float range = 5f;
    Vector3 currPost;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1.5f, 0, Space.World);
        //speed of object 

        currPost = transform.position;
        currPost += mDir * speed * Time.deltaTime;
        transform.position = currPost;

        colorChange();
        if (Mathf.Abs(currPost.y) > range || currPost.y < 0)
        {
            mDir *= -1f;
        }

    }

    public void colorChange()
    {
        Renderer r = GetComponent<Renderer>();
        if (r != null)
        {
            Material m = r.material;
            Color c = m.color;
            if (mDir < 0)
            {
                c.g = 1f - c.g;
            }
            else
            {
                c.g = 1f;
                c.r = 1f;
                c.b = 1f;
            }
            m.color = c;
        }
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
