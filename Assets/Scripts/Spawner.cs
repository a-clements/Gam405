using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjects;
    [SerializeField] private int PooledObjects = 1;

    public float SpawnRate = 5.0F;

    private float NextSpawn = 1.0F;
    public static int MinX;
    public static int MaxX;
    public static int MinY;
    public static int MaxY;

    List<GameObject> ObjectList = new List<GameObject>();

    private void Awake()
    {
        //called first
        int i;
        int j;
        GameObject obj;

        MinX = (int)-this.transform.localScale.x / 2;
        MaxX = (int)this.transform.localScale.x / 2;
        MinY = (int)-this.transform.localScale.y / 2;
        MaxY = (int)this.transform.localScale.y / 2;

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
                int j = Random.Range(0, 4);

                switch (j)
                {
                    case 0:
                        ActiveObject(i, Random.Range(MinX, MaxX), MaxY);
                        break;

                    case 1:
                        ActiveObject(i, Random.Range(MinX, MaxX), MinY);
                        break;

                    case 2:
                        ActiveObject(i, MaxX, Random.Range(MinY, MaxY));
                        break;

                    case 3:
                        ActiveObject(i, MinX, Random.Range(MinY, MaxY));
                        break;
                }
            }
        }
    }

    void ActiveObject(int i, int X, int Y)
    {
        ObjectList[i].transform.position = new Vector3(X, Y, this.transform.position.z);
        ObjectList[i].SetActive(true);
    }
}
