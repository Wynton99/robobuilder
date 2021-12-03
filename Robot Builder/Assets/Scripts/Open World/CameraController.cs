using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float Distance = 10.0f; //distance of the camera from the player
    public float XSpeed = 60.0f; //speed of rotation about the x axis
    public float YSpeed = 130.0f; //speed of rotation about the y axis
    public float ScrollSpeed = 10;

    public float YMinLimit = -20.0f; //lower bound that the camera can rotate about the y axis
    public float YMaxLimit = 80.0f; //upper bound that the camera can rotate about the y axis

    public float DistanceMin = 5.0f; //minimum distance of the camera from the player
    public float DistanceMax = 30.0f; //maximum distance of the camera from the player

    private Rigidbody FixedRotation; //the object that the camera rotates around
    private bool colliding = false;

    float x = 0.0f; //x axis rotation
    float y = 0.0f; //y axis rotation

    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        FixedRotation = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (FixedRotation != null)
        {
            FixedRotation.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        //on collision enter, call repositionCamera()
        colliding = true;
    }

    void OnTriggerExit(Collider collider)
    {
        //on collision enter, call repositionCamera()
        colliding = false;
    }

    void LateUpdate()
    {
        //method is called by CamCollisionDetect script if camera collider is triggered
        //casts a ray to get the distance and calculate rotation and position for the camera
        if (target)
        {
            x += Input.GetAxis("Mouse X") * XSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * YSpeed * 0.02f;

            y = ClampAngle(y, YMinLimit, YMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Distance = Mathf.Clamp(Distance - Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed, DistanceMin, DistanceMax);
            float dst = Distance;

            //if the camera collides with an object in the map, raycast to calculate new camera distance
            if (colliding)
            {
                //print("camera colliding");
                //raycast to the character to prevent camera from intersecting with objects in map
                RaycastHit hit;
                if (Physics.Linecast(target.position, rotation * new Vector3(0f, 0f, -Distance) + target.position, out hit))
                {
                    dst = hit.distance;
                }
            }

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -dst);
            Vector3 position = rotation * negDistance + target.position;

            //update the camera's position and rotation
            transform.rotation = rotation;
            transform.position = position;
        }
    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
