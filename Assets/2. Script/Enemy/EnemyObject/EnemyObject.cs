using UnityEngine;

[CreateAssetMenu]
public class EnemyObject : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] Sprite sprite;
    [SerializeField] Animator animator;

    //���� ����
    //���ʹ� n�и��� ������
    public float atkPoint;
    public float speed;
}