using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public static int points = 0;

    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + points;

        RestrictMovement();

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);
    }

    private void RestrictMovement()
    {
        if(transform.position.y >= 3.93f)
        {
            gameObject.transform.position = new Vector3(-4.28f, 3.93f, 0.008284654f);
        }

        if(transform.position.y <= -3.9f)
        {
            gameObject.transform.position = new Vector3(-4.28f, -3.9f, 0.008284654f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            points = 0;
            SceneManager.LoadScene("GameLose");
        }
    }
}
