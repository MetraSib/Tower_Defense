using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName ="Weapon Data",order =51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float damage;

    [SerializeField] private float range;

    public float GetDamage
    {
        get
        {
            return damage;
        }
    }

    public float GetRange
    {
        get
        {
            return range;
        }
    }
}
