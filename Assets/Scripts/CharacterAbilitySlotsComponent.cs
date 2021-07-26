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
    private Animator _animator;
    
    public Dictionary<AbilitySlotType, AbilitySlotWrapper> AbilitySlots;
    private InputSystem _inputSystem;
    private static readonly int PrimaryAbility = Animator.StringToHash("PrimaryAbility");

    [Inject]
    private void Construct(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.AbilitySlotPressed += HandleSlotPressed;
        _inputSystem.AbilitySlotReleased += HandleSlotReleased;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        InitializeAbilitySlots();
    }

    public void Update()
    {
        // This can be replaced with coroutines
        /*foreach (var abilitySlot in AbilitySlots)
        {
            abilitySlot.Value.UpdateCooldownTimer();
        }*/
        
    }
    
    private void HandleSlotPressed(AbilitySlotType abilitySlot)
    {   
        AbilitySlots[abilitySlot].UseAbility(_animator);
        _animator.SetTrigger(PrimaryAbility);
        // delete later
        /*AbilitySlots[abilitySlot].UseAbility();
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
        }*/
    }

    private void HandleSlotReleased(AbilitySlotType abilitySlot)
    {
        /*AbilitySlots[abilitySlot].AbilityRelease();*/
    }

    private void InitializeAbilitySlots()
    {
        AbilitySlots = new Dictionary<AbilitySlotType, AbilitySlotWrapper>
        {
            {AbilitySlotType.PrimaryAbilitySlot, new AbilitySlotWrapper(primaryAbility, this)},
            {AbilitySlotType.SecondaryAbilitySlot, new AbilitySlotWrapper(this)},
            {AbilitySlotType.AbilitySlot1, new AbilitySlotWrapper(this)},
            {AbilitySlotType.AbilitySlot2, new AbilitySlotWrapper(this)},
            {AbilitySlotType.AbilitySlot3, new AbilitySlotWrapper(this)},
            {AbilitySlotType.AbilitySlot4, new AbilitySlotWrapper(this)}
        };
    }
    private void ChangeSlotAbility(AbilitySlotType slot, BaseAbility newAbility)
    {
        AbilitySlots[slot].ChangeAbility(newAbility);
    }
}