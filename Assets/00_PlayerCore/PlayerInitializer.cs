using UnityEngine;
using MMJ.PlayerCore;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private PlayerInputAction input;
    [SerializeField] private PlayerInteractionResolver resolver;
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSkillHandler skillHandler;

    private void Start()
    {
        // 입력 → 판별
        input.OnLeftClick += resolver.ResolveLeftClick;

        // 판별 결과 → 이동/공격 실행
        resolver.OnMoveCommand += controller.MoveTo;
        resolver.OnAttackCommand += target =>
        {
            skillHandler.UseSkill(SkillSlotType.LeftClick, target);
        };
    }
}
