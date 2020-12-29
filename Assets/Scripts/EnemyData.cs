using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Sprite mainSprite;

    [SerializeField] private Sprite rotateSprite;

    [SerializeField] private float health;

    [SerializeField] private GameObject finish;

    public Sprite GetMainSprite
    {
        get
        {
            return mainSprite;
        }
    }

    public Sprite GetRotateSprite
    {
        get
        {
            return rotateSprite;
        }
    }

    public GameObject GetFinish
    {
        get
        {
            return finish;
        }
    }

    public float GetHealth
    {
        get
        {
            return health;
        }
    }
}
