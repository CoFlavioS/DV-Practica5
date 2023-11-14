using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    public GameObject prefab;

    public int poolSize;


    void Start()
    {
        pool = new List<GameObject>();
        GameObject go;

        for (int i = 0; i < poolSize; i++)
        {
            go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            go.GetComponent<BulletHandler>().shooter = this.gameObject;
            go.SetActive(false);
            pool.Add(go);
        }
    }

    public GameObject GetNewObjectFromPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        return null;
    }
}
