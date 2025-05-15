using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // 포인터는 보이면서 화면 바깥으로 나가지 않음
        Cursor.visible = true; // 포인터 보이기
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
