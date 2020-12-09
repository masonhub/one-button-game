using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    bool isGrounded = false;
    bool candoublejump;
// Player Function variable

    float posX = 0.0f;
   bool isGameOver = false;
    ChallengeController myChallengeController;
    GameController myGameController;
    public AudioClip jump;
    AudioSource myAudioPlayer;
    public AudioClip scoreSFX;
    public AudioClip deadSFX;
// Adding new backgrounds variables

  
    void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
        myGameController = GameObject.FindObjectOfType<GameController>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
    }
	
	
	void FixedUpdate () {
        if (isGrounded)
        {
            candoublejump = true;
        }
        if (Input.GetKey(KeyCode.Space) ) {
            if (isGrounded)
            {
                Debug.Log("Jump once");
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 10.0f));
                myAudioPlayer.PlayOneShot(jump);
               // isGrounded = false;
            }
            else
            {
                if (candoublejump)
                {
                    Debug.Log("Double Jump");
                    myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 10.0f));
                    myAudioPlayer.PlayOneShot(jump);
                    candoublejump = false;
                }
            }

        }
       
  

	}

    //End the game
    void GameOver() {
        isGameOver = true;
        myChallengeController.GameOver();
    }



    void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }


    void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
            Reset();
        }
   
}
     public void Reset()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Star") {
            myGameController.IncrementScore();
            myAudioPlayer.PlayOneShot(scoreSFX);
            Destroy(other.gameObject);
        }
    }
}
