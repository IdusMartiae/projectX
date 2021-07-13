using ScriptableObjects;
using UnityEngine;
using Zenject;

public class CharacterMovementComponentInstaller : MonoInstaller
{
    [SerializeField] private CharacterMovementSettings movementSettings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(movementSettings).AsSingle();
    }
}