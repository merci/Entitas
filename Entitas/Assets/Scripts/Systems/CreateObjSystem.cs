using System.Collections.Generic;
using Entitas;
using UnityEngine;


/// <summary>
/// 创建物体系统
/// </summary>
public class CreateObjSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public CreateObjSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCreateObjCom;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CreateObjCom);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var obj = GenarateObj(entity);
            entity.AddViewCom(obj);
            entity.RemoveCreateObjCom();
        }
    }


    private GameObject GenarateObj(GameEntity gameEntity)
    {
        var path = gameEntity.createObjCom.path;
        var prefab = Resources.Load<GameObject>(path);
        var obj = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        var view = obj.GetComponent<View>();
        view.Link(_contexts, gameEntity);
        return obj;
    }
}
