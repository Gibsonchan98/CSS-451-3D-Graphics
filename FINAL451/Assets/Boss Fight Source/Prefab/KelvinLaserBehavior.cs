using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinLaserBehavior : MonoBehaviour
{
    //Code learned from the following question on Unity: 
    //https://answers.unity.com/questions/161063/laser-bullet.html 
    float Speed = 8;
    bool hit;
    Vector3 BossPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(-Vector3.up * Time.deltaTime * Speed);
        transform.localPosition += -transform.up * Time.deltaTime * Speed;
        //Destroy laser
        Destroy(gameObject, 5);
        //check if hit boss
        Vector3 D = BossPos - transform.localPosition;
        if (D.magnitude < 5)
        {
            hit = true;
            Debug.Log("HIT BOSS");
            Destroy(gameObject);
        }
        else
        {
            hit = false;
        }
    }

    public void setBossPosition(Vector3 posB)
    {
        BossPos = posB;
    }

    public bool hitBoss()
    {
        return hit;
    }
}
