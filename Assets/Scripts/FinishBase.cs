using UnityEngine;
using UnityEngine.UI;

public class FinishBase : MonoBehaviour
{
    [SerializeField] private Text text;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject enemyPool;

    [SerializeField] private GameObject bulletPool;

    [SerializeField] private GameObject gamePanel;

    private int missedEnemies;

    private int gameOverNumber = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (missedEnemies < gameOverNumber) 
        {
            collision.gameObject.SetActive(false);

            missedEnemies++;

            text.text = missedEnemies.ToString();
        }

        else 
        {
            enemyPool.SetActive(false);
            bulletPool.SetActive(false);
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}
