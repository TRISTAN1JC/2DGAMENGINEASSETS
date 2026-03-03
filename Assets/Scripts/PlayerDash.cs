/*using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
public Rigidbody2D rb;
bool dashing = true;
public float startDashTime;
public float dashTime;
public float dashSpeed;
public float airFrictionForce;

void PlayerDash() {
        
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * dashSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashing) {
            dashing = true;
            rb.linearVelocity = velocity;
            startDashTime = Time.time;
        }
    }
void AirFriction() {
        if (Time.time > startDashTime + dashTime) {
            rb.AddForce(new Vector2(-rb.linearVelocity.x * airFrictionForce, 0), ForceMode2D.Force);
        }
    }
private void OnCollisionEnter2D(Collision2D collision) {
			 rb.linearVelocity = Vector2.zero;
    }
void Update() {
        if (rb.linearVelocity.x == 0) {
            dashing = false;
        }

        if (!dashing) {
            PlayerDash();
        }

        if (dashing) {
            AirFriction();
        }

    }
}
*/
