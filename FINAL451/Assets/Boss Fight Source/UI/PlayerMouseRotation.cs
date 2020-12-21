using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinPlayerMouseRotation : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * turnSpeed * Vector2.up, Space.World);
    }
}
