using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
	public float speed

    void FixedUpdate()
    {
    transform.Rotate(new Vector3(0,speed,0))
    }
}
