using UnityEngine;

[CreateAssetMenu]
public class EnemyObject : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] Sprite sprite;
    [SerializeField] Animator animator;

    //몬스터 스탯
    //몬스터는 n분마다 강해짐
    public float atkPoint;
    public float speed;
}