using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool returnToZero = false; //default value is false  
    public GameObject PrefabToSpawn;
    public bool UseingMe;
	Vector3 prefabWorldPosition;
    public static int BondableAtomsTakenSoFar;
    public Button AdvanceTutorial;
    public GameObject TutorialArrow;  //used in the 9-molecule Guided practice scene
    public GameObject TutorialSpeechBubble;  //used in the 9-molecule Guided practice scene
    public GameObject MoleculeProductImageKeeper;  //used so that 3D molecule display will disappear when a new molecule is begun by dragging out an atom
    public Button AdvanceToNextMoleculeButton;

    void Start()
	{

	}

    public void OnDrag(PointerEventData eventData)
    {	
		transform.position = Input.mousePosition;        
		UseingMe = true;    		
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (returnToZero == true)
        {
            transform.localPosition = Vector3.zero;
            print("return to zero");
        }
        UseingMe = false;

        //if (ableToSpawn())  //checks for overlap between the newly spawned atom and prior atoms in scene
        //{
        //    InstantiateRealAtom();
        //}

        //else
        //{
        //    if (returnToZero == true)
        //    {
        //        transform.localPosition = Vector3.zero;
        //        print("return to zero");
        //    }
        //    UseingMe = false;

        //}
    }

    // Assess the need for instantiating a separate GameObject prior to utilizing this method 
    // and the ableToSpawn() method
    private void InstantiateRealAtom()
    {
        //print("InstantiateRealAtom");
        //print(ableToSpawn());

        if(AdvanceToNextMoleculeButton.interactable==true)  //can't drag out additional atoms when you have just finished a molecule!
        {
            transform.localPosition = Vector3.zero;
            UseingMe = false;
            return;
        }

        prefabWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        prefabWorldPosition.z = 0;
        GameObject Atom = Instantiate(PrefabToSpawn, prefabWorldPosition, Quaternion.identity);

        if (returnToZero == true)
        {
            transform.localPosition = Vector3.zero;
            //print("return to zero");
        }
        UseingMe = false;

    }


    

    //public bool ableToSpawn()
    //{
    //    PointerEventData pointer = new PointerEventData(EventSystem.current);
    //    pointer.position = Input.mousePosition;
    //    List<RaycastResult> raycastResults = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(pointer, raycastResults);
    //    if (raycastResults.Count > 0)
    //    {
    //        foreach (var go in raycastResults)
    //        {
    //            if (go.gameObject.transform.parent.gameObject.name == "RollPannelSingle" || go.gameObject.transform.parent.gameObject.name == "RollPannelDouble")
    //            {
    //                return false;
    //            }

                
    //        }
    //    }

    //    prefabWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    prefabWorldPosition.z = 0;
    //    GameObject dummyObject = Instantiate(PrefabToSpawn, prefabWorldPosition, Quaternion.identity);
    //    //print("instantiated dummyObject =" + dummyObject);
    //    //dummyObject.GetComponent<BondMaker>().CheckDummyObjectCollisions();

        
    //    int accuracy = 5; //1 is pixel perfect accuracy but causes stutter, 5 is a great performance but could allow minor overlap
    //    int range = Screen.height / 2;

    //    for (int x = (int)Input.mousePosition.x - range; x < (int)Input.mousePosition.x + range; x += accuracy)  //checks every 5 pixels to see if there is a "hit"
    //    {
    //        for (int y = (int)Input.mousePosition.y - range; y < (int)Input.mousePosition.y + range; y += accuracy)  //the scan covers the entire screen display, looking for double hits!
    //        {
    //            Vector2 RayCastPosition = new Vector2(x, y);
    //            //print(RayCastPosition);
                
    //            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenPointToRay(new Vector3(x, y, 0)).origin, Vector2.zero);
    //            //Debug.DrawRay(Camera.main.ScreenPointToRay(new Vector3(x, y, 0)).origin, transform.TransformDirection(Vector3.forward) * 100, Color.green, 10f, false);
    //            if (hits.Length > 1)
    //            {

    //                foreach (var go in hits)                        
    //                {                        
    //                    if (go.rigidbody.gameObject == dummyObject)  //this is now going to check to see if there is a second game object (go2) that is hit with the same ray!
    //                    {
    //                        foreach (var go2 in hits)
    //                        {                                
    //                            if (go2.rigidbody.gameObject != dummyObject && (go2.rigidbody.gameObject.GetComponent<DragIt>() != null || go2.rigidbody.gameObject.tag == "Diatomic"))
    //                            {
    //                                print("this game object prevented instantiation:" + go2.rigidbody);
    //                                Destroy(dummyObject);
    //                                Debug.DrawRay(Camera.main.ScreenPointToRay(new Vector3(x, y, 0)).origin, transform.TransformDirection(Vector3.forward) * 100, Color.green, 10f, false);
    //                                GameObject.Find("ConversationDisplay").GetComponent<ConversationDisplayFor2DModels>().DontStackAtoms();
    //                                return false;  //there was an overlapping atom, so don't instantiate the new atom
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    Destroy(dummyObject);
    //    //print("not destroying the dummy!");
    //    return true;
    //}
}