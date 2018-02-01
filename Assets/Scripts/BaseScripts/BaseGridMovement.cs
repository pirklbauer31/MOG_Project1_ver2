using System.Collections;
using UnityEngine;

public class BaseGridMovement : MonoBehaviour {

    /**
     * If true, the Object publishes it's position
     */
    public bool Publisher = false;
    private bool isMoving = false;
    /**
     * GridMove Instances of the same group doesn't notice each others movements
     */
    public string GroupName = "DEFAULT";

    private Vector3 previousPosition = new Vector3();

    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
        set
        {
            isMoving = value;
            if (!value && Publisher)
                if (!previousPosition.Equals(transform.position))
                    EventAggregator.SingletionAggregator.Publish(new MovementNotification() { Group = GroupName, Position = transform.position });
        }
    }

    public static float cellSize = 0.9f;
    public float WalkSpeed = 5.0f;
    public float TurnSpeed = 3.5f;
    private AudioSource walkingSound;

    // Use this for initialization
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();
    }

    public void movementLock(int state)
    {
        IsMoving = (state == 1);
    }

    public IEnumerator MoveForward()
    {
        IsMoving = true;
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0)
        {
            walkingSound.Play();
            for (float t = 0f; t < 1f; t += Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
            transform.position = newPos;
        }
        IsMoving = false;
    }

    public IEnumerator MoveBackward()
    {
        IsMoving = true;
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * -cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0)
        {
            walkingSound.Play();
            for (float t = 0f; t < 1f; t += Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
            transform.position = newPos;
        }
        IsMoving = false;
    }

    public IEnumerator RotateLeft()
    {
        IsMoving = true;
        var oldRotation = transform.rotation;
        transform.Rotate(0, -90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        transform.rotation = NewRotation;
        IsMoving = false;
    }

    public IEnumerator RotateRight()
    {
        IsMoving = true;
        var oldRotation = transform.rotation;
        transform.Rotate(0, 90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        transform.rotation = NewRotation;
        IsMoving = false;
    }
}
