using System.Collections.Generic;
using Enums;
using UnityEngine;

public class CharacterAbilitiesComponent
{
    private readonly Dictionary<AbilitySlotType, BaseAbility> _abilitySlots = new Dictionary<AbilitySlotType, BaseAbility>();
    private readonly InputSystem _inputSystem;
    
    // delete this after testing
    public BaseAbility CurrentAbility;

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
        _abilitySlots[abilitySlot].Start();
        CurrentAbility = _abilitySlots[abilitySlot];
    }
    
    private void HandleAbilityFinish(AbilitySlotType abilitySlot)
    {
        Debug.Log($"{abilitySlot} released");
        _abilitySlots[abilitySlot].Finish();
        CurrentAbility = null;
    }

    private void InitializeAbilitySlots()
    {
        _abilitySlots.Add(AbilitySlotType.PrimaryAbilitySlot,new MockAbility1());
        _abilitySlots.Add(AbilitySlotType.SecondaryAbilitySlot,new MockAbility2());
    }
    
    // Mock abilities for testing
    internal class MockAbility1 : BaseAbility
    {
        public override string Name { get; set; }
        public override string IconPath { get; set; }
        public override bool MovementBlocking { get; set; }
        public override bool Aimed { get; set; }

        internal MockAbility1()
        {
            Name = "MockAbility1";
            IconPath = "/1.png";
            MovementBlocking = false;
            Aimed = true;
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