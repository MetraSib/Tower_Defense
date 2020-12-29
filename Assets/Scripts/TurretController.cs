using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private List<Transform> enemiesTransform;

    [SerializeField] private WeaponData weaponData;

    private float bulletForce = 10f;

    private CircleCollider2D turretCollider;

    [SerializeField] private BulletObjectPool bulletObjectPool;

    private bool isEnemyInTrigger = false;

    private static string enemy = "Enemy";

    private void Start()
    {
        StartCoroutine(Shooting());
        enemiesTransform = new List<Transform>();
        turretCollider = GetComponent<CircleCollider2D>();
        turretCollider.radius = weaponData.GetRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemy)) 
        {
            enemiesTransform.Add(collision.transform);
            isEnemyInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemiesTransform.Remove(collision.transform);
       
        if (enemiesTransform.Count == 0)
        {
            isEnemyInTrigger = false;
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            if (isEnemyInTrigger)
            {
                var bullet = bulletObjectPool.UnitInstantiate(transform.position, Quaternion.identity);

                bullet.GetComponent<BulletActiveFalse>().bulletDamage = weaponData.GetDamage;

                bullet.GetComponent<Rigidbody2D>().AddForce((enemiesTransform[enemiesTransform.Count - 1].position - transform.position).normalized*bulletForce, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
