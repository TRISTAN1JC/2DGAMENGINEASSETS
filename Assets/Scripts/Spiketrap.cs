using UnityEngine;

public class Spiketrap : MonoBehaviour
{
  [SerializeField] float damage = 10f;
  void OnTriggerStay2D(Collider2D other)
  {
    if(other.TryGetComponent(out IDamageable damageable))
    {
        damageable.ApplyDamage (damage);
    }
  }
}