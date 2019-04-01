using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // variables
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletForce;
    public float moveSpeed;
    Rigidbody2D myRigidbody;
    public int typeOfShooting;
    public static int partsCount = 0;

    void Start()
    {
        // get our rigidbody component
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (typeOfShooting == 0)
        {
            AimShootMoveToShot();
        }
        if (typeOfShooting == 1)
        {
            WASDandArrowMovement();
            ClickToShoot();
        }
    }
    void WASDandArrowMovement()
    {
        // move by transform
        // increase speed to move faster since this will be slow
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
    }
    void ClickToShoot()
    {
        // if mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn Bullet
            GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            // Add force in direction aimed
            newBullet.GetComponent<Rigidbody2D>().AddForce(MouseDirection() * bulletForce, ForceMode2D.Impulse);
        }
    }
    // Where you click, your character moves towards
    void AimShootMoveToShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn Bullet
            GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            // Add force in direction aimed
            newBullet.GetComponent<Rigidbody2D>().AddForce(MouseDirection() * bulletForce, ForceMode2D.Impulse);
            // Make sure our character is not moving
            myRigidbody.velocity = Vector2.zero;
            // add force to the direction shot
            myRigidbody.AddForce(MouseDirection() * moveSpeed, ForceMode2D.Impulse);
        }
    }

    Vector3 MouseDirection()
    {
        // Get the mouse position values
        Vector3 mousePos = Input.mousePosition;
        // make that a world position (a game world position)
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        // get the direction the mouse is aimed from the player
        Vector3 direction = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        // make the vector3 found 1 so we can increase it the way we want
        return direction.normalized;
    }

    public static void ShipCounter()
    {
        if (partsCount >= 4)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
