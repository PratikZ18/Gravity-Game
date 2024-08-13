
using UnityEngine;

public class MirrorCamMove : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public Vector3 angleOffset = new Vector3(0f,0f,0f);
    private Transform thisCam;
    private Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        thisCam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        angles.y = -player.eulerAngles.y +angleOffset.y;
        angles.x = playerCam.localEulerAngles.x + angleOffset.x;
        angles.z = angleOffset.z;
        thisCam.localEulerAngles = angles;
    }
}
