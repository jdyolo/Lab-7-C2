using UnityEngine;

public class Ability1 : BaseAbility
{
    public override string AbilityName
    {
        get { return "Fuego"; }
    }

    public override void Execute()
    {
        if (!CanCast())
            return;

        Debug.Log("Ejecutando Ability1");
        LaunchProjectile();
        PlayFeedback();
    }

    protected override void PlayFeedback()
    {
        base.PlayFeedback();
        Debug.Log("Ability1 lanzó su feedback especial.");
    }
}