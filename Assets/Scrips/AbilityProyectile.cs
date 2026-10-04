using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
    [SerializeField] private StatusEffect effect;
    [SerializeField] private float duration = 3f;
    [SerializeField] private bool useDuration = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TargetDummy dummy = collision.GetComponent<TargetDummy>();

        if (dummy != null)
        {
            if (useDuration)
                dummy.ApplyStatus(effect, duration);
            else
                dummy.ApplyStatus(effect);

            Destroy(gameObject);
        }
    }
}