//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewCom viewCom { get { return (ViewCom)GetComponent(GameComponentsLookup.ViewCom); } }
    public bool hasViewCom { get { return HasComponent(GameComponentsLookup.ViewCom); } }

    public void AddViewCom(UnityEngine.GameObject newGo) {
        var index = GameComponentsLookup.ViewCom;
        var component = (ViewCom)CreateComponent(index, typeof(ViewCom));
        component.go = newGo;
        AddComponent(index, component);
    }

    public void ReplaceViewCom(UnityEngine.GameObject newGo) {
        var index = GameComponentsLookup.ViewCom;
        var component = (ViewCom)CreateComponent(index, typeof(ViewCom));
        component.go = newGo;
        ReplaceComponent(index, component);
    }

    public void RemoveViewCom() {
        RemoveComponent(GameComponentsLookup.ViewCom);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewCom;

    public static Entitas.IMatcher<GameEntity> ViewCom {
        get {
            if (_matcherViewCom == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewCom);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewCom = matcher;
            }

            return _matcherViewCom;
        }
    }
}