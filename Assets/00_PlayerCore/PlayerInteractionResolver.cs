using UnityEngine;
using System;

namespace MMJ.PlayerCore
{
    public class PlayerInteractionResolver : MonoBehaviour
    {
        [Header("Layer Masks")]
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private LayerMask attackableMask; // Monster + Destructible 포함

        public event Action<Vector3> OnMoveCommand;
        public event Action<GameObject> OnAttackCommand;

        private Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        public void ResolveLeftClick(Vector2 screenPos)
        {
            Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;

            // 1️⃣ 공격 가능한 대상 우선 탐색
            RaycastHit2D hitAttackable = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, attackableMask);
            if (hitAttackable.collider != null)
            {
                OnAttackCommand?.Invoke(hitAttackable.collider.gameObject);
                return;
            }

            // 2️⃣ 바닥 클릭 시 이동
            RaycastHit2D hitGround = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, groundMask);
            if (hitGround.collider != null)
            {
                OnMoveCommand?.Invoke(hitGround.point);
                return;
            }

            Debug.Log("[Resolver] 클릭된 대상 없음");
        }
    }
}
