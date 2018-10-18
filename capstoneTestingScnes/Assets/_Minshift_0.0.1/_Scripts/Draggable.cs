using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public GameObject thisObject;
    public Transform TheCardDescription;
    public string thisObjectString;
    public GameObject villain;
    public GameObject hero;
	public Transform findingTheImageObject;
    public Sprite[] findTheCardBackground;
    //public Image
    GameObject placeholder = null;
    public Text cardName;
    public Color cardColor;
    public Image m_SpriteRenderer;
    public GameObject theNameOFhisObject;
    public AudioSource music;
    public Sprite[] facesOfEmotion;
    public Sprite[] cardbody;
	//public Image m_SpriteRenderer2;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
	/// 
    /// </summary>

    
    void Awake()
    {
        villain = GameObject.FindGameObjectWithTag("Villain");
        hero = GameObject.FindGameObjectWithTag("Hero");
        music = GameObject.FindGameObjectWithTag("soundOfWar").GetComponent<AudioSource>();
    }


    void Start()
    {
        Time.timeScale = 1;
        thisObject = this.gameObject;
        thisObjectString = thisObject.name.ToString();
        TheCardDescription = thisObject.transform.Find( thisObjectString + "/Card Description");
    }


    void Update()
    {
        //cardName = GetComponentInChildren<Text>();
		m_SpriteRenderer = GetComponentInChildren<Image>();
		findingTheImageObject = transform.Find("Image");
        //findTheCardBackground = GetComponent<Image>();


       
        switch (this.gameObject.GetComponent<cardClass>().CardType)
        {
            case cardEnum.AGRESSIVE:
                Debug.Log("agressive");
                //cardName.GetComponent<Text>().text = "Agressive";
				//m_SpriteRenderer.color = Color.red;
                m_SpriteRenderer.sprite = cardbody[0];
				//findingTheImageObject.GetComponent<Image>().color = Color.green;
                findingTheImageObject.GetComponent<Image>().sprite = facesOfEmotion[0];
             

                break;
            case cardEnum.KIND:
                Debug.Log("kind");
                //cardName.GetComponent<Text>().text = "kind";
				//m_SpriteRenderer.color = Color.blue;
                m_SpriteRenderer.sprite = cardbody[1];
                //findingTheImageObject.GetComponent<Image>().color = Color.cyan;
                findingTheImageObject.GetComponent<Image>().sprite = facesOfEmotion[1];
                break;
            case cardEnum.WITHDRAWN:
                Debug.Log("withdrawn");
                //cardName.GetComponent<Text>().text = "withdrawn";
				//m_SpriteRenderer.color = Color.yellow;
                m_SpriteRenderer.sprite = cardbody[2];
                //findingTheImageObject.GetComponent<Image>().color = Color.white;
                findingTheImageObject.GetComponent<Image>().sprite = facesOfEmotion[2];
                break;
            default:
                break;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        music.clip = music.GetComponent<audioPocket>().SoundsOfWar[0];
        music.Play();
    }

    /// <summary>
    /// OnDrag is supposed to handle how to do on the point where you drag
	/// things into it
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {


        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }


 /// <summary>
    /// this is called to handle what happens when the player finishes the drag
	/// is it destroyed and how?
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        music.Stop();
        if (parentToReturnTo.name == "Hand")
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
        }
        else
        {
            switch (this.gameObject.GetComponent<cardClass>().CardType)
            {
                case cardEnum.AGRESSIVE:
                    Debug.Log("agressive");

                    hero.GetComponent<Heroes>().heroAttacks();
                    //music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
                    //music.Play();
                    break;
                case cardEnum.KIND:
                    Debug.Log("kind");
                    hero.GetComponent<Heroes>().heroBlue();
                    //music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
                    //music.Play();
                    break;
                case cardEnum.WITHDRAWN:
                    Debug.Log("withdrawn");
                    hero.GetComponent<Heroes>().heroYellow();
                    //music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
                    //music.Play();
                    break;
                default:
                    break;
            }

            Destroy(this.gameObject);
        }

    }



}
