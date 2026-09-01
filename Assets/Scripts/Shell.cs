using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 0f;
    float yspeed = 0f;
     float mass = 1f;
     float force = 100;
     float drag = 1f;
     float gravity = -1f;
     float gaccel;
    
    float acceleration;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;
        gaccel = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1-Time.deltaTime * drag);
        yspeed += gaccel * Time.deltaTime;
        this.transform.Translate(0,yspeed,speed * Time.deltaTime);

    }
}
