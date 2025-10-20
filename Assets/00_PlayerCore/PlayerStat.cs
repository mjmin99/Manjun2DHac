using System;
using UnityEngine;

namespace MMJ.PlayerCore
{
    [Serializable]
    public class PlayerStat : MonoBehaviour
    {
        [Header("Base Stats")]
        [SerializeField] private float maxHP = 100f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float attackPower = 10f;

        private float currentHP;

        // 📡 스탯 변경 이벤트
        public event Action<float, float> OnHPChanged;        // current, max
        public event Action<float> OnMoveSpeedChanged;
        public event Action<float> OnAttackPowerChanged;
        public event Action OnDied;

        private void Awake()
        {
            currentHP = maxHP;
        }

        #region === Getter ===
        public float MaxHP => maxHP;
        public float CurrentHP => currentHP;
        public float MoveSpeed => moveSpeed;
        public float AttackPower => attackPower;
        #endregion

        #region === Setter & Modifier ===
        public void TakeDamage(float amount)
        {
            currentHP -= amount;
            if (currentHP < 0) currentHP = 0;

            OnHPChanged?.Invoke(currentHP, maxHP);

            if (currentHP <= 0)
                OnDied?.Invoke();
        }

        public void Heal(float amount)
        {
            currentHP = Mathf.Min(maxHP, currentHP + amount);
            OnHPChanged?.Invoke(currentHP, maxHP);
        }

        public void SetMoveSpeed(float value)
        {
            moveSpeed = value;
            OnMoveSpeedChanged?.Invoke(moveSpeed);
        }

        public void AddAttackPower(float value)
        {
            attackPower += value;
            OnAttackPowerChanged?.Invoke(attackPower);
        }

        public void SetAttackPower(float value)
        {
            attackPower = value;
            OnAttackPowerChanged?.Invoke(attackPower);
        }
        #endregion
    }
}
