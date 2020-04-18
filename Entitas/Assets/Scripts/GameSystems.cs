/// <summary>
/// 游戏系统集合，用于管理所有系统
/// Feature : Entitas.Systems 一组系统的集合
/// </summary>
public class GameSystems : Feature
{

    public GameSystems(Contexts contexts)
    {
        //初始化Entity
        Add(new InitializeSystem(contexts));
        //玩家输入
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));

        //移动
        Add(new MoveSystem(contexts));

        //创建玩家对象
        Add(new CreateObjSystem(contexts));
        //清理
        Add(new InputCleanupSystem(contexts));
    }
}
