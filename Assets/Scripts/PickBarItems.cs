using UnityEngine;
using UnityEngine.EventSystems;
//Script for picking Set Pieces from lower bar
public class PickBarItems : MonoBehaviour, IPointerDownHandler
{
    public GameObject notPlacedPiecesHolder;
    public Transform removedSets;
    private bool grabbed;

    void Start()
    {
        grabbed = false;
    }

    void Update()
    {
        if (grabbed)
        {
            this.gameObject.transform.position = GameControl.instance.MousePosition();
            if (Input.GetMouseButtonDown(0) && GameControl.instance.canDrop)
            {
                if (GameControl.instance.grabbedSet == "ItemSet_1")
                {
                    notPlacedPiecesHolder.transform.GetChild(0).gameObject.SetActive(true);
                    notPlacedPiecesHolder.transform.GetChild(1).gameObject.SetActive(true);
                    ReplaceImages();
                }
                else if (GameControl.instance.grabbedSet == "ItemSet_2")
                {
                    notPlacedPiecesHolder.transform.GetChild(2).gameObject.SetActive(true);
                    notPlacedPiecesHolder.transform.GetChild(3).gameObject.SetActive(true);
                    ReplaceImages();
                }
                else if (GameControl.instance.grabbedSet == "ItemSet_3")
                {
                    notPlacedPiecesHolder.transform.GetChild(4).gameObject.SetActive(true);
                    notPlacedPiecesHolder.transform.GetChild(5).gameObject.SetActive(true);
                    ReplaceImages();
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameControl.instance.canPickSet==false)
        {
            this.gameObject.transform.SetParent(removedSets);
            GameControl.instance.grabbedSet = this.gameObject.name;
            GameControl.instance.canPickSet = true;
            grabbed = true;
        }
    }

    private void ReplaceImages()
    {
        GameControl.instance.canPickSet = false;
        grabbed = false;
        GameControl.instance.grabbedSet = null;
        GameControl.instance.numberOfSpawnedPairs++;
        if (GameControl.instance.numberOfSpawnedPairs == 3)
        {
            StartCoroutine(GameControl.instance.AllowPicking());
        }
        this.gameObject.SetActive(false);
    }
}
