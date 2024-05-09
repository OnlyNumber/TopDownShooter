using Fusion;
using Fusion.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class NetworkRunnerHandler : MonoBehaviour
{
    [SerializeField]
    private NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunner;

    void Start()
    {
        networkRunner = Instantiate(networkRunnerPrefab);
        networkRunner.name = "Network runner";

        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(), SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex), null);


    }

    public virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if (sceneManager == null)
        {
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "TetRoom",
            OnGameStarted = initialized,
            SceneManager = sceneManager
        });

    }

}
