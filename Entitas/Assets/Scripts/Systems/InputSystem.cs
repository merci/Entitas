using UnityEngine;
using Entitas;

public class InputSystem :IExecuteSystem
{
    private readonly Contexts _contexts;
    private Vector2 inputVal;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }


    public void Execute()
    {
        var inputEntity = _contexts.input.CreateEntity();
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        inputVal = new Vector2(inputX, inputY);
        inputEntity.AddInputCom(inputVal);
    }
}
