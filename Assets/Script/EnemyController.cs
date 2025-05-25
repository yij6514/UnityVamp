using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float mSpeed = 3.0f;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir.y = 0; // 수평 방향만 고려

            // 적 캐릭터의 이동 로직
            transform.position += dir.normalized * mSpeed * Time.deltaTime;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 충돌 시 적 캐릭터 삭제
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
