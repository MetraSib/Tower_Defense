using System.Collections;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    [SerializeField] private EnemiesObjectPool enemiesObject;

    private int numbersOfEnemies = 100;

    private int numberOfWaves = 3;

    void Start()
    {
        StartCoroutine(WaveInstantiate());
    }

    private IEnumerator WaveInstantiate()
    {
        while (true)
        {
            if (CurrentWaveStatic.currentWave > numberOfWaves) yield break;

            if(numbersOfEnemies > 0) 
            {
                enemiesObject.UnitInstantiate(transform.position, Quaternion.identity);
                numbersOfEnemies--;
            }

            else if (numbersOfEnemies == 0) 
            {
                CurrentWaveStatic.currentWave++;
                enemiesObject.StartUnit();
                numbersOfEnemies = 100;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
