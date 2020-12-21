using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class KelvinWorld : MonoBehaviour
{
    public KelvinSceneNode TheRoot;
    public GameObject Player;
    GunScript playerGun;
    public KelvinAttack1 attack1;
    public KelvinAttack2 attack2;
    public KelvinAttack3 finalAttack;
    KelvinBulletBehavior bullet;

    //public AxisFrame AxisFrame;
    private void Start()
    {
        playerGun = Player.transform.GetComponent<GunScript>();
    }

    private void Update()
    {
        Matrix4x4 i = Matrix4x4.identity;
        TheRoot.CompositeXform(ref i);
        if (attack2.enabled == true)
        {
            bullet = attack2.GetBullet();
        }

    }

    public int bulletHit()
    {
        if (bullet.bulletHit() == true)
        {
            return 15;
        }
        return 0;
    }

    public int jumpHit()
    {
        if (finalAttack.hitPlayer() == true)
        {
            return -20;
        }
        return 0;
    }

    public int swordHit()
    {
        if (attack1.HitPlayer() == true)
        {
            return 10;
        }
        return 0;
    }

    //if player hits boss then boss health will decrease
    public int hitBoss()
    {
        if (playerGun.HitBoss() == true)
        {
            return 1;
        }
        return 0;

    }

    public void shoot()
    {
        playerGun.ShootLaser();
    }
}
