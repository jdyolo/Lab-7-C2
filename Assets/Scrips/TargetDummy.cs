using UnityEngine;
using MoreMountains.Feedbacks;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private MMF_Player normalImpactFeedback;
    [SerializeField] private MMF_Player durationImpactFeedback;

    public void ApplyStatus(StatusEffect effect)
    {
        Debug.Log("Estado aplicado al muñeco: " + effect);

        if (normalImpactFeedback != null)
        {
            normalImpactFeedback.PlayFeedbacks();
        }
    }

    public void ApplyStatus(StatusEffect effect, float duration)
    {
        Debug.Log("Estado aplicado al muñeco: " + effect + " durante " + duration + " segundos.");

        if (durationImpactFeedback != null)
        {
            durationImpactFeedback.PlayFeedbacks();
        }
    }
}