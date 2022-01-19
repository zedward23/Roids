using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 thrust;
    public Quaternion heading;

    // Start is called before the first frame update
    void Start()
    {
        // travel straight in the X-axis 
        thrust.x = 400.0f;

        // do not passively decelerate 
        GetComponent<Rigidbody>().drag = 0;

        // set the direction it will travel in 
        GetComponent<Rigidbody>().MoveRotation(heading);

        // apply thrust once, no need to apply it again since 
        // it will not decelerate 
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it�s the colliding 
        // object we�re most interested in. 

        Collider collider = collision.collider;
        if (collider.CompareTag("Asteroid"))
        {

            AsteroidScript roid = collider.gameObject.GetComponent<AsteroidScript>();
            // let the other object handle its own death throes 
            roid.Die();
            // Destroy the Bullet which collided with the Asteroid 
            Destroy(gameObject);
        }
        else
        {
            // if we collided with something else, print to console 
            // what the other thing was 
            Debug.Log("Collided with " + collider.tag);
        }
    }
}
