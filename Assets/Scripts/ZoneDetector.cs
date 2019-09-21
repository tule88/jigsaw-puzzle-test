using System.Collections;
using UnityEngine;
//Script detects collision with other triggers
public class ZoneDetector : MonoBehaviour
{
    public static ZoneDetector instance;

    public GameObject PlacedPiecesHolder;
    private string zoneName;

    private void Awake()
    {
        instance = this;
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
         zoneName = collision.name;
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         zoneName = "";
     }

    public void LockPiece(GameObject piece)  // If piece is on correct trigger space and at the right angle, on click it will be "locked"
    {
        if(piece.name == "PlacedImage_1" && zoneName == "Trigger_1" && piece.transform.localEulerAngles.z==0)
        {
            PlacedPiecesHolder.transform.GetChild(0).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;        
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }else
            if (piece.name == "PlacedImage_2" && zoneName == "Trigger_2" && piece.transform.localEulerAngles.z == 0)
        {
            PlacedPiecesHolder.transform.GetChild(1).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }
        else
            if (piece.name == "PlacedImage_3" && zoneName == "Trigger_3" && piece.transform.localEulerAngles.z == 0)
        {
            PlacedPiecesHolder.transform.GetChild(2).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }
        else
            if (piece.name == "PlacedImage_4" && zoneName == "Trigger_4" && piece.transform.localEulerAngles.z == 0)
        {
            PlacedPiecesHolder.transform.GetChild(3).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }
        else
            if (piece.name == "PlacedImage_5" && zoneName == "Trigger_5" && piece.transform.localEulerAngles.z == 0)
        {
            PlacedPiecesHolder.transform.GetChild(4).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }
        else
            if (piece.name == "PlacedImage_6" && zoneName == "Trigger_6" && piece.transform.localEulerAngles.z == 0)
        {
            PlacedPiecesHolder.transform.GetChild(5).gameObject.SetActive(true);
            piece.SetActive(false);
            GameControl.instance.numberOfCorrectlyPlaced++;
            if (GameControl.instance.numberOfCorrectlyPlaced == 6)
            {
                ActivateParticle();
            }
        }
    }

    IEnumerator ActivateComletedImage()  //play animation of completed puzzle image
    {
        yield return new WaitForSeconds(1);
        GameControl.instance.completedImage.gameObject.SetActive(true);
        GameControl.instance.completedImage.GetComponent<Animation>().Play();
    }

    private void ActivateParticle() //play ending particle if all pieces are in correct place
    {
        GameControl.instance.particle1.Play();
        GameControl.instance.particle2.Play();
        GameControl.instance.particle3.Play();
        GameControl.instance.particle4.Play();
        GameControl.instance.particle5.Play();
        GameControl.instance.particle6.Play();

        StartCoroutine("ActivateComletedImage");
    }
}
