using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnTransform;
    //스폰 장소가 될 오브젝트
    [SerializeField] GameObject spawnPoint;
    //스폰 될 장소가 들어갈 배열
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float spawnNum;

    PlayerObject player;
    Camera mainCamera;
    private void Start()
    {

        player = GameManager.instance.player;
        mainCamera = GameManager.instance.mainCamera;

        //스폰 포인터 배열 초기화
        spawnPoints = new GameObject[10];

        //시작 할 때 스폰 시작
        for (int i = 0; i < 10; i++)
        {
            SetSpawnPositon(i);
        }
        EnemySpawn();

        //코루틴 시작
        StartCoroutine(EnemySpawnTime(spawnNum));
    }

    //몬스터가 스폰될 시간을 재는 함수
    IEnumerator EnemySpawnTime(float spawnNum)
    {
        while (true)
        {
            //10초에 한번 씩;
            yield return new WaitForSeconds(10.0f);

            //스폰 되기 전 스폰 포인트 위치를 바꾸어 준다.
            for (int i = 0; i < spawnNum; i++)
            {
                spawnPoints[i].transform.position = new Vector2(GetSpawnPosition().x, GetSpawnPosition().y);
            }

            //랜덤한 적을 스폰시킨다.
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

    //랜덤한 스폰 포인트 위치 생성 함수
    Vector2 GetSpawnPosition()
    {
        //기준점이 될 플레이어의 위치
        Vector2 playerPosition = player.transform.position;
        //맵 전체의 크기 = 타일 하나의 크기 * 3
        int borderSize = 18 * 3;

        //랜덤한 위치 생성
        float randomX = Random.Range(-borderSize * 0.5f, borderSize * 0.5f);
        float randomY = Random.Range(-borderSize * 0.5f, borderSize * 0.5f);

        //카메라의 가로 시야 내에 생성이 되었다면
        if (Mathf.Abs(randomX) < mainCamera.orthographicSize * mainCamera.aspect)
        {
            //함수 다시 시작
            return GetSpawnPosition();
        }
        //카메라의 세로 시야 내에 생성 되었다면
        else if (Mathf.Abs(randomY)< mainCamera.orthographicSize)
        {
            //함수 다시 시작
            return GetSpawnPosition();
        }

        //전체 맵 1/2 범위로 한 스폰위치 생성
        float positionX = playerPosition.x + randomX;
        float positionY = playerPosition.y + randomY;

        Vector2 spawnPosition = new Vector2(positionX, positionY);

        return spawnPosition;
    }

    //스폰 포인트를 생성해 줄 함수
    void SetSpawnPositon(int index)
    {
        Vector2 spawnPosition = GetSpawnPosition();
        
        //생성
        GameObject instance = Instantiate(spawnPoint, spawnPosition, Quaternion.identity, spawnTransform);
        //생성된 instacne 배열에 저장
        spawnPoints[index] = instance;
    }

}
