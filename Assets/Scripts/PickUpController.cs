using UnityEngine;

/// <summary>
/// The pick up controller.
/// </summary>
public class PickUpController : MonoBehaviour {

	void Update () {
        // Rotate the pick up object every frame to give feedback to the player.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
