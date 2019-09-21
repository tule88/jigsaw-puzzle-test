using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Script for picking puzzle pieces
public class PiecesControl : MonoBehaviour, IPointerDownHandler
{
    public Image zoneDetector;
    private Vector3 zoneDetectorStartPosition;
    private bool grabbed;
    private float timer;

    private float newAngle;
    private bool canRotate;
    Quaternion newRotation;

	void Start ()
    {
        zoneDetectorStartPosition = zoneDetector.transform.position;
        grabbed = false;
        timer = 0;
        canRotate = true;
        newAngle = -1;
    }
	
	void Update ()
    {
        if (grabbed) //if piece is grabbed: it follows mouse position, it's scaled up and it's above other pieces on the layer
        if (grabbed) //if piece is grabbed: it follows mouse position, it's scaled up and it's above other pieces on the layer
        {
            this.gameObject.transform.position = GameControl.instance.MousePosition();
            this.gameObject.transform.SetSiblingIndex(5);
            zoneDetector.transform.position = GameControl.instance.MousePosition();
            this.gameObject.GetComponent<RectTransform>().localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1.2f, 1.2f, 1),timer);
            Timer(1);
        }

        if (!canRotate) //rotate a piece on right click
        {
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, newRotation, timer);
            float x = Mathf.RoundToInt(this.gameObject.GetComponent<RectTransform>().eulerAngles.z);
            if (x == newAngle) canRotate = true;
            Timer(1);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameControl.instance.canPickPiece)
        {
            if (IsNotGrabbedAndMouseDown())
            {
                grabbed = true;
                GameControl.instance.grabbedPiece = this.gameObject.name;

            }
            else
            if (IsGrabbedAndMouseDown())
            {
                grabbed = false;
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
                ZoneDetector.instance.LockPiece(this.gameObject);
                zoneDetector.transform.position = zoneDetectorStartPosition;
                GameControl.instance.grabbedPiece = null;
            }
            else
            if (Input.GetMouseButtonDown(1))
            {
                if (canRotate)
                {
                    newAngle = (int)this.gameObject.GetComponent<RectTransform>().eulerAngles.z;
                    newAngle += 90;
                    if (newAngle == 360) newAngle = 0;
                    newRotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                    timer = 0;
                    canRotate = false;
                }
            }
        }        
    }

    private void Timer(float speed)
    {
        if (timer == 0 || timer < 1)
        {
            timer += 0.2f*speed;
        }
    }

    private bool IsNotGrabbedAndMouseDown()
    {
        return Input.GetMouseButtonDown(0) && GameControl.instance.grabbedPiece == null && grabbed == false;
    }

    private bool IsGrabbedAndMouseDown()
    {
        return Input.GetMouseButtonDown(0) && GameControl.instance.grabbedPiece != null && grabbed == true;
    }
}
