using UnityEngine;

public class Player : MonoBehaviour
{
    /*private CharacterMovementComponent _movementComponent;
    private CharacterAbilitiesComponent _abilitiesComponent;*/

    /*[Inject]
    private void Construct(
        CharacterMovementComponent movementComponent,
        CharacterAbilitiesComponent abilitiesComponent)
    {
        _movementComponent = movementComponent;
        _abilitiesComponent = abilitiesComponent;
    }*/

    private void Update()
    {
        /*if (_abilitiesComponent.CurrentAbility != null)
        {
            _movementComponent.Update(
                _abilitiesComponent.CurrentAbility.MovementBlocking,
                _abilitiesComponent.CurrentAbility.Aimed);
        }
        else
        {
            _movementComponent.Update(false, false);
        }*/
    }
}