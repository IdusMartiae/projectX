using System.Collections.Generic;
using Enums;
using UnityEngine;
using Wrappers;
using Zenject;

public class CharacterAbilitySlotsComponent : MonoBehaviour
{
    public readonly Dictionary<AbilitySlotType, AbilitySlotWrapper> AbilitySlots =
        new Dictionary<AbilitySlotType, AbilitySlotWrapper>();

    private InputSystem _inputSystem;

    [Inject]
    private void Construct(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.AbilitySlotPressed += HandleSlotPressed;
        _inputSystem.AbilitySlotReleased += HandleSlotReleased;
    }

    private void Start()
    {
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
        AbilitySlots[abilitySlot].UseAbility();
    }

    private void HandleSlotReleased(AbilitySlotType abilitySlot)
    {
        AbilitySlots[abilitySlot].AbilityRelease();
    }

    private void InitializeAbilitySlots()
    {
        AbilitySlots.Add(AbilitySlotType.PrimaryAbilitySlot, new AbilitySlotWrapper(new MockAbility1(transform, GetComponent<Animator>())));
        AbilitySlots.Add(AbilitySlotType.SecondaryAbilitySlot, new AbilitySlotWrapper(new MockAbility2()));
    }
    
    // Mock abilities for testing
    private class MockAbility1 : BaseAbility
    {
        
        public sealed override string Name { get; set; }
        public sealed override string IconPath { get; set; }
        public sealed override bool MovementBlocking { get; set; }
        public sealed override bool Aimed { get; set; }
        public sealed override float Duration { get; set; }
        public sealed override float Cooldown { get; set; }

        private Transform _actorTransform;
        private Animator _animator;

        internal MockAbility1(Transform actorTransform, Animator animator)
        {
            _actorTransform = actorTransform;
            Name = "MockAbility1";
            IconPath = "/1.png";
            MovementBlocking = false;
            Aimed = false;
            Duration = 0.1f;
            Cooldown = 0.5f;
            _animator = animator;
        }

        public override void Start()
        {
            var colliders = Physics.OverlapBox(
                _actorTransform.position + _actorTransform.forward * 2,
                new Vector3(1, 1, 1));
            
            _animator.SetFloat("Attacking", 2f);
        }

        public override void Finish()
        {
            _animator.SetFloat("Attacking", 0);
        }
    }

    private class MockAbility2 : BaseAbility
    {
        public sealed override string Name { get; set; }
        public sealed override string IconPath { get; set; }
        public sealed override bool MovementBlocking { get; set; }
        public sealed override bool Aimed { get; set; }
        public override float Duration { get; set; }
        public override float Cooldown { get; set; }

        internal MockAbility2()
        {
            Name = "MockAbility2";
            IconPath = "/2.png";
            MovementBlocking = true;
            Aimed = true;
        }

        public override void Start()
        {
        }

        public override void Finish()
        {
        }
    }
}