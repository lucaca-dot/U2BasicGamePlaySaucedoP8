using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float ZRange = 10;
    public float xRange = 23;
    public GameObject ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Keep the player inbounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Keep the player inbounds
        if (transform.position.z < -ZRange)
        {
            transform.position = new Vector3(transform.position.z, transform.position.y, -ZRange);
        }
        if (transform.position.z > ZRange)
        {
            transform.position = new Vector3(transform.position.z, transform.position.y, ZRange );
        }




        // We will the projectile shoot out
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(ProjectilePrefab, transform.position, ProjectilePrefab.transform.rotation);
        }
            

        
    }
}
