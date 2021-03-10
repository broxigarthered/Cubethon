using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DollarMovement : MonoBehaviour
{
    public Rigidbody rigidBody = new Rigidbody();
    public Transform transform;
    public float fallForce = 100000f;
    public Text textBox;

    private int score = 0;
    private bool isTapping = false;

    void Start()
    {
        Debug.Log("start");

        StartCoroutine(WaitTimeAndFall(6, 100f));
    }

    private void FixedUpdate()
    {
        HandleTap();
        HandleKeyboardKey("w");
    }

    IEnumerator WaitTimeAndFall(int time, float fallForce)
    {
        int wait_time = Random.Range(2, time);
        yield return new WaitForSeconds(wait_time);
        print("Waited time " + wait_time + "sec");

        textBox.text = "Seconds: " + wait_time;
        Fall(fallForce);
    }

    private void Fall(float fallForce)
    {
        // This starts the fall
        rigidBody.useGravity = true;
        rigidBody.AddForce(0, -fallForce, 0);
    }

    private void HandleTap()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("A tap has been recognized on the screen.");
            // TODO: restart level
        }
    }

    private void HandleKeyboardKey(string key)
    {

        if (Input.GetKey(key))
        {
            if (!isTapping)
            {
                isTapping = true;
                // TODO: Restart the level
                Debug.Log("Button pressed has been recognized on the screen.");
                score++;
                FindObjectOfType<ScoreText>().SetScoreText("Number of taps " + score.ToString());
            }
        }
    }
}


/*
 public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb = new Rigidbody();
    public Transform tr;
    public float forwardForce = 1000f;
    public float sideForce = 500f;
    public float slowSideForce = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello world! ");

        //BullshitFunctions();
    }

    // Physics are added here   
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //HandleMovementRight();
        //HandleMovementLeft();

        // TODO: This will be used for the player to get teleported
        HandleMovePlayerLeft();

        HandleMovePlayerRight();

        HandleMovePlayerBack();
    }

    public void StopPlayerFromMoving()
    {
        //rb.AddForce(0, 0, 0);
        rb.velocity = Vector3.zero;
    }

    #region Private functions
    private void EndGameOnPlayerFall()
    {
        if (tr.position.y < 0 )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void BullshitFunctions()
    {
        //rb.useGravity = false;

        //rb.AddForce(newVector(0,15));
        rb.AddForce(0, 0, 300);

        tr.SetPositionAndRotation(new Vector3(0, 1.25f, -85.0f), tr.rotation);
    }

    private void HandleMovementLeft()
    {
        Debug.Log("LEFT");
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void HandleMovementRight()
    {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void HandleMovePlayerLeft()
    {
     
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            // this.transform.position = new Vector3(this.transform.position.x - 5.0f, this.transform.position.y, this.transform.position.z);
            this.transform.position = tr.position + new Vector3(-slowSideForce, 0, 0);
        }
    }

    private void HandleMovePlayerRight()
    {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            tr.transform.position = tr.position + new Vector3(slowSideForce, 0, 0);
        }
    }

    private void HandleMovePlayerBack()
    {
        if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = tr.position + new Vector3(0, 0, -2.0f);
        }
    }
    #endregion

}
 
 */