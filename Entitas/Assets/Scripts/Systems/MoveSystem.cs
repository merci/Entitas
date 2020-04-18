using UnityEngine;
using Entitas;

/// <summary>
/// 移动逻辑的处理
/// IExecuteSystem ： ISystem
/// </summary>
public class MoveSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        //从GameEntity中获取包含速度，位置组件的entity实体
        _group = _contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.MoveCom,
            GameMatcher.ViewCom
        ));
    }


    ////实现接口 
    public void Execute()
    {
        foreach (var entity in _group.GetEntities())
        {
            //当玩家位置发生变化时
            if(entity.moveDirCom.moveDir != Vector3.zero)
            {
                var moveVal = entity.moveCom.moveSpeed;
                var rotateVal = entity.moveCom.rotateSpeed;
                Move(entity, entity.moveDirCom.moveDir, rotateVal, moveVal);
            }
        }
    }

    /// <summary>
    /// 玩家朝向
    /// </summary>
    private void LookAtTarget(GameObject go, Vector3 dir,float rotateSpeed)
    {
        Quaternion lookDir = Quaternion.LookRotation(dir);
        go.transform.rotation = Quaternion.Lerp(go.transform.rotation,lookDir, rotateSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    private void Move(GameEntity entity, Vector3 dir, float rotateSpeed, float moveSpeed)
    {
        var go = entity.viewCom.go;
        LookAtTarget(go, dir, rotateSpeed);
        Vector3 forward = go.transform.forward;
        go.transform.Translate(forward * moveSpeed * Time.deltaTime,Space.World);

    }
}
