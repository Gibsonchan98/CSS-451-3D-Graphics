using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinPlayerCam : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Player.localPosition;
        transform.localRotation = Quaternion.FromToRotation(transform.up, Player.transform.up) * transform.localRotation;
        transform.localRotation = Quaternion.FromToRotation(transform.right, Player.right) * transform.localRotation;
    }
}
