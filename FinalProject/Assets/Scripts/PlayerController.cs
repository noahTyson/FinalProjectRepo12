using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    // How to make a C# ----> Accesor datatype varName


    public CharacterController controller; // A var to hold the players char controller component


    public float moveSpeed = 5;


    private Vector3 moveDirections = Vector3.zero;


    public int health;


    private EnemyFollow enemy;


    public float rotateSpeed = 5f; // speed the player rotate


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();


        enemy = FindObjectOfType<EnemyFollow>();

    }


    // Update is called once per frame
    void Update()
    {
         // gather input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // calculate direction the player should based on our collected input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);


        // move the player based on input
        controller.Move(movement * moveSpeed * Time.deltaTime);

        {
        //rotate the player in direction they are moving over time
        Quaternion targetRotation = Quaternion.LookRotation(movement); // storing the rotation needed

        // rotate the player based on its current Rotation values and the target rotation value
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            // trigger the damage
            health = health - enemy.damage;

            if(health <=0)
            {   
                GameManager.Instance.GameOver();

                Destroy(gameObject);
                AudioManager.Instance.PlaySound("PlayerDeath");
            }
        }
    }
}

