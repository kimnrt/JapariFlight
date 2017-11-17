using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Transform target;
    public float detectRange;

    bool isAware = false;

    int attckType;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (!isAware)
            DetectPlayer();


        
	}

    void DetectPlayer()
    {
        if (detectRange >= Vector3.Distance(target.transform.position, transform.position))
        {
            isAware = true;
        }
    }

    void AttackPlayer()
    {

    }

    void FireMissile()
    {

    }


}
