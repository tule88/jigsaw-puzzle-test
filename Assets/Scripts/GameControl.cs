using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//Script for input limitations
public class GameControl : MonoBehaviour {

    public static GameControl instance;

    public GameObject barSetHolder;
    public GameObject notPlacedPieces;
    public Camera cam;
    public Image completedImage;

    public string grabbedSet;
    public string grabbedPiece;
    public bool canPickPiece;
    public bool canPickSet;
    public bool canDrop;
    public int numberOfSpawnedPairs;
    public int numberOfCorrectlyPlaced;

    private Animation anim;
    [Space]
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public ParticleSystem particle5;
    public ParticleSystem particle6;
    public ParticleSystem globalParticle;

    private void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        completedImage.gameObject.SetActive(false);
        numberOfCorrectlyPlaced = 0;
        numberOfSpawnedPairs = 0;
        grabbedSet = null;
        grabbedPiece = null;
        canDrop = false;
        canPickPiece = false;
        canPickSet = false;
        anim = notPlacedPieces.GetComponent<Animation>();
        //
        particle1.Stop();
        particle2.Stop();
        particle3.Stop();
        particle4.Stop();
        particle5.Stop();
        particle6.Stop();
	}
	
	void Update ()
    {

    }

    public void canDropExit() //if mouse pointer is out of lower bar zone, set piece can be dropped
    {
        canDrop = true;
    }

    public void canDropEnter()
    {
        canDrop = false;
    }

    public Vector3 MousePosition()  //convert Input.mousePosition for canvas with Screen Space - Camera render mode
    {
        Vector3 position = Input.mousePosition;
        position.z = 10;
        return cam.ScreenToWorldPoint(position);
    }

    public IEnumerator AllowPicking()  //play animation after all set pieces are on table
    {
        anim.Play();
        barSetHolder.GetComponent<RectTransform>().localScale = Vector3.zero;
        yield return new WaitForSeconds(1.5f);
        canPickPiece = true;
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
