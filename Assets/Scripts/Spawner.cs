using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjects;
    [SerializeField] private int PooledObjects = 1;

    public float SpawnRate = 0.5F;

    private float NextSpawn = 1.0F;
    private int MinX;
    private int MaxX;
    private int MinY;
    private int MaxY;

    List<GameObject> ObjectList = new List<GameObject>();

    private void Awake()
    {
        //called first
        int i;
        int j;
        GameObject obj;

        MinX = (int)-this.transform.localScale.x;
        MaxX = (int)this.transform.localScale.x + 1;
        MinY = (int)-this.transform.localScale.y;
        MaxY = (int)this.transform.localScale.y + 1;

        for (i = 0; i < PooledObjects; i++)
        {

            j = Random.Range(0, GameObjects.Length);

            obj = (GameObject)Instantiate(GameObjects[j]);
            obj.transform.rotation = Quaternion.identity;
            ObjectList.Add(obj);
            ObjectList[i].SetActive(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            Spawn();
        }
    }

    void Spawn()
    {
        int i = Random.Range(0, ObjectList.Count);
        {
            if (!ObjectList[i].activeInHierarchy)
            {
                ObjectList[i].transform.position = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), transform.position.z);
                ObjectList[i].SetActive(true);
            }

            else
            {
                Spawn();
            }
        }
    }
}
