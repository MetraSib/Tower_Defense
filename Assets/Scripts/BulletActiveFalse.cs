using UnityEngine;

public class BulletActiveFalse : MonoBehaviour
{
    [HideInInspector] public float bulletDamage;

    private EnemyController enemyController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        enemyController = collision.gameObject.GetComponent<EnemyController>();

        enemyController.TakeDamage(bulletDamage);
    }
}
