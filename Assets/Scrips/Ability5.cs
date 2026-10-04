using UnityEngine;

public class Ability5 : BaseAbility
{
    public override string AbilityName
    {
        get { return "Lentitud"; }
    }
    public override void Execute()
    {
        if (!CanCast())
            return;

        Debug.Log("Ejecutando Ability5");
        LaunchProjectile();
        PlayFeedback();
    }
}