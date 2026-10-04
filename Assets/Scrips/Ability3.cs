using UnityEngine;

public class Ability3 : BaseAbility
{
    public override string AbilityName
    {
        get { return "Veneno"; }
    }
    public override void Execute()
    {
        if (!CanCast())
            return;

        Debug.Log("Ejecutando Ability3");
        LaunchProjectile();
        PlayFeedback();
    }
}