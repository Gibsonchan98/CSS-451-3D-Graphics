using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    Vector3 speed;
    float mDir = 1;
    public float range;
    Vector3 currPost;
    float startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        currPost = transform.position;
        startingPoint = currPost.x;
        if (startingPoint > 2)
        {
            mDir *= -1;
            range = startingPoint - 5;
        }
        else
        {
            range = startingPoint + 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = new Vector3(1, 0, 0);
        transform.position += mDir * speed * Time.deltaTime;

        colorChange();
        if (startingPoint > 2)
        {
            if (transform.position.x < range || transform.position.x > startingPoint)
            {
                mDir *= -1;
            }
        }
        else if (startingPoint < 2)
        {
            if (transform.position.x > range || transform.position.x < startingPoint)
            {
                mDir *= -1;
            }
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
                c.r = 1f - c.r;
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
