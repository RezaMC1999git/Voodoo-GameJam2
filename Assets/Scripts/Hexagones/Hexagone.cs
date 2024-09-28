using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hexagone : MonoBehaviour
{
    public bool hexActivated = false;
    public bool isWhiteHexShown = false;
    public bool showBackSide = false;
    public float showBacSideSpeed = 4f;
    public Vector3 OtherPortal;

    private bool doHexBehaviourOnce = true;
    private bool findWhiteHexOnce = true;
    private bool makeRandomNumberOnce = true;
    private bool goToCoroutineOnce = true;
    private bool improvePosOnce = true;
    [SerializeField] private bool orangeHexActive = false;
    [SerializeField] private bool orangeHexDeActive = false;
    private int randIndex;
    private GameObject countDownText;
    private GameObject ball;
    private Hexagones_GameController gameController;
    private List<GameObject> surrendedHexs = new List<GameObject>();

    private void Start()
    {
        gameController = FindObjectOfType<Hexagones_GameController>();
        ball = FindObjectOfType<HexaGon_Ball>().gameObject;
        ChangeBackColor();
        SetBehaviour();
    }

    private void Update()
    {
        if (showBackSide)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-180f, 0f, 0f),
                showBacSideSpeed * Time.deltaTime);
            if (gameObject.tag == "WhiteHex" && findWhiteHexOnce)
            {
                gameController.WhiteHexagonFounded();
                isWhiteHexShown = true;
                findWhiteHexOnce = false;
            }

            if (doHexBehaviourOnce)
            {
                DoBehaviour();
                doHexBehaviourOnce = false;
            }
        }
        if (orangeHexActive)
        {
            if (makeRandomNumberOnce)
            {
                randIndex = Random.Range(0, gameController.whiteHexs.Length);
                if(gameController.whiteHexs[randIndex].GetComponent<Hexagone>().isWhiteHexShown)
                    randIndex = FindAnotherWhiteHex();
                makeRandomNumberOnce = false;
            }
            gameController.whiteHexs[randIndex].transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-180f, 0f, 0f),
                    showBacSideSpeed * Time.deltaTime);
            if (goToCoroutineOnce)
            {
                StartCoroutine(ShowHint());
                goToCoroutineOnce = false;
            }
        }

        if (orangeHexDeActive)
        {
            GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(gameController.yellowMaterial);
            gameController.whiteHexs[randIndex].transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-360f, 0f, 0f),
                    showBacSideSpeed * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-360f, 0f, 0f),
                    showBacSideSpeed * Time.deltaTime);
            Vector3 improvedPos = transform.position;
            if (improvePosOnce)
            {
                improvedPos.y = improvedPos.y - 0.25f;
                improvePosOnce = false;
            }
            transform.position = improvedPos;
        }
        /*if (hexActivated)
        {
            showBackSide = true;
            foreach (GameObject hex in surrendedHexs)
            {
                hex.GetComponent<Hexagone>().showBackSide = true;
            }
        }*/
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 12f, 0f);
            if(gameObject.tag != "LockedHex")
                showBackSide = true;
        }

        if (gameObject.CompareTag("OrangeHex") && showBackSide)
        {
            orangeHexActive = true;
        }

        if (gameObject.tag == "BlueHex" && showBackSide)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 8f, 0f);
            StartCoroutine(Test());
            //Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position
            //    , OtherPortal, showBacSideSpeed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "YellowHex" || obj.tag == "WhiteHex" || obj.tag == "RedHex" ||
            obj.tag == "BlueHex" || obj.tag == "OrangeHex" || obj.tag == "Hexagone")
        {
            AddToSurundedList(obj);
        }

    }
    void AddToSurundedList(GameObject obj)
    {
        bool canAdd = true;
        for(int i = 0; i < surrendedHexs.Count; i++)
        {
            if (obj == surrendedHexs[i].gameObject)
                canAdd = false;
        }
        if (canAdd)
            surrendedHexs.Add(obj);
    }
    void ChangeBackColor()
    {
        switch (gameObject.tag)
        {
            case "WhiteHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.whiteMaterial);
                break;
            case "RedHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.redMaterial);
                break;
            case "BlueHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.blueMaterial);
                break;
            case "YellowHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.yellowMaterial);
                break;
            case "OrangeHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.orangeMaterial);
                break;
        } 
    }

    void SetBehaviour()
    {
        switch (gameObject.tag)
        {
            case "RedHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.redMaterial);
                Vector3 newPos = new Vector3(transform.position.x - 2.8f, transform.position.y - 0.9f, transform.position.z + 7.3f);
                countDownText = Instantiate(gameController.redHexagonBombCountDown,
                    newPos, Quaternion.Euler(-90f,-180f,90f)).gameObject;
                countDownText.transform.parent = gameObject.transform;
                break;
            case "BlueHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.blueMaterial);
                break;
            case "OrangeHex":
                GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(gameController.orangeMaterial);
                break;
        }
    }

    void DoBehaviour()
    {
        switch (gameObject.tag)
        {
            case "RedHex":
                StartCoroutine(BombActivated());
                break;
            case "BlueHex":
                //StartCoroutine(PortalActivated());
                break;
        }
    }
    
    IEnumerator BombActivated()
    {
        yield return new WaitForSeconds(1f);
        countDownText.GetComponent<TextMeshPro>().text = "4";
        yield return new WaitForSeconds(1f);
        countDownText.GetComponent<TextMeshPro>().text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.GetComponent<TextMeshPro>().text = "2";
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Bomb";
        countDownText.GetComponent<TextMeshPro>().text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.SetActive(false);
        Vector3 dir = transform.position - ball.transform.position;
        dir = -dir.normalized;
        if(Mathf.Abs(dir.y) > 0.5f)
        {
            ball.GetComponent<Rigidbody>().velocity = dir * 2f;
            OtherPortal -= dir;
        }

        yield return new WaitForSeconds(0.5f);
        gameObject.tag = "RedHex";
        Destroy(gameObject);
    }

    IEnumerator PortalActivated()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<MeshCollider>().isTrigger = true;
    }

    IEnumerator ShowHint()
    {
        gameObject.tag = "LockedHex";
        yield return new WaitForSeconds(4f);
        orangeHexActive = false;
        orangeHexDeActive = true;
        showBackSide = false;
        yield return new WaitForSeconds(2f);
        //showBackSide = true;
        orangeHexDeActive = false;
    }

    int FindAnotherWhiteHex()
    {
        int indexToReturn = 0;
        for(int i = 0;i< gameController.whiteHexs.Length; i++)
        {
            int newRand = Random.Range(0, gameController.whiteHexs.Length);
            if (!gameController.whiteHexs[newRand].GetComponent<Hexagone>().isWhiteHexShown)
                indexToReturn = newRand;
            else
            {
                i = 0;
            }
        }
        return indexToReturn;
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.05f);
        Camera.main.transform.position = OtherPortal;
    }
}
