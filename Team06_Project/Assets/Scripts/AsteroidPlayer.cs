using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPlayer : MonoBehaviour
{
    #region Variables
    public GameObject explosion;
    public GameObject bullet;
    public Transform bulletSpawn;
    public bool wasdMovement;
    public float bulletSpeed;
    public float pushForce;
    public float velocityLimit;
    Vector2 screenSize;
    float halfWidth;
    Rigidbody2D rb;
    #endregion

    private void Start()
    {
        // Add Character size to screen size
        Vector3 charSize = transform.localScale;
        // get the size of camera
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + charSize.x, Camera.main.orthographicSize + charSize.y);
        // get the rigidbody of the player
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(wasdMovement)
        {
            WASDMovement();
        }
        // restrict how fast the character can move
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, velocityLimit);
        // if we press down on the left mouse button, we shoot
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        // if we press down on the right mouse button, we boost
        if(Input.GetMouseButtonDown(1))
        {
            Boost();
        }
        // make player look at mouse
        LookAtMouse();
        // make player wrap around map
        PlayerWrapAround();
    }
    private void WASDMovement()
    {
        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * pushForce, ForceMode2D.Impulse);
    }
    private void Shoot()
    {
        // spawn new bullet
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        // add a force to the bullet in the direction the mouse is aimed
        newBullet.GetComponent<Rigidbody2D>().AddForce(GetMouseDirection().normalized * bulletSpeed, ForceMode2D.Impulse);
        // destroy bullet after two seconds
        Destroy(newBullet, 2);
    }
    private void LookAtMouse()
    {
        // make the players up direction(tip of triangle) aim at the mouse 
        transform.up += GetMouseDirection();
    }
    Vector3 GetMouseDirection()
    {
        // get the direction of the mouse in a vector 3
        Vector3 mousePosition = Input.mousePosition;
        // translate that to world units to use in the Orthographics camera's point in space
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // get the direction we are looking at on the x and y axis
        Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        // return the direction
        return direction;
    }
    private void Boost()
    {
        // add force to the player where he is looking
        rb.AddForce(GetMouseDirection().normalized * pushForce, ForceMode2D.Impulse);
    }
    private void PlayerWrapAround()
    {
        // wrap player around screen screen by using the cameras width and height
        if(transform.position.x < -screenSize.x)
        {
            transform.position = new Vector3(screenSize.x, transform.position.y);
        }
        if (transform.position.x > screenSize.x)
        {
            transform.position = new Vector3(-screenSize.x, transform.position.y);
        }
        if (transform.position.y < -screenSize.y)
        {
            transform.position = new Vector3(transform.position.x , screenSize.y);
        }
        if (transform.position.y > screenSize.y)
        {
            transform.position = new Vector3(transform.position.x, - screenSize.y);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Bullet")
        {
            GameObject newExplosion = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(newExplosion, 2);
            AsteroidGameManager.gameOver = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
