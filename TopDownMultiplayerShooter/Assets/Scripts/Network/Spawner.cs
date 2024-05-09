using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer playerPrefab;

    private CharacterInputHandler CharacterInputHandler;

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if(CharacterInputHandler == null && NetworkPlayer.local != null)
        {
            CharacterInputHandler = NetworkPlayer.local.GetComponent<CharacterInputHandler>();
        }

        if(CharacterInputHandler != null)
        {
            input.Set(CharacterInputHandler.GetNetworkInput());
        }

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(runner.IsPlayer)
        {
            var transfer = runner.Spawn(playerPrefab, Vector3.zero + Vector3.up * 2 ,Quaternion.identity, player);

            //transfer.GetComponent<NetworkCharacterControllerCustom>().enabled = true;
            //transfer.GetComponent<CharacterMovementHandler>().enabled = true;

            StartCoroutine(DelayBeforePlay(transfer));
        }
        else
        {
            Debug.Log("OnPlayerJoined");
        }
    }
    private IEnumerator DelayBeforePlay(NetworkPlayer transfer)
    {
        yield return new WaitForSeconds(1);
        transfer.GetComponent<NetworkCharacterControllerCustom>().enabled = true;
        transfer.GetComponent<CharacterMovementHandler>().enabled = true;

    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
}
