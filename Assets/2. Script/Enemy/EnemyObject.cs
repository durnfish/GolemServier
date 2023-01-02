using UnityEngine;

[CreateAssetMenu]
public class EnemyObject : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] Animator animator;

    //몬스터 스탯
    //몬스터는 n분마다 강해짐
    public float currentHp;
    public float maxHp;
    public float atkPoint;
    public float speed;
}