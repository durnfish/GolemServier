using UnityEngine;

public class cameraPlayerTracking : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing;
    Vector3 position;

    private void LateUpdate()
    {
        position = new Vector3(player.position.x, player.position.y, -10);
        // ī�޶� ����
        transform.position = Vector3.Lerp(transform.position, position, smoothing);
    }
}
