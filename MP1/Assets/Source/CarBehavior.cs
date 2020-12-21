using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    float time = 0;
    float radius;

    // Start is called before the first frame update
    void Start()
    {
        radius = 4;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float x = Mathf.Cos(time) * radius, y = .5f, z = Mathf.Sin(time) * radius;
        transform.position = new Vector3(x, y, z);

            transform.Rotate(0, -1.2f, 0, Space.World);

        //Destroy After 20
        Destroy(gameObject, 12);

    }

}
