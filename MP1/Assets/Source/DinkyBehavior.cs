using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkyBehavior : MonoBehaviour
{
    Vector3 speed;
    float mDir = 1;
    public float range = 8f;
    Vector3 currPost;
    Vector3 speed2;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(1.5f, 0, 0, Space.World);
        //speed of object 
        speed = new Vector3(0, 0, 1);
        speed2 = new Vector3(0, 1, 0);

        currPost = transform.position;
        currPost += mDir * speed * Time.deltaTime;
        currPost += mDir * speed2 * Time.deltaTime;
        transform.position = currPost;
        if (Mathf.Abs(currPost.y) > range || currPost.y < 0)
        {
            mDir *= -1f;
        }

        Destroy(gameObject, 10);
    }

}
