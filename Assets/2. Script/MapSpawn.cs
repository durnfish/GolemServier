using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    /* [0][1][2] 배열의 모습
     * [3][4][5]
     * [6][7][8]
    */
    [SerializeField] GameObject[] groundArray;

    //타일 하나의 크기
    [SerializeField] int borderSize;

    //맵의 전체 좌표를 저장해줄 배열
    Vector2[] border;

    //카메라 시야의 가로 범위
    float cameraWidth;
    //카메라 시야 세로 범위
    float cameraHeight;

    private void Start()
    {
        //순서대로 왼쪽 위, 오른쪽 아래가 들어감
        border = new Vector2[]
        {
            new Vector2(-borderSize*1.5f , borderSize*1.5f),
            new Vector2( borderSize*1.5f , -borderSize*1.5f),
        };

        //카메라의 시야 범위 가져오기
        Camera mainCamera = GameManager.instance.mainCamera;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        cameraHeight = mainCamera.orthographicSize;
    }

    private void Update()
    {
        PositionUpdate();
    }

    void PositionUpdate()
    {
        //플레이어 포지션 미리 불러오기
        Vector2 playerPosition = GameManager.instance.player.transform.position;
        //Debug.Log("y축 위치: "+playerPosition.y);


        //오른쪽 시야에서 타일이 빈 공간을 만났을 때
        if (border[1].x < playerPosition.x + cameraWidth)
        {
            //맵 전체의 좌표 border를 한칸 오른쪽으로 이동
            border[0] += Vector2.right * borderSize;
            border[1] += Vector2.right * borderSize;

            //실제 왼쪽 타일들을 오른쪽으로 옮기는 함수
            MoveTile(1);
        }
        //왼쪽 시야에서 타일이 빈 공간을 만났을 때
        else if (border[0].x > playerPosition.x - cameraWidth)
        {
            //맵 전체의 좌표 border를 한칸 왼쪽으로 이동
            border[0] -= Vector2.right * borderSize;
            border[1] -= Vector2.right * borderSize;

            //실제 오른쪽 타일들을 왼쪽으로 옮기는 함수
            MoveTile(2);
        }

        //위쪽 시야에서 타일이 빈 공간을 만났을 때
        if (border[0].y < playerPosition.y + cameraHeight)
        {
            //맵 전체의 좌표 border를 한칸 위로 이동
            border[0] += Vector2.up * borderSize;
            border[1] += Vector2.up * borderSize;

            //실제 아래 타일들을 위로 옮기는 함수
            MoveTile(3);
        }
        //아래쪽 시야에서 타일이 빈 공간을 만났을 때
        else if (border[1].y > playerPosition.y - cameraHeight) 
        {
            //맵 전체의 좌표 border를 한칸 아래로 이동
            border[0] -= Vector2.up * borderSize;
            border[1] -= Vector2.up * borderSize;

            //실제 위의 타일들을 아래로 옮기는 함수
            MoveTile(4);
        }
    }

    //타일들을 실제로 움직이는 함수
    void MoveTile(int index)
    {
        //groundArray 가 바꿀 배열, _groundArray 는 저장된 배열
        GameObject[] _groundArray = new GameObject[9];
        System.Array.Copy(groundArray, _groundArray, 9);

        switch (index)
        {
            //왼쪽 타일 오른쪽 이동
            case 1:
                /*  [0][1][2]   이동    [1][2][0]
                 *  [3][4][5] ------->  [4][5][3]
                 *  [6][7][8]           [7][8][6]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 0)
                    {
                        //조건에 맞는 타일을 교환
                        groundArray[i + 2] = _groundArray[i];

                        //교환한 타일의 실제 위치 이동(오른쪽 이동)
                        _groundArray[i].transform.position += Vector3.right * borderSize * 3;
                    }
                    else groundArray[i - 1] = _groundArray[i];
                }
                break;

            //오른쪽 타일 왼쪽 이동
            case 2:
                /* [0][1][2]   이동    [2][0][1]
                *  [3][4][5] ------->  [5][3][4]
                *  [6][7][8]           [8][6][7]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 2)
                    {
                        //조건에 맞는 타일을 교환
                        groundArray[i - 2] = _groundArray[i];

                        //교환한 타일의 실제 위치 이동(왼쪽 이동)
                        _groundArray[i].transform.position -= Vector3.right * borderSize * 3;
                    }
                    else groundArray[i + 1] = _groundArray[i];
                }
                break;

            //아래 타일 위로 이동
            case 3:
                /* [0][1][2]   이동    [6][7][8]
                *  [3][4][5] ------->  [0][1][2]
                *  [6][7][8]           [3][4][5]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i > 5)
                    {
                        //조건에 맞는 타일을 교환
                        groundArray[i - 6] = _groundArray[i];

                        //교환한 타일의 실제 위치 이동(위로 이동)
                        _groundArray[i].transform.position += Vector3.up * borderSize * 3;
                    }
                    else groundArray[i + 3] = _groundArray[i];
                }
                break;
            //위의 타일 아래로 이동
            case 4:
                /* [0][1][2]   이동    [3][4][5]
                *  [3][4][5] ------->  [6][7][8]
                *  [6][7][8]           [0][1][2]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i < 3)
                    {
                        //조건에 맞는 타일을 교환
                        groundArray[i + 6] = _groundArray[i];

                        //교환한 타일의 실제 위치 이동(아래로 이동)
                        _groundArray[i].transform.position -= Vector3.up * borderSize * 3;
                    }
                    else groundArray[i - 3] = _groundArray[i];
                }
                break;
        }
    }
}
