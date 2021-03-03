using UnityEngine;

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
