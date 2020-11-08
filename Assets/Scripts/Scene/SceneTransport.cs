using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTransport : MonoBehaviour
{
    public SceneName sceneNameGoto = SceneName.Scene1_Farm;
    public Vector3 scenePosition = new Vector3();

    private void OnTriggerStay2D(Collider2D target)
    {
        Player player = target.GetComponent<Player>();

        if (player != null)
        {
            float xPosition = Mathf.Approximately(scenePosition.x, 0f) ? player.transform.position.x : scenePosition.x;

            float yPosition = Mathf.Approximately(scenePosition.y, 0f) ? player.transform.position.y : scenePosition.y;

            float zPosition = 0f;

            // Teleport to new scene
            SceneControllerManager.Instance.FadeAndLoadScene(sceneNameGoto.ToString(), new Vector3(xPosition, yPosition, zPosition));
        }
    }
}