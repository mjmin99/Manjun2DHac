using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MMJ.PlayerCore
{
    public class PlayerInputAction : MonoBehaviour
    {
        public event Action<Vector2> OnLeftClick;
        public event Action OnRightClick;
        public event Action<int> OnKeySkill;

        public Vector2 PointerPosition { get; private set; }

        private PlayerInput input;

        private void Awake()
        {
            input = new PlayerInput();

            // ✅ 마우스 위치 갱신
            input.Player.PointerPosition.performed += ctx =>
            {
                PointerPosition = ctx.ReadValue<Vector2>();
            };

            // ✅ 좌클릭 (이동 or 공격)
            input.Player.LeftSkill.performed += _ =>
            {
                OnLeftClick?.Invoke(PointerPosition);
            };

            // ✅ 우클릭
            input.Player.RightSkill.performed += _ => OnRightClick?.Invoke();

            // ✅ 키보드 스킬 입력
            input.Player.Skill1.performed += _ => OnKeySkill?.Invoke(1);
            input.Player.Skill2.performed += _ => OnKeySkill?.Invoke(2);
            input.Player.Skill3.performed += _ => OnKeySkill?.Invoke(3);
            input.Player.Skill4.performed += _ => OnKeySkill?.Invoke(4);
        }

        private void OnEnable() => input.Enable();
        private void OnDisable() => input.Disable();
    }
}
