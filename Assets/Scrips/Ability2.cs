using UnityEngine;

public class Ability2 : BaseAbility
{
    public override string AbilityName
    {
        get { return "Hielo"; }
    }
    public override void Execute()
    {
        if (!CanCast())
            return;

        Debug.Log("Ejecutando Ability2");
        LaunchProjectile();
        PlayFeedback();
    }

    protected override void PlayFeedback()
    {
        base.PlayFeedback();
        Debug.Log("Ability2 lanzó su feedback especial.");
    }
}