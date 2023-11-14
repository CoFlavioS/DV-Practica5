using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> prefabs;

    [Range(0.0f, 10.0f)] public float minTime = 0.0f;
    [Range(5.0f, 25.0f)] public float maxTime = 5.0f;

    private Coroutine corRef;

    void Start()
    {
        if (minTime > maxTime)
            Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        corRef = StartCoroutine(SpawnNow());
    }

    IEnumerator SpawnNow()
    {
        Start();
        int ocupiedIndex;
        GameObject newTarget;

        while (true)
        {
            ocupiedIndex = Random.Range(0, spawnPoints.Count);
            if (spawnPoints[ocupiedIndex].childCount <= 0)
            {
                newTarget = Instantiate(prefabs[Random.Range(0, prefabs.Count)], spawnPoints[ocupiedIndex]);
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(corRef);
    }
}
