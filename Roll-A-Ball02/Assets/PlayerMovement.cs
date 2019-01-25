using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using InControl;

public class PlayerMovement : MonoBehaviour
{

    //public float speed;
    public Text countText;
    public GameObject winText;
    public GameObject InControl;

    //private Rigidbody rb;
    private int count;

    private AudioSource audioSource;

    public AudioClip victoryClip;

    public enum MovementType { Force, Torque }
    public float speed = 25f;
    public MovementType movementType = MovementType.Torque;
    private Vector3 forward = Vector3.zero;
    private Vector3 movement = Vector3.zero;
    private Rigidbody rb = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    void FixedUpdate()
    {
        var InputDevice = InputManager.ActiveDevice;

        /*
        float moveHorizontal = InputDevice.LeftStickX;
        float moveVertical = InputDevice.LeftStickY;
        //float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);*/

        float moveHorizontal = InputDevice.LeftStickX;
        float moveVertical = InputDevice.LeftStickY;
        forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        movement = (moveVertical * forward + moveHorizontal * Camera.main.transform.right).normalized;
        if (movementType == MovementType.Force) rb.AddForce(movement * speed);
        if (movementType == MovementType.Torque) rb.AddTorque(new Vector3(movement.z, 0, -movement.x) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //other.gameObject.transform.Find("Exploson6");
            //other.gameObject.transform.GetChild(0);
            // Destroy(other.gameObject.GetChild(0));
            //StartCoroutine(Delay());

           other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
           // other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //StartCoroutine("delay");
            //PlayExplosionSound.PlaySound(2);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
           // other.gameObject.transform.GetChild(1).GetComponent<DestroyEffect>().enabled = true;
            count = count + 1;
            SetCountText();
        }
    }

    /*IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
                
    }*/

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            Debug.Log("WINNING");
            

            countText.text = "";

            StartCoroutine("winDelay");
            //Time.timeScale = 0f;
        }
    }

    IEnumerator winDelay()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
        audioSource.clip = victoryClip;
        audioSource.Play();
        InControl.SetActive(false);
        winText.SetActive(true);
    }
}