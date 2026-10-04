using UnityEngine;
using MoreMountains.Feedbacks;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float projectileSpeed = 5f;

    [Header("Feel")]
    [SerializeField] protected MMF_Player castFeedback;

    protected float lastCastTime = -100f;

    public virtual float Cooldown
    {
        get { return 1f; }
    }

    public abstract string AbilityName { get; }

    public abstract void Execute();

    protected bool CanCast()
    {
        if (Time.time < lastCastTime + Cooldown)
        {
            Debug.Log("Habilidad en cooldown.");
            return false;
        }

        lastCastTime = Time.time;
        return true;
    }

    protected void LaunchProjectile()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * projectileSpeed;
        }
    }

    protected virtual void PlayFeedback()
    {
        if (castFeedback != null)
        {
            castFeedback.PlayFeedbacks();
        }
    }
}