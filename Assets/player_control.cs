using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_control : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody rb;
    private bool onGround = false;
    public int direction = 1;
    public GameObject ammo;
    public int ammocount = 6;
    public Text ammo_string;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ammo_string.text = "Ammo: " + ammocount.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ground;
        for (float i = -0.45f; i <= 0.45f; i = i + 0.45f)
        {
            Vector3 pozycja = new Vector3(i, 0, 0) + transform.position;
            Debug.DrawRay(pozycja, -Vector3.up, Color.red, 0.1f);
            if (Physics.Raycast(pozycja, new Vector3(0, -1, 0), out ground, 0.6f, 1, QueryTriggerInteraction.Ignore))
            {
                if (ground.collider.tag == "enemy")
                {
                    Destroy(ground.collider.gameObject);
                    Jump();
                    break;
                }
                onGround = true;
                break;
            }
            else
            {
                onGround = false;
            }
        }


        if (Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //ammocount--;

            if (ammocount > 0)
            {
                Vector3 shot_pos = transform.position + new Vector3(direction, 0, 0);
                Instantiate(ammo, shot_pos, transform.rotation);
                ammocount--;
            }
            else if (ammocount == 0) { return; }
            
        }
        ammo_string.text = "Ammo: " + ammocount.ToString("F0");
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal") * speed;
        if (move > 0)
        {
            direction = 1;
        }
        if (move < 0)
        {
            direction = -1;
        }
        rb.velocity = new Vector3(move, rb.velocity.y, 0);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
    void OnTriggerEnter(Collider collect)
    {


        if (collect.gameObject.CompareTag("ammo"))
        {
            if (ammocount <= 0)
            {
                ammocount = 0;
                ammocount = ammocount + 6;
                Destroy(collect.gameObject);
            }
            else
            {

                ammocount = ammocount + 6;
                Destroy(collect.gameObject);
            }

        }
    }
}
