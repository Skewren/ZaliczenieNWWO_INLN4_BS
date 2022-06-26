using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
	public float MinX;
	public float MaxX;
	public float MinY;
	public float MaxY;
	public float Offset;
	public float Distance;
	private GameObject Player;
	
    // Start is called before the first frame update
    void Start()
    {
    Player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    float posX=Player.transform.position.x;
	float posY=Player.transform.position.y;

	posX=Mathf.Clamp(posX, MinX, MaxX);
    posY=Mathf.Clamp(posY, MinY, MaxY)+Offset;
	
	transform.position=new Vector3(posX,posY,Distance);
    }
}
