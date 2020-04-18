using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameSystems _gameSystems;

    private void Awake()
    {
        _gameSystems = new GameSystems(Contexts.sharedInstance);
    }


    private void Start()
    {
        // 初始化系统
        _gameSystems.Initialize();
    }

    private void Update()
    {
        //每帧去执行
        _gameSystems.Execute();
        _gameSystems.Cleanup();
    }

    private void OnDestroy()
    {
        //回收
        _gameSystems.TearDown();
    }
}
