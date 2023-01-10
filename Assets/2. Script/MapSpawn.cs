using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    /* [0][1][2] �迭�� ���
     * [3][4][5]
     * [6][7][8]
    */
    [SerializeField] GameObject[] groundArray;

    //Ÿ�� �ϳ��� ũ��
    [SerializeField] int borderSize;

    //���� ��ü ��ǥ�� �������� �迭
    Vector2[] border;

    //ī�޶� �þ��� ���� ����
    float cameraWidth;
    //ī�޶� �þ� ���� ����
    float cameraHeight;

    private void Start()
    {
        //������� ���� ��, ������ �Ʒ��� ��
        border = new Vector2[]
        {
            new Vector2(-borderSize*1.5f , borderSize*1.5f),
            new Vector2( borderSize*1.5f , -borderSize*1.5f),
        };

        //ī�޶��� �þ� ���� ��������
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
        //�÷��̾� ������ �̸� �ҷ�����
        Vector2 playerPosition = GameManager.instance.player.transform.position;
        //Debug.Log("y�� ��ġ: "+playerPosition.y);


        //������ �þ߿��� Ÿ���� �� ������ ������ ��
        if (border[1].x < playerPosition.x + cameraWidth)
        {
            //�� ��ü�� ��ǥ border�� ��ĭ ���������� �̵�
            border[0] += Vector2.right * borderSize;
            border[1] += Vector2.right * borderSize;

            //���� ���� Ÿ�ϵ��� ���������� �ű�� �Լ�
            MoveTile(1);
        }
        //���� �þ߿��� Ÿ���� �� ������ ������ ��
        else if (border[0].x > playerPosition.x - cameraWidth)
        {
            //�� ��ü�� ��ǥ border�� ��ĭ �������� �̵�
            border[0] -= Vector2.right * borderSize;
            border[1] -= Vector2.right * borderSize;

            //���� ������ Ÿ�ϵ��� �������� �ű�� �Լ�
            MoveTile(2);
        }

        //���� �þ߿��� Ÿ���� �� ������ ������ ��
        if (border[0].y < playerPosition.y + cameraHeight)
        {
            //�� ��ü�� ��ǥ border�� ��ĭ ���� �̵�
            border[0] += Vector2.up * borderSize;
            border[1] += Vector2.up * borderSize;

            //���� �Ʒ� Ÿ�ϵ��� ���� �ű�� �Լ�
            MoveTile(3);
        }
        //�Ʒ��� �þ߿��� Ÿ���� �� ������ ������ ��
        else if (border[1].y > playerPosition.y - cameraHeight) 
        {
            //�� ��ü�� ��ǥ border�� ��ĭ �Ʒ��� �̵�
            border[0] -= Vector2.up * borderSize;
            border[1] -= Vector2.up * borderSize;

            //���� ���� Ÿ�ϵ��� �Ʒ��� �ű�� �Լ�
            MoveTile(4);
        }
    }

    //Ÿ�ϵ��� ������ �����̴� �Լ�
    void MoveTile(int index)
    {
        //groundArray �� �ٲ� �迭, _groundArray �� ����� �迭
        GameObject[] _groundArray = new GameObject[9];
        System.Array.Copy(groundArray, _groundArray, 9);

        switch (index)
        {
            //���� Ÿ�� ������ �̵�
            case 1:
                /*  [0][1][2]   �̵�    [1][2][0]
                 *  [3][4][5] ------->  [4][5][3]
                 *  [6][7][8]           [7][8][6]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 0)
                    {
                        //���ǿ� �´� Ÿ���� ��ȯ
                        groundArray[i + 2] = _groundArray[i];

                        //��ȯ�� Ÿ���� ���� ��ġ �̵�(������ �̵�)
                        _groundArray[i].transform.position += Vector3.right * borderSize * 3;
                    }
                    else groundArray[i - 1] = _groundArray[i];
                }
                break;

            //������ Ÿ�� ���� �̵�
            case 2:
                /* [0][1][2]   �̵�    [2][0][1]
                *  [3][4][5] ------->  [5][3][4]
                *  [6][7][8]           [8][6][7]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 2)
                    {
                        //���ǿ� �´� Ÿ���� ��ȯ
                        groundArray[i - 2] = _groundArray[i];

                        //��ȯ�� Ÿ���� ���� ��ġ �̵�(���� �̵�)
                        _groundArray[i].transform.position -= Vector3.right * borderSize * 3;
                    }
                    else groundArray[i + 1] = _groundArray[i];
                }
                break;

            //�Ʒ� Ÿ�� ���� �̵�
            case 3:
                /* [0][1][2]   �̵�    [6][7][8]
                *  [3][4][5] ------->  [0][1][2]
                *  [6][7][8]           [3][4][5]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i > 5)
                    {
                        //���ǿ� �´� Ÿ���� ��ȯ
                        groundArray[i - 6] = _groundArray[i];

                        //��ȯ�� Ÿ���� ���� ��ġ �̵�(���� �̵�)
                        _groundArray[i].transform.position += Vector3.up * borderSize * 3;
                    }
                    else groundArray[i + 3] = _groundArray[i];
                }
                break;
            //���� Ÿ�� �Ʒ��� �̵�
            case 4:
                /* [0][1][2]   �̵�    [3][4][5]
                *  [3][4][5] ------->  [6][7][8]
                *  [6][7][8]           [0][1][2]
                */
                for (int i = 0; i < 9; i++)
                {
                    if (i < 3)
                    {
                        //���ǿ� �´� Ÿ���� ��ȯ
                        groundArray[i + 6] = _groundArray[i];

                        //��ȯ�� Ÿ���� ���� ��ġ �̵�(�Ʒ��� �̵�)
                        _groundArray[i].transform.position -= Vector3.up * borderSize * 3;
                    }
                    else groundArray[i - 3] = _groundArray[i];
                }
                break;
        }
    }
}
