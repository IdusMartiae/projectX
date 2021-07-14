using System.Collections.Generic;
using Enums;
using UnityEngine;
using Wrappers;

public class CharacterAbilitiesComponent
{
    private readonly Dictionary<AbilitySlotType, AbilitySlotWrapper> _abilitySlots =
        new Dictionary<AbilitySlotType, AbilitySlotWrapper>(
        );
    private readonly InputSystem _inputSystem;
    
    // delete this after testing
    public BaseAbility CurrentAbility;

    public BaseAbility Update()
    {
        foreach (var abilitySlot in _abilitySlots)
        {
            abilitySlot.Value.UpdateCooldownTimer();
        }

        //return;
    }
    
    private CharacterAbilitiesComponent(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.AbilityStarted += HandleAbilityStart;
        _inputSystem.AbilityFinished += HandleAbilityFinish;
        
        InitializeAbilitySlots();
    }

    private void HandleAbilityStart(AbilitySlotType abilitySlot)
    {
        Debug.Log($"Pressed {abilitySlot} button");
    }
    
    private void HandleAbilityFinish(AbilitySlotType abilitySlot)
    {
        Debug.Log($"{abilitySlot} released");
        CurrentAbility = null;
    }

    private void InitializeAbilitySlots()
    {
        _abilitySlots.Add(AbilitySlotType.PrimaryAbilitySlot,new AbilitySlotWrapper(new MockAbility1()));
        _abilitySlots.Add(AbilitySlotType.SecondaryAbilitySlot,new AbilitySlotWrapper(new MockAbility2()));
    }
    
    // Mock abilities for testing
    internal class MockAbility1 : BaseAbility
    {
        public sealed override string Name { get; set; }
        public sealed override string IconPath { get; set; }
        public sealed override bool MovementBlocking { get; set; }
        public sealed override bool Aimed { get; set; }
        public sealed override float Duration { get; set; }
        public sealed override float Cooldown { get; set; }

        internal MockAbility1()
        {
            Name = "MockAbility1";
            IconPath = "/1.png";
            MovementBlocking = false;
            Aimed = true;
            Duration = 0.1f;
            Cooldown = 0.5f;
        }
        
        public override void Start()
        {
            Debug.Log($"Started {Name} ability, icon at '{IconPath}'");
            Debug.Log("This is a hold-to-charge ability");
        }

        public override void Finish()
        {
            Debug.Log($"Finished {Name} ability, icon at '{IconPath}'");
        }
    }

    internal class MockAbility2 : BaseAbility
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
            Debug.Log($"Started {Name} ability, icon at '{IconPath}'");
            Debug.Log("This is a one-time cast");
        }

        public override void Finish()
        {
            Debug.Log($"Finished {Name} ability, icon at '{IconPath}'");
        }
    }
}