using UnityEngine;

public class Ability4 : BaseAbility
{
    public override string AbilityName
    {
        get { return "Rayo"; }
    }
    public override float Cooldown
    {
        get { return 0.4f; }
    }

    public override void Execute()
    {
        if (!CanCast())
            return;

        Debug.Log("Ejecutando Ability4 | Cooldown especial: " + Cooldown);
        LaunchProjectile();
        PlayFeedback();
    }
}