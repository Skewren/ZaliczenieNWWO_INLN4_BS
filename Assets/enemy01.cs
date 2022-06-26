using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy01 : MonoBehaviour
{
	public float speed;
	private int direction=-1;
	private Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
    rb=GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	RaycastHit wall;
	Debug.DrawRay(transform.position,new Vector3(direction,0,0), Color.blue, 0.1f);
	if (Physics.Raycast(transform.position,new Vector3(direction,0,0), out wall, 0.45f, 1, QueryTriggerInteraction.Ignore))
		{
		if (wall.collider.tag!="Player")
			{
			direction=-direction;	
			}
		}
	
    float move=speed*direction;
	rb.velocity=new Vector3(move,rb.velocity.y,0);	
    }
	
	void OnCollisionEnter(Collision hit)
	{
	if (hit.gameObject.CompareTag("Player"))
		{
		hit.gameObject.GetComponent<game_mechanics>().Dead=true;
		}	
	}
	
}
