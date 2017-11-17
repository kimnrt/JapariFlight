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

    [Header("Missile Object")]
    public Transform missile;
    public float missileDistance = .2f;
    public float timeBetweenFires = .3f;
    private float timeTilNextFire = 0.0f;
    public List<KeyCode> shootButton;

    [Header("Bomb Object")]
    public Transform bomb;
    public float bombDistance = .2f;
    public float timeBetweenDoubleClick = 1f;
    private float timeClick = 0.0f;
    public List<KeyCode> bombButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();

        foreach (KeyCode element in shootButton)
        {
            if (Input.GetKeyDown(element))
            {
                if (timeClick < 0)
                {
                    timeClick = timeBetweenDoubleClick;
                }
                else
                {
                    FireBomb();
                }
            }

            if (Input.GetKey(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                FireMissile();
                break;
            }
        }
        timeTilNextFire -= Time.deltaTime;
        timeClick -= Time.deltaTime;
    }

    public void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);
        input.Normalize();

        this.transform.Translate(input * speed * Time.deltaTime);
    }

    public void FireMissile()
    {
        Vector3 missilePos = this.transform.position;
        
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        Instantiate(missile, missilePos, rot);
    }

    public void FireBomb()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        Vector3 bombPos = new Vector3(worldPos.x, worldPos.y, this.transform.position.z);

        Quaternion rot = Quaternion.Euler(Vector3.zero);

        Instantiate(bomb, bombPos, rot);
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
