using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed;

    public Text score;
    [SerializeField]
    private int scoreValue = 0;
    public Text youWin;
    public Text lives;
    private int livesCount = 3;
    public CameraScript camscript;
    public Animator anim;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        lives.text = "Lives: " + livesCount.ToString();
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rb2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
    private void Update()
    {
        anim.SetFloat("Axis", Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") < -.1f)
        {
            transform.eulerAngles = new Vector2(this.transform.rotation.x, 180);
        } else if (Input.GetAxis("Horizontal") > .1f)
        {
            transform.eulerAngles = new Vector2(this.transform.rotation.x, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue == 4)
            {
                this.transform.position = new Vector2(42, this.transform.position.y);
                camscript.level2 = true;
                livesCount = 3;
                lives.text = "Lives: 3";
            }
        }
        if (scoreValue == 8)
        {
            youWin.gameObject.SetActive(true);
            camscript.didwin = true;
        }
        if (collision.collider.tag == "Enemy")
        {
            livesCount -= 1;
            lives.text = "Lives: " + livesCount.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (livesCount == 0)
        {
            youWin.gameObject.SetActive(true);
            youWin.text = "You lose";
            Destroy(this.gameObject);
        }

    }
}