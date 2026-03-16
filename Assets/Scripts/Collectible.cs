using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
   // [SerializeField]
    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (pickupEffectPrefab != null)
    {
       ParticleSystem effect = Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
       effect.Play();

        //optional
        //Destroy.gameObject, effect.mainduration +
        } */
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectibleSFX);
            //GameManager.Instance.AddCollectible();
            Destroy (gameObject);
        }
    }
}
