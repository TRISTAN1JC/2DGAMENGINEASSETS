using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth: MonoBehaviour, IDamageable
{
  [SerializeField] float maxHealth = 100f;
  [SerializeField] float invulnerabilityDuration = 0.1f;
  [SerializeField] float blinkInterval = 0.1f;

  float currentHealth;

  float invulnerabilityTimer;

  SpriteRenderer sprite;

  float blinkTimer;

  bool blinking;

  void Awake()
  {
    currentHealth = maxHealth
    sprite = GetComponent<SpriteRenderer>();
  }
  void Update()
  {
    if(invulnerabilityTimer > 0f)
    {
        invulnerabilityTimer -= Time.deltaTime;
    }
  }
  public bool ApplyDmamage(float amount)
  {
    if(currentHealth <= 0f || invulnerabilityTimer >0f)
    return false;
    
    currentHealth -= amount;
    if (currentHealth <= 0f)
    {
        Die();
        return true;
    }
    invulnerabilityTimer = invulnerabilityDuration
    StartBlink(invulnerabilityDuration);
    return true;
  }


  void StartBlink (float duration)
  {

  }


  void HandleBlink ()
  {
    if(!blinking) return;
    blinkTimer -= Time.deltaTime;
    if(blinkTimer <= 0f)
    {
        blinking = false;
        sprite.enabled = true;
        return;
    }
    //ISSUES WITH .NET
    sprite.enabled =
    Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 == 0;
  }


  void Die()
  {
    //setactive -> is stopping shit like camera going wild after dying by having it remain as a real thing 
    //for bullets use destroy game object
      gameObject.SetActive(false);
  }
}