using UnityEngine;
using System.Collections;

public class BlowMechanic : MonoBehaviour
{
    public float distance=1f;
	public LayerMask boxMask;
    GameObject /* box might need to be changed */ box;
  
    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && /*hit.collider.gameObject.tag == "pushable" &&*/ Input.GetKeyDown (KeyCode.E))
        {
        print ("E pressed");
        box = hit.collider.gameObject;
        box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
		box.GetComponent<FixedJoint2D> ().enabled = true;
       // box.GetComponent<boxpull> ().beingPushed = true;


        } else if (Input.GetKeyUp (KeyCode.E)) {
						box.GetComponent<FixedJoint2D> ().enabled = false;
					//	box.GetComponent<boxpull> ().beingPushed = false;
	}

    }

    //Showing the raycast 
    void OnDrawGizmos()
    {
        Gizmos.color= Color.blue;
        Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
