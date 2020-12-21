using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public KelvinSceneNode Node;
    public Transform Gun;
    KelvinLaserBehavior laserB;
    GameObject laser;
    protected Matrix4x4 m;
    Vector3 posB;
    private void Start()
    {
        m = Node.GetMatrix();
        posB = new Vector3(m.GetColumn(3).x, m.GetColumn(3).y, m.GetColumn(3).z);

    }

    public GameObject getLaser() {
        return laser;
    }
    public void ShootLaser()
    {
        //create laser
        laser = Instantiate(Resources.Load("Laser Bullet")) as GameObject;
        laserB = laser.transform.GetComponent<KelvinLaserBehavior>();
        laserB.setBossPosition(posB);
        //set up laser location and rotation
        Vector3 temp = Gun.position;
        temp.y += .12f;
        laser.transform.position = temp;
        laser.transform.localRotation = Quaternion.FromToRotation(laser.transform.up, Gun.up) * laser.transform.localRotation;
        laser.transform.localRotation = Quaternion.FromToRotation(laser.transform.right, Gun.right) * laser.transform.localRotation;

        //ClientSend.PlayerShoot(laser.transform.localRotation, laser.transform.localPosition, 8f);
    }

    public bool HitBoss()
    {
        return laserB.hitBoss();
    }
}
