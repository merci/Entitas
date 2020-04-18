using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

/// <summary>
/// 处理玩家输入
/// </summary>
public class InputProcessSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _playerGroup;

    public InputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _playerGroup = _contexts.game.GetGroup(GameMatcher.PlayerTag);
    }
       

    protected override void Execute(List<InputEntity> entities)
    {
        var playerEntity = _playerGroup.GetSingleEntity();

        foreach (var inputEntity in entities)
        {
            float x = inputEntity.inputCom.inputValue.x;
            float z = inputEntity.inputCom.inputValue.y;

            playerEntity.ReplaceMoveDirCom(new Vector3(x, 0, z));
        }
        
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputCom;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputCom);
    }

}
