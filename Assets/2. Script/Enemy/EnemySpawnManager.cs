using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnTransform;
    //���� ��Ұ� �� ������Ʈ
    [SerializeField] GameObject spawnPoint;
    //���� �� ��Ұ� �� �迭
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float spawnNum;

    PlayerObject player;
    Camera mainCamera;
    private void Start()
    {

        player = GameManager.instance.player;
        mainCamera = GameManager.instance.mainCamera;

        //���� ������ �迭 �ʱ�ȭ
        spawnPoints = new GameObject[10];

        //���� �� �� ���� ����
        for (int i = 0; i < 10; i++)
        {
            SetSpawnPositon(i);
        }
        EnemySpawn();

        //�ڷ�ƾ ����
        StartCoroutine(EnemySpawnTime(spawnNum));
    }

    //���Ͱ� ������ �ð��� ��� �Լ�
    IEnumerator EnemySpawnTime(float spawnNum)
    {
        while (true)
        {
            //10�ʿ� �ѹ� ��;
            yield return new WaitForSeconds(10.0f);

            //���� �Ǳ� �� ���� ����Ʈ ��ġ�� �ٲپ� �ش�.
            for (int i = 0; i < spawnNum; i++)
            {
                spawnPoints[i].transform.position = new Vector2(GetSpawnPosition().x, GetSpawnPosition().y);
            }

            //������ ���� ������Ų��.
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject creatEnemy = GameManager.instance.enemyPoolManager.GetEnemy(Random.Range(0, 2));
            creatEnemy.transform.position = spawnPoints[i].transform.position;
        }
    }

    //������ ���� ����Ʈ ��ġ ���� �Լ�
    Vector2 GetSpawnPosition()
    {
        //�������� �� �÷��̾��� ��ġ
        Vector2 playerPosition = player.transform.position;
        //�� ��ü�� ũ�� = Ÿ�� �ϳ��� ũ�� * 3
        int borderSize = 18 * 3;

        //������ ��ġ ����
        float randomX = Random.Range(-borderSize * 0.5f, borderSize * 0.5f);
        float randomY = Random.Range(-borderSize * 0.5f, borderSize * 0.5f);

        //ī�޶��� ���� �þ� ���� ������ �Ǿ��ٸ�
        if (Mathf.Abs(randomX) < mainCamera.orthographicSize * mainCamera.aspect)
        {
            //�Լ� �ٽ� ����
            return GetSpawnPosition();
        }
        //ī�޶��� ���� �þ� ���� ���� �Ǿ��ٸ�
        else if (Mathf.Abs(randomY)< mainCamera.orthographicSize)
        {
            //�Լ� �ٽ� ����
            return GetSpawnPosition();
        }

        //��ü �� 1/2 ������ �� ������ġ ����
        float positionX = playerPosition.x + randomX;
        float positionY = playerPosition.y + randomY;

        Vector2 spawnPosition = new Vector2(positionX, positionY);

        return spawnPosition;
    }

    //���� ����Ʈ�� ������ �� �Լ�
    void SetSpawnPositon(int index)
    {
        Vector2 spawnPosition = GetSpawnPosition();
        
        //����
        GameObject instance = Instantiate(spawnPoint, spawnPosition, Quaternion.identity, spawnTransform);
        //������ instacne �迭�� ����
        spawnPoints[index] = instance;
    }

}
