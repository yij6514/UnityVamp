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

        Vector3 mouse = Input.mousePosition;
        float d = cam.nearClipPlane;
        //mouse.z = d;
        Vector3 worldMousePos = cam.ScreenToWorldPoint(mouse);
        Debug.Log(mouse);
    }
}
