using UnityEngine;

namespace MMJ.PlayerCore
{
    public class PlayerSkillHandler : MonoBehaviour
    {
        public void UseSkill(SkillSlotType slotType, GameObject target)
        {
            if (target == null) return;

            Debug.Log($"[SkillHandler] {slotType} 스킬 사용 → 대상: {target.name}");

            // 회전 처리
            Vector3 dir = target.transform.position - transform.position;
            dir.z = 0;
            if (dir.sqrMagnitude > 0.01f)
                transform.up = dir.normalized;

            // TODO: 애니메이션, 데미지, 이펙트, 사운드 등 추가
        }
    }

    public enum SkillSlotType
    {
        LeftClick,
        RightClick,
        Skill1,
        Skill2,
        Skill3,
        Skill4
    }
}
