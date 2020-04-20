using UnityEngine;
using Entitas;

public class InputSystem :IExecuteSystem
{
    private readonly Contexts _contexts;
    //private InputEntity inputEntity;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
       
    }


    public void Execute()
    {
        var inputEntity = _contexts.input.CreateEntity();
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        inputEntity.AddInputCom(new Vector2(inputX, inputY));
    }
}
