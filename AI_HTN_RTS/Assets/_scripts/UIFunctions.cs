using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour {

    public Button CGoldButton;
    public Button CRockButton;
    public Button CWoodButton;

    public Button BuildHutButton;
    public Button BuildFactoryButton;

    public Text gold;
    public Text rock;
    public Text wood;

	// Use this for initialization
	void Start () {
        Button CGButton = CGoldButton.GetComponent<Button>();
        CGButton.onClick.AddListener(CollectGold);

        Button CRButton = CRockButton.GetComponent<Button>();
        CGButton.onClick.AddListener(CollectRock);

        Button CWButton = CWoodButton.GetComponent<Button>();
        CGButton.onClick.AddListener(CollectWood);

        Button BHutButton = BuildHutButton.GetComponent<Button>();
        CGButton.onClick.AddListener(BuildHut);

        Button BFactoryButton = BuildFactoryButton.GetComponent<Button>();
        CGButton.onClick.AddListener(BuildFactory);


    }

    void CollectGold()
    {
        
    }

    void CollectRock()
    {
        
    }

    void CollectWood()
    {
        
    }

    void BuildHut()
    {
       
    }

    void BuildFactory()
    {
        
    }



    // Update is called once per frame
    void Update () {
		
	}
}
