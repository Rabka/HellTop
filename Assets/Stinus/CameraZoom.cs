using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float smoothTime = 0.5f;
    public Transform ThisCameraTransform;
    public List<Transform> Players;

    private Vector3 smoothVelocity;

    public Camera ThisCamera;
    public float Border = 1.0f;
    public float MaxZoom = 3.0f;
    public float MinZoom = 10.0f;
    public float ZoomLerp = 10.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
        Move();
	    Zoom();
	}

    void Zoom()
    {
        if (Players.Count < 2)
            return;

        float newZoom = Mathf.Lerp(MaxZoom, MinZoom, (GetGreatesDistance() + Border) / ZoomLerp);

        ThisCamera.orthographicSize = Mathf.Lerp(ThisCamera.orthographicSize, newZoom, Time.deltaTime);
    }

    void Move()
    {
        if (Players.Count == 0)
            return;

        Vector3 NewPosition = GetCenterPoint();

        NewPosition.z = -10.0f;

        ThisCameraTransform.position = Vector3.SmoothDamp(ThisCameraTransform.position, NewPosition, ref smoothVelocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (Players.Count == 1)
        {
            return Players[0].position;
        }

        var bounds = new Bounds(Players[0].position, Vector3.zero);
        foreach (var t in Players)
        {
            bounds.Encapsulate(t.position);
        }

        return bounds.center;
    }

    float GetGreatesDistance()
    {
        var bounds = new Bounds(Players[0].position, Vector3.zero);
        foreach (var t in Players)
        {
            bounds.Encapsulate(t.position);
        }

        return Mathf.Max(bounds.size.x, bounds.size.y);
    }
}
