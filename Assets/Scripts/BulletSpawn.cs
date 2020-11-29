using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int BulletPool = 1;
    [SerializeField] float BulletSpeed = 16.0F;
    public float FireRate = 0.5F;
    private float NextBullet = 1.0F;
    private Transform ThisTransform;

    List<GameObject> Bullets = new List<GameObject>();

    private void Awake()
    {
        //called first
        int i;
        GameObject obj;

        ThisTransform = transform;

        for (i = 0; i < BulletPool; i++)
        {

            obj = (GameObject)Instantiate(Bullet);
            obj.transform.rotation = Quaternion.identity;
            Bullets.Add(obj);
            Bullets[i].SetActive(false);
        }
    }

    public void Shoot()
    {
        if (this.enabled == true && Time.time > NextBullet)
        {
            NextBullet = Time.time + FireRate;
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (!Bullets[i].activeInHierarchy)
                {
                    Bullets[i].SetActive(true);
                    Bullets[i].transform.position = ThisTransform.position;
                    Bullets[i].transform.rotation = ThisTransform.rotation;
                    Bullets[i].GetComponent<Rigidbody>().velocity = ThisTransform.up * BulletSpeed;
                    break;
                }
            }
        }
    }
}
