using System.Collections.Generic;
using Enums;
using UnityEditor.Animations;
using UnityEngine;
using Wrappers;
using Zenject;

public class CharacterAbilitySlotsComponent : MonoBehaviour
{
    [SerializeField] private BaseAbility testBasicAttack;
    [SerializeField] private AnimatorController animatorController;
    
    public readonly Dictionary<AbilitySlotType, AbilitySlotWrapper> AbilitySlots =
        new Dictionary<AbilitySlotType, AbilitySlotWrapper>();
    private InputSystem _inputSystem;
    private Animator _animator;
        
    [Inject]
    private void Construct(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.AbilitySlotPressed += HandleSlotPressed;
        _inputSystem.AbilitySlotReleased += HandleSlotReleased;
    }

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        InitializeAbilitySlots();
    }

    public void Update()
    {
        foreach (var abilitySlot in AbilitySlots)
        {
            abilitySlot.Value.UpdateCooldownTimer();
        }
        
    }
    
    private void HandleSlotPressed(AbilitySlotType abilitySlot)
    {
        // delete later
        AbilitySlots[abilitySlot].UseAbility();
        animatorController.layers[1].stateMachine.states[1].state.speed =
            1 / AbilitySlots[abilitySlot].SlotAbility.Duration;
        _animator.Play(animatorController.layers[1].stateMachine.states[1].state.nameHash);
        var hitZone = Instantiate(AbilitySlots[abilitySlot].SlotAbility.HitZone);
        hitZone.transform.position = transform.position + transform.up * 1 + transform.forward * 2f;
        hitZone.transform.rotation = Quaternion.Euler(-90f, transform.eulerAngles.y + 180f, 0);
    }

    private void HandleSlotReleased(AbilitySlotType abilitySlot)
    {
        AbilitySlots[abilitySlot].AbilityRelease();
    }

    private void InitializeAbilitySlots()
    {
        AbilitySlots.Add(AbilitySlotType.PrimaryAbilitySlot, new AbilitySlotWrapper(testBasicAttack));
        animatorController.SetStateEffectiveMotion(animatorController.layers[1].stateMachine.states[1].state, testBasicAttack.Animation);
    }
    
}