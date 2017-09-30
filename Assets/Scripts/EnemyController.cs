using UnityEngine;

/// <summary>
/// The enemy controller.
/// </summary>
public class EnemyController : MonoBehaviour {

    /// <summary>
    /// The player game object.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The speed factor.
    /// </summary>
    public float speedFactor = 1;

    /// <summary>
    /// The enemy rigid body.
    /// </summary>
    private Rigidbody rigidBody;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // adds a force into the player direction (follows the player)
        rigidBody.AddForce((player.transform.position - this.transform.position) * speedFactor * Time.deltaTime);
    }
}
