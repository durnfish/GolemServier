using UnityEngine;

[CreateAssetMenu]
public class EnemyObject : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] Animator animator;

    //���� ����
    //���ʹ� n�и��� ������
    public float currentHp;
    public float maxHp;
    public float atkPoint;
    public float speed;
}