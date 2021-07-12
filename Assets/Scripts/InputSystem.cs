using System.Collections.Generic;
using Enums;
using ScriptableObjects;
using UnityEngine;
using Wrappers;
using Zenject;

public class InputSystem : MonoBehaviour
{
    private KeyBindings _keyBindings;
    private Quaternion _worldRotation;
    private Vector3 _movementDirection = Vector3.zero;

    public Vector3 MovementDirection => _worldRotation * _movementDirection.normalized; 
    
    [Inject]
    private void Initialize(KeyBindings keyBindings)
    {
        _keyBindings = keyBindings;
    }

    private void Start()
    {
        _worldRotation = GetWorldRotation();
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            CheckForMovementDown();
        }

        if (Input.anyKey)
        {
            
        }

        CheckForMovementUp();
    }
    
    private void CheckForCombat(List<KeyBindingWrapper<PlayerCombatEnum>> list)
    {
    }
    
    private void CheckForMovementDown()
    {
        foreach (var move in _keyBindings.Movement)
        {
            if (Input.GetKeyDown(move.MainKey) || Input.GetKeyDown(move.AlternativeKey))
            {
                switch (move.KeyAction)
                {
                    case PlayerMovementEnum.Up: 
                        _movementDirection += Vector3.forward;
                        break;
                    case PlayerMovementEnum.Down: 
                        _movementDirection += Vector3.back;
                        break;
                    case PlayerMovementEnum.Left: 
                        _movementDirection += Vector3.left;
                        break;
                    case PlayerMovementEnum.Right: 
                        _movementDirection += Vector3.right;
                        break;
                    
                }
            }
        }
    }
    
    private void CheckForMovementUp()
    {
        foreach (var move in _keyBindings.Movement)
        {
            if (Input.GetKeyUp(move.MainKey) || Input.GetKeyUp(move.AlternativeKey))
            {
                switch (move.KeyAction)
                {
                    case PlayerMovementEnum.Up: 
                        _movementDirection -= Vector3.forward;
                        break;
                    case PlayerMovementEnum.Down: 
                        _movementDirection -= Vector3.back;
                        break;
                    case PlayerMovementEnum.Left: 
                        _movementDirection -= Vector3.left;
                        break;
                    case PlayerMovementEnum.Right: 
                        _movementDirection -= Vector3.right;
                        break;
                    
                }
            }
        }
    }
    
    private Quaternion GetWorldRotation()
    {
        var cameraForward = Camera.main.transform.forward.normalized;
        var playerForward = transform.forward;
        
        cameraForward.y = 0;
        
        return Quaternion.FromToRotation(playerForward, cameraForward);
    }
}
