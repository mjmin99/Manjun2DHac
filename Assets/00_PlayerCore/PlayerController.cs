using UnityEngine;

namespace MMJ.PlayerCore
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D rb;
        private Vector3 targetPos;
        private bool isMoving;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            targetPos = transform.position;
        }

        public void MoveTo(Vector3 pos)
        {
            targetPos = pos;
            isMoving = true;
        }

        private void FixedUpdate()
        {
            if (!isMoving) return;

            Vector2 dir = targetPos - transform.position;
            if (dir.magnitude < 0.05f)
            {
                rb.linearVelocity = Vector2.zero;
                isMoving = false;
                return;
            }

            rb.linearVelocity = dir.normalized * moveSpeed;
            transform.up = dir.normalized; // 바라보는 방향 회전
        }
    }
}
