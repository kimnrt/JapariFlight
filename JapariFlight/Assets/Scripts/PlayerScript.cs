using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public const float maxHealth = 100f;  // max health gauge
    public float currentHealth = maxHealth;// current health gauge

    public float speed = 10f;       // move speed
    public int score = 0;           // score
    public float power = 0f;        // power gauge
    public float atk = 1f;          // attack damage
    public int stock = 3;           // life stock

    public Image lifebar;           //

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}

    public void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);
        input.Normalize();

        this.transform.Translate(input * speed * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            print("Dead");
        }
        lifebar.GetComponent<RectTransform>().sizeDelta = new Vector2(currentHealth, 10);
    }
}
