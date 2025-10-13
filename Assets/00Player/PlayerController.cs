using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 targetPos;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMouseClick();
    }

    private void FixedUpdate()
    {
        if (isMoving)
            MoveToTarget();
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;
            targetPos = mouseWorld;
            isMoving = true;
        }
    }

    void MoveToTarget()
    {
        Vector2 direction = (targetPos - rb.position);
        if (direction.magnitude < 0.05f)
        {
            isMoving = false;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
