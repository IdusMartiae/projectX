using System.Collections.Generic;
using Enums;
using UnityEditor.Animations;
using UnityEngine;
using Wrappers;
using Zenject;

// TODO Add skill panel to represent chosen skills
public class CharacterAbilitySlotsComponent : MonoBehaviour
{
    [SerializeField] private BaseAbility primaryAbility;
    [SerializeField] private BaseAbility secondaryAbility;
    [SerializeField] private BaseAbility abilitySlot1;
    [SerializeField] private BaseAbility abilitySlot2;
    [SerializeField] private BaseAbility abilitySlot3;
    [SerializeField] private BaseAbility abilitySlot4;
    
    [SerializeField] private AnimatorController animatorController;
    
    public readonly Dictionary<AbilitySlotType, AbilitySlotWrapper> AbilitySlots =
        new Dictionary<AbilitySlotType, AbilitySlotWrapper>();
    private InputSystem _inputSystem;
    private Animator _animator;

    [SerializeField] private LayerMask layerMask;
    
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
        animatorController.layers[0].stateMachine.states[1].state.speed =
            1 / AbilitySlots[abilitySlot].SlotAbility.Duration;
        _animator.Play(animatorController.layers[0].stateMachine.states[1].state.nameHash);
        
        var collisions = Physics.OverlapBox(
            transform.position + transform.forward * 2, 
            Vector3.one * 2, 
            transform.rotation,
            layerMask);
        
        foreach (var collider in collisions)
        {
            Debug.Log(collider.name);
        }
    }

    private void HandleSlotReleased(AbilitySlotType abilitySlot)
    {
        AbilitySlots[abilitySlot].AbilityRelease();
    }

    private void InitializeAbilitySlots()
    {
        // TODO Initialize here serialized abilities until skill tree is implemented
    }
    
}