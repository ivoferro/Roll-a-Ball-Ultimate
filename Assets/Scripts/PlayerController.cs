using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// The speed factor used to calculated force applied to the rigid body.
    /// </summary>
    public float speedFactor = 1;

    /// <summary>
    /// The rigid body of the player.
    /// </summary>
    private Rigidbody rigidBody;

    /// <summary>
    /// The explosion game object.
    /// </summary>
    public GameObject explosion;

    /// <summary>
    /// The count of the picked items.
    /// </summary>
    private int countPickedItems;

    /// <summary>
    /// The UI text element to display the picked items.
    /// </summary>
    public Text countPickedItemsText;

    /// <summary>
    /// The total number of items to pick up.
    /// </summary>
    private int totalPickItems;

    /// <summary>
    /// The UI text to display the win/lose messages.
    /// </summary>
    public Text winLoseText;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        countPickedItems = 0;
        totalPickItems = GameObject.FindGameObjectsWithTag("Pick Up").Length;

        SetCountText();
        winLoseText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.AddForce(movement * speedFactor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            countPickedItems++;
            SetCountText();

            if (countPickedItems >= totalPickItems)
            {
                SetWinMessage();
                ExploadEnemies();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
            SetLoseMessage();
        }
    }

    private void ExploadEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
            Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
        }
    }

    void SetCountText()
    {
        countPickedItemsText.text = "Score: " + countPickedItems;
    }

    void SetWinMessage()
    {
        winLoseText.text = "You Won!";
    }

    void SetLoseMessage()
    {
        winLoseText.text = "You Lost! Press R to restart!";
    }
}
