using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveDelay : MonoBehaviour
{
    [SerializeField] private Text counter;
    [SerializeField] private Text parentCounter;

    private EnemyWaveController enemyWaveController;

    private int time=10;

    void Start()
    {
        enemyWaveController = GetComponent<EnemyWaveController>();
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay() 
    {
        while (true) 
        {
            if (time > 0) 
            {
                time--;
                counter.text = time.ToString();
            }

            else 
            {
                enemyWaveController.enabled = true;
                parentCounter.gameObject.SetActive(false);
                yield break;
            }

            yield return new WaitForSeconds(1);
        }
    }
  
}
