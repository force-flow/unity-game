using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public GameObject bullet;
    GameObject BulletClone;
    Rigidbody clone;
    public Text text;
    int hp = 15;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        text.text = "Health: " + hp;
    }

    // Update is called once per frame
    void Update()
    {
     	float MoveVert = Input.GetAxis("Vertical");
    	rb.AddForce(transform.forward * MoveVert * 20f); 

        float Rotate = Input.GetAxis("Horizontal");
        transform.Rotate(0, Rotate * 5f, 0); 

        if(Input.GetKeyDown("space")) {
        	BulletClone = Instantiate(bullet,  new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        	BulletClone.gameObject.tag = "Bullet";
        	clone = GetComponent<Rigidbody>();
        	clone.AddForce(transform.forward * 500);
        }      
    }
    void OnCollisionEnter(Collision col)
        {
        	if(col.gameObject.tag=="Enemy"){
        		hp --;
        		text.text = "Health:" + hp;
        		if(hp <= 0){
	                SceneManager.LoadScene(1);
	                hp = 0;
        		}
        	}
        }
}
