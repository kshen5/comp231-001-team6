using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject explosion;
    public ControlHealth healthBar;
    public static float bulletForce;
    Vector3 dirFrom;
    public GameObject bullet, smallShip, bigShip;
    Transform player;
    public string shipType;
    Vector2 screenSize;
    float nextShootTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player") != null ? GameObject.FindGameObjectWithTag("Player").transform : null;
        // Add Character size to screen size
        Vector3 charSize = transform.localScale;
        // get the size of camera
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + (charSize.x * 2), Camera.main.orthographicSize + (charSize.y * 2));
    }
    void Update()
    {
        if (player != null)
        {
            dirFrom = player.position - transform.position;
            float distance = dirFrom.magnitude;

            if (Time.time > nextShootTime)
            {
                int randomNextShootTime = Random.Range(1, 3);
                nextShootTime = Time.time + randomNextShootTime;
                ShootPlayer();
            }
        }
        ShipWrapAround();
    }
    private void ShootPlayer()
    {
        if(shipType == "King")
        {
            GameObject newBullet1 = Instantiate(bullet, new Vector3(this.transform.position.x - 1, transform.position.y), Quaternion.identity);
            GameObject newBullet2 = Instantiate(bullet, new Vector3(this.transform.position.x + 1, transform.position.y), Quaternion.identity);
            GameObject newBullet3 = Instantiate(bullet, this.transform.position , Quaternion.identity);
            newBullet1.transform.up = dirFrom.normalized;
            newBullet2.transform.up = dirFrom.normalized;
            newBullet3.transform.up = dirFrom.normalized;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
            newBullet2.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
            newBullet1.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
        }
        if (shipType == "Big")
        {
            GameObject newBullet1 = Instantiate(bullet, new Vector3(this.transform.position.x - 1, transform.position.y), Quaternion.identity);
            GameObject newBullet2 = Instantiate(bullet, new Vector3(this.transform.position.x + 1, transform.position.y), Quaternion.identity);
            newBullet1.transform.up = dirFrom.normalized;
            newBullet2.transform.up = dirFrom.normalized;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
            newBullet1.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
        }
        if (shipType == "Small")
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
            newBullet.transform.up = dirFrom.normalized;
            newBullet.GetComponent<Rigidbody2D>().AddForce(dirFrom.normalized * bulletForce, ForceMode2D.Impulse);
        }
    }
    private void ShipWrapAround()
    {
        // wrap object around screen if goes off camera
        if (transform.position.x < -screenSize.x)
        {
            transform.position = new Vector3(screenSize.x, transform.position.y);
        }
        if (transform.position.x > screenSize.x)
        {
            transform.position = new Vector3(-screenSize.x, transform.position.y);
        }
        if (transform.position.y < -screenSize.y)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y);
        }
        if (transform.position.y > screenSize.y)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if hit player, game over and destroy player
        if (collision.tag == "Player")
        {
            AsteroidGameManager.gameOver = true;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Bullet")
        {
            // if hit big rock, destroy rock and spawn small rocks
            if (shipType == "King")
            {
                Instantiate(bigShip, new Vector3((transform.position.x - 1), transform.position.y), Quaternion.identity);
                Instantiate(bigShip, new Vector3((transform.position.x + 1), transform.position.y), Quaternion.identity);
                AsteroidGameManager.currentScore += 10;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            if (shipType == "Big")
            {
                Instantiate(smallShip, new Vector3((transform.position.x - 1), transform.position.y), Quaternion.identity);
                Instantiate(smallShip, new Vector3((transform.position.x + 1), transform.position.y), Quaternion.identity);
                AsteroidGameManager.currentScore += 5;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            if (shipType == "Small")
            {
                // if hit small rock, destroy rock and subtract a half a point from the spawn rate(2 halfs make a full - .5 + .5 = 1) so we know a big rock has been completely destroyed
                // Add Point
                AsteroidGameManager.currentScore += 2;
                AsteroidSpawner.spawnAmount -= .5f;
                AsteroidSpawner.shipsLeft -= .5f;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            GameObject newExplosion = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(newExplosion, 2);
        } 
        // if hit big ship, destroy rock and spawn small rocks
        //healthBar.hit = true;
    }
}
