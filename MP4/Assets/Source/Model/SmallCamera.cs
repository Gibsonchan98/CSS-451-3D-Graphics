using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCamera : MonoBehaviour
{
    public SceneNode head;
    float Size = 5f;
    public GameObject Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 n = transform.forward;
        Normal.transform.localScale = new Vector3(.1f, Size, .1f);
        Normal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, n);
        Normal.transform.localPosition = transform.localPosition + (Size * Normal.transform.up);
    }
}
