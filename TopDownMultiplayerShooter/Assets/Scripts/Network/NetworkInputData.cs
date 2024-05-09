using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementInput;

    public Vector3 rotationInput;

    public NetworkBool IsJumpPressed;

    
}
