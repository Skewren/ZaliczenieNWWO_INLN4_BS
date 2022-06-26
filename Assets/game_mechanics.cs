using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_mechanics : MonoBehaviour
{
	public int coinCount=0;
	public bool Dead;
	public float threshold;
	public Text death_string;
	public Text coin_string;
	public Text win_string;
    

    void Start()
	{
	Dead=false;
	death_string.text="";
	win_string.text="";
	coin_string.text="Coins: "+coinCount.ToString("F0");
	}

    void Update()
    {
        if (Dead)
        {
            death_string.text = "You died! Press 'space' to restart.";
            Destroy(GetComponent<player_control>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Renderer>());
		if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        if (transform.position.y < threshold)
        {
            Dead = true;
        }
    }

        void OnTriggerEnter(Collider collect)
        {
            if (collect.gameObject.CompareTag("coin"))
            {
                coinCount++;
                Destroy(collect.gameObject);
                coin_string.text = "Coins: " + coinCount.ToString("F0");
            }


        if (collect.gameObject.CompareTag("Finish") && coinCount == 1)
            {
                win_string.text = "You won!";
                Destroy(GetComponent<player_control>());
                Destroy(GetComponent<Rigidbody>());
                Destroy(GetComponent<Collider>());
                Destroy(GetComponent<Renderer>());
            }
        if (collect.gameObject.CompareTag("obstacle"))
        {
            Dead = true;
        }
    }
     
      
}
