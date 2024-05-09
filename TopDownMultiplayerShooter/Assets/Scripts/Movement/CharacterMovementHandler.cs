using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    private Vector3 viewInput;

    private NetworkCharacterControllerCustom NetworkCharacterControllerCustom;

    private void Awake()
    {
        NetworkCharacterControllerCustom = GetComponent<NetworkCharacterControllerCustom>();
    }

    public override void FixedUpdateNetwork()
    {
        //Vector3 moveDirection = Vector3.zero;

        if (GetInput(out NetworkInputData networkInputData))
        {
            NetworkCharacterControllerCustom.RotateInDirection(networkInputData.rotationInput);

            //Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;

            Vector3 moveDirection = new Vector3(networkInputData.movementInput.x,0, networkInputData.movementInput.y);


            moveDirection.Normalize();
            
            NetworkCharacterControllerCustom.Move(moveDirection);
            
        }
    }

    public void SetViewInputVector(Vector3 viewInput)
    {
        this.viewInput = viewInput;
    }

}
