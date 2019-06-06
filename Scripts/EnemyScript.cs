using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    NavMeshAgent enemy;
    static int score = 0;
    public Text text;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
         text.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision col)
        {
        	if(col.gameObject.tag=="Bullet"){
        		Destroy(gameObject);
        		score++;
        		if(score >= 5){
	                SceneManager.LoadScene(0);
	                score = 0;
        		}
        	}
        }
}
