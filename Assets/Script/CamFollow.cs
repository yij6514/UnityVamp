using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform player; // 따라갈 대상
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10); // 기본 카메라 위치 오프셋

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}