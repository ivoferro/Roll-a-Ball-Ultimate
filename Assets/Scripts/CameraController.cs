using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The camera controller.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// The player game object.
    /// </summary>
    public GameObject player;


    /// <summary>
    /// The off set between the camera and the player.
    /// </summary>
    private Vector3 offSet;

    void Start()
    {
        offSet = this.transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
