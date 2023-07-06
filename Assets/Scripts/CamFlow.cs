using UnityEngine;

public class CamFlow : MonoBehaviour
{

    public void CamShiftLeft()
    { transform.position = new Vector3(transform.position.x - 19, transform.position.y, transform.position.z); }

    public void CamShiftRight()
    { transform.position = new Vector3(transform.position.x + 19, transform.position.y, transform.position.z); }

    public void CamShiftUp()
    { transform.position = new Vector3(transform.position.x, transform.position.y + 11, transform.position.z); }

    public void CamShiftDown()
    { transform.position = new Vector3(transform.position.x, transform.position.y - 11, transform.position.z); }
}
