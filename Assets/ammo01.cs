using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo01 : MonoBehaviour
{
	public float speed;
	private int direction;
	public int lifespan;
	private int i=0;
	
    // Start is called before the first frame update
    void Start()
    {
    direction=GameObject.FindWithTag("Player").GetComponent<player_control>().direction;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    i++;
	if (i>lifespan)
		{
		Destroy(gameObject);	
		}
    float move=speed*direction;
	GetComponent<Rigidbody>().velocity=new Vector3(move,GetComponent<Rigidbody>().velocity.y,0);
    }
	
	void OnCollisionEnter(Collision hit)
	{
	if (hit.gameObject.CompareTag("player"))
		{
		Destroy(hit.gameObject);	
		}
	Destroy(gameObject);	
	}
	
}
