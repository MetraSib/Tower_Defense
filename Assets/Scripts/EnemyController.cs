using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private SpriteRenderer spriteRenderer;

    private NavMeshAgent agent;

    private float health;

    private EnemiesScore enemiesScore;

    void Awake()
    {
        enemiesScore = FindObjectOfType<EnemiesScore>();

        health = enemyData.GetHealth;

        agent = GetComponent<NavMeshAgent>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyData.GetMainSprite;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (transform.position.x >= 0)
        {
            spriteRenderer.sprite = enemyData.GetRotateSprite;
        }

        agent.SetDestination(enemyData.GetFinish.transform.position);
    }

    private void OnDisable()
    {
        spriteRenderer.sprite = enemyData.GetMainSprite;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            enemiesScore.PlusEnemy();
        }
    }
}
