using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The scene controller.
/// </summary>
public class SceneController : MonoBehaviour
{
    void Update()
    {
        // FIXME not the best place for game control logic.
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
