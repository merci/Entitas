using Entitas;
using UnityEngine;

public class InitializeSystem : IInitializeSystem
{
    private readonly Contexts _contexts;  


    public InitializeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        GeneratePlayer();
    }


    private void GeneratePlayer()
    {
        //创建entity
        var playerEntity = _contexts.game.CreateEntity();
        //添加属性组件，赋初始值
        playerEntity.isPlayerTag = true;
        playerEntity.AddMoveCom(5f,20f);
        playerEntity.AddMoveDirCom(Vector3.zero);
        playerEntity.AddCreateObjCom("Player");
    }
}
    

