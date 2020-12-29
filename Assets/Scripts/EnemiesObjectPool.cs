using System.Collections.Generic;
using UnityEngine;

public class EnemiesObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject [] startPrefabs;

    private GameObject enemy;

    [SerializeField] private int amount = 30;

    private Transform enemyParent;

    private bool populateOnStart = true;
    private bool growOverAmount = true;

    [SerializeField] private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        StartUnit();
    }

    public GameObject UnitInstantiate(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.position = position;
                pool[i].transform.rotation = rotation;
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        if (growOverAmount)
        {
            var instance = Instantiate(enemy, position, rotation,enemyParent);
            pool.Add(instance);
            return instance;
        }

        return null;
    }

    public void StartUnit()
    {
        if (pool.Count != 0) pool.Clear();

        enemy = startPrefabs[CurrentWaveStatic.currentWave - 1];

        enemyParent = transform;

        if (populateOnStart && enemy != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(enemy, enemyParent);
                instance.SetActive(false);
                pool.Add(instance);
            }
        }
    }
}
