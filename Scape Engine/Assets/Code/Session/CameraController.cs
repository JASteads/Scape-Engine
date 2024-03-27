using UnityEngine;

public class CameraController : MonoBehaviour
{
    readonly float moveSpeed = 0.5f,
                   rotationAmp = 2f,
                   sqrt2 = Mathf.Sqrt(2),
                   halfSqrt2 = 0.7071f,
                   speedAmp = 2;
    readonly int   maxAngle = 90, minAngle = 5;

    public Camera cam;
    Transform tf;
    Vector3 mousePos, mouseDelta;

    void Start()
    {
        tf = cam.transform;
    }
    void Update()
    {
        Vector3 newPos = Vector3.zero;

        mouseDelta = mousePos - Input.mousePosition;
        mousePos = Input.mousePosition;

        newPos.y += Input.GetAxis("Mouse ScrollWheel");
        tf.Translate(newPos, Space.Self);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 newRot = Vector3.Scale(
                new Vector3(1, 1, 0),
                new Vector3(mouseDelta.y, mouseDelta.x, 0));
            Vector3 result = ClampRotation(Vector3.Scale(
                new Vector3(1, 1, 0),
                tf.localEulerAngles + newRot));

            tf.localEulerAngles = result;
        }
    }
    void FixedUpdate()
    {
        float speed = moveSpeed;

        Vector3 newPos = Vector3.zero,
                newRot = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.RightShift))
            speed *= speedAmp;

        if (Input.GetKey(KeyCode.W))
        {
            newPos.z += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.z -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed;
        }
        newPos.y += Input.GetAxis("Mouse ScrollWheel");


        if (Input.GetKey(KeyCode.UpArrow))
        {
            newRot.x += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newRot.x -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newRot.y += speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newRot.y -= speed;
        }

        newRot *= rotationAmp;

        if (newPos.magnitude == speed * sqrt2)
            speed *= halfSqrt2;

        // Restrict vertical movement by translating the camera as
        // if facing forward, then rotate the camera.
        Vector3 finalRotation = ClampRotation(
            tf.localEulerAngles + newRot);

        Vector3 realRotation = finalRotation,
                fakeRotation = Vector3.Scale(
                    new Vector3(0, 1, 1), finalRotation);

        tf.localEulerAngles = fakeRotation;
        tf.Translate(newPos, Space.Self);
        tf.localEulerAngles = realRotation;
    }

    // Clamps the rotation between max and min angles
    Vector3 ClampRotation(Vector3 rotation)
    {
        if (rotation.x > maxAngle)
            rotation = new Vector3(maxAngle, rotation.y, 0);
        else if (rotation.x < minAngle)
            rotation = new Vector3(minAngle, rotation.y, 0);

        return rotation;
    }
}
