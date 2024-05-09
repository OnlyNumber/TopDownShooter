using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local { get; set; }

    public override void Spawned()
    {
        base.Spawned();

        if (Object.HasInputAuthority)
        {
            local = this;

        }

    }
    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
        }
    }


}
