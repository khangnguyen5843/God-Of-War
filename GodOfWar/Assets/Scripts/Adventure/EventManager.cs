using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private PlayerAdventureMovement playerAdventureMovement;

    public void SetJump()
    {
        playerAdventureMovement.SetJumpHeight();
     
    }
    public void SwitchStateToNormal()
    {
        playerAdventureMovement.SwitchCharacterState(PlayerAdventureMovement.CharacterState.Normal);
    }
    public void SwitchStateToFalling()
    {
        playerAdventureMovement.SwitchCharacterState(PlayerAdventureMovement.CharacterState.Falling);
    }
    public void SwitchStateToJump()
    {
        playerAdventureMovement.SwitchCharacterState(PlayerAdventureMovement.CharacterState.Jump);
    }
    public void JumpEnd()
    {
        playerAdventureMovement.StartJumpEnd();
    }
}
