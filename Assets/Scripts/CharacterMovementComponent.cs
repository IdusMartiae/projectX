using ScriptableObjects;
using StateMachines;
using StateMachines.Decisions.AimDecisions;
using StateMachines.Decisions.MovementDecisions;
using StateMachines.States.CharacterAim;
using StateMachines.States.CharacterMovement;
using StateMachines.Transitions;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovementComponent : MonoBehaviour
{
    private CharacterController _controller;
    private InputSystem _inputSystem;
    private CharacterMovementSettings _movementSettings;
        
    private StateMachine _movementStateMachine;
    private StateMachine _aimingStateMachine;

    [Inject]
    private void Construct(InputSystem inputSystem, CharacterMovementSettings movementSettings)
    {
        _inputSystem = inputSystem;
        _movementSettings = movementSettings;
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        InitializeStateMachines();
    }

    public void Update()
    {
        _movementStateMachine.Update();
        _aimingStateMachine.Update();
    }

    private void InitializeStateMachines()
    {
        var staticState = new StaticState(gameObject.GetComponent<Animator>());
        var movingState = new MovingState(
            _controller,
            _movementSettings,
            _inputSystem,
            gameObject.GetComponent<Animator>());
        var movementBlockedState = new MovementBlockedState(gameObject.GetComponent<Animator>());

        staticState.AddTransition(new Transition(
            movingState,
            staticState,
            new MovementButtonDownDecision(_inputSystem))
        );
        movingState.AddTransition(new Transition(
            staticState,
            movingState,
            new MovementButtonUpDecision(_inputSystem))
        );

        var playerTransform = transform;
        var faceForwardState = new FaceForwardState(playerTransform, _movementSettings, _inputSystem);
        var lookAtMouse = new LookAtMouseState(playerTransform, _movementSettings, _inputSystem);

        _movementStateMachine = new StateMachine(staticState);
        _aimingStateMachine = new StateMachine(faceForwardState);

        var abilityComponent = GetComponent<CharacterAbilitySlotsComponent>();

        // ADD ADDITIONAL TRANSITIONS IF ABILITY COMPONENT IS PRESENT
        if (abilityComponent == null) return;

        var usedBlockingAbility = new BlockingAbilityUsedDecision(_inputSystem, abilityComponent);

        movementBlockedState.AddTransition(new Transition(
            movingState, 
            movementBlockedState, 
            new BlockingAbilityCancelledDecision(_inputSystem, abilityComponent))
        );
        movingState.AddTransition(new Transition(
            movementBlockedState, 
            movingState, 
            usedBlockingAbility)
        );
        staticState.AddTransition(new Transition(
            movementBlockedState, 
            staticState, 
            usedBlockingAbility)
        );
        faceForwardState.AddTransition(new Transition(
                lookAtMouse,
                faceForwardState,
                new AimedAbilityUsedDecision(_inputSystem, abilityComponent))
        );
        lookAtMouse.AddTransition(new Transition(
                faceForwardState,
                lookAtMouse,
                new AimedAbilityCancelledDecision(_inputSystem, abilityComponent))
        );
    }
}