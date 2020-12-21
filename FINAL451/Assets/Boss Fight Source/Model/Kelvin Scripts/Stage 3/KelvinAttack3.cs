using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinAttack3 : MonoBehaviour
{
    public KelvinSceneNode Node;
    public GameObject Player;

    Matrix4x4 pos;
    float mSpeed = 10;
    float jumpSpeed = 2.5f;
    float gravity = .1f;
    Vector3 posV;
    bool hit;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        pos = Node.GetMatrix();
        posV = new Vector3(pos.GetColumn(3).x, pos.GetColumn(3).y, pos.GetColumn(3).z);
    }

    // Update is called once per frame
    void Update()
    {
        pos = Node.GetMatrix();
        posV = new Vector3(pos.GetColumn(3).x, pos.GetColumn(3).y, pos.GetColumn(3).z);
        Vector3 velocity = Player.transform.localPosition - posV;
        float D = velocity.magnitude;
        Vector3 temp = transform.localPosition;

        if (D > 15)
        {
            float angle = Vector3.Dot(transform.forward, velocity / D);
            transform.localRotation *= Quaternion.AngleAxis(angle * 50, Vector3.up);
            //create jump 
            if (isGrounded() == true)
            {
                temp.y += jumpSpeed * mSpeed;
            }
            else
            {
                temp.y -= gravity * Time.deltaTime;
            }
            velocity.Normalize();

            temp += (D / 120) * velocity;
            transform.localPosition = new Vector3(temp.x, temp.y, temp.z);
        }

        if (D < 8)
        {
            hit = true;
        }
        else
        {
            hit = true;
        }


    }

    public bool hitPlayer()
    {
        return hit;
    }
    private bool isGrounded()
    {
        float tempY = pos.GetColumn(3).y;
        if (tempY < 11)
        {
            return true;
        }
        Debug.Log(tempY);
        return false;
    }
}
