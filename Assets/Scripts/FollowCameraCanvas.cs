using UnityEngine;

public class FollowCameraCanvas : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y, -5f);
    }
    private void OnEnable()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -5f);
    }
}
