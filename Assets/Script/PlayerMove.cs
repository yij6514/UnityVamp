using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float mSpeed = 5.0f;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        transform.position += dir * mSpeed * Time.deltaTime;

        // 카메라에서 보이는 마우스 위치로부터 이어지는 ray 생성성
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        // 만들어진 ray 가 지나갈 수 있는 평면을 생성
        // 평면은 Y축을 기준으로 하며, 플레이어의 위치를 기준으로 한다.
        Plane groundPlane = new Plane(Vector3.up, transform.position); // 지면: Y=플레이어 높이

        // ray와 평면의 교차점을 계산
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter); // 마우스가 가리키는 월드 좌표
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f; // 수평 방향만 고려

            if (direction.sqrMagnitude > 0.001f)
            {
                // 플레이어의 방향을 마우스가 가리키는 방향으로 회전
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                // Quaternion.Euler(0f, angle, 0f) : Y축을 기준으로 회전
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
        }
    }
}
