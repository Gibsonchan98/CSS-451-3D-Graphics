using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KelvinAttack1: MonoBehaviour
{
    void SwordMove()
    {
        Vector3 currRot = Leaf.transform.eulerAngles;

        if (currRot.z < 360 && currRot.z > 20)
        {
            Leaf.transform.localRotation *= Quaternion.AngleAxis(45 * Time.fixedDeltaTime, Vector3.forward);
        }
        Vector3 handRot = Hand.transform.eulerAngles;
        if (handRot.z > 390 || handRot.z < 275)
        {
            dir *= -1;
        }
        Hand.transform.localRotation *= Quaternion.AngleAxis(45 * Time.fixedDeltaTime, dir);
        //check if hit player
        Debug.Log(HitPlayer());
    }

    public bool HitPlayer()
    {
        //if it hits the player then return true
        Vector3 swordPos = new Vector3(leafPos.GetColumn(3).x, leafPos.GetColumn(3).y, leafPos.GetColumn(3).z);
        Vector3 dist = Player.transform.position - swordPos;
        if (dist.magnitude < 3 && dist.magnitude > 1.5f)
        {
            return true;
        }
        return false;
    }

    //Add animation later
    void initialStance()
    {
        Hand.transform.localRotation = iniH;
        Leaf.transform.localRotation = iniL;
    }
}
