using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryChanged : MonoBehaviour {

	public Text populationTXT;
	public Text CountryText;
	public Text governmentTXT;

//	public PanelManager menuPanel;

	string russia, china, mongolia, japan, russiaG, chinaG, mongoliaG, japanG;
	string [] countryArray;
	int [] population;
	string [] governmentArray;

	public Color color;
	public Material[] material;

	Renderer render;
	List<Quests> quests = new List<Quests>();

	void Start () {
		render = GetComponent<Renderer> ();
		render.enabled = true;
		render.sharedMaterial = material [0];
		TextAsset DataCountries = Resources.Load<TextAsset> ("DataCountries");
		countryArray = new string[5];/*{"1", "2", "3", "4", "5"};*/
		governmentArray = new string[5];/*{"1", "2", "3", "4", "5"};*/
		population = new int[5];

		string[] data = DataCountries.text.Split (new char[]{ '\n' });

		for (int i = 1; i < data.Length - 1; i++) { //парсинг данных из файла
			string[] row = data [i].Split (new char[] { ';' }); //разделение по знаку ";"

			Quests q = new Quests ();
			int.TryParse (row [0], out q.id);

			q.country = row [1];
			countryArray[i] = q.country.ToString ();

			russia = countryArray [1];
			china = countryArray [2];
			mongolia = countryArray [3];
			japan = countryArray [4];

			q.government = row [2];
			governmentArray [i] = q.government.ToString ();

			russiaG = governmentArray [1];
			chinaG = governmentArray [2];
			mongoliaG = governmentArray [3];
			japanG = governmentArray [4];

			int.TryParse (row [3], out q.population);
			population [i] = q.population;

			quests.Add (q);
		}

		foreach (Quests q in quests) {
			Debug.Log (q.country);
		}

	}
	void Update(){
//		menuPanel = new PanelManager ();
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1));
			RaycastHit _hit;
			if(Physics.Raycast(ray, out _hit, Mathf.Infinity)){
//				menuPanel.AnimPlay ();
				if(_hit.transform.tag == "russia"){
			RussiaChange ();
			}
				if(_hit.transform.tag == "china"){
					Debug.Log ("ChangedChinaTeg");
					ChinaChange ();
				}

				if(_hit.transform.tag == "mongolia"){
					Debug.Log ("ChangedMongoliaTeg");
					MongoliaChange ();
				}
		}
	}
}

	public void RussiaChange(){
		CountryText.text = russia;
		populationTXT.text = population [1].ToString() + " человек";
		governmentTXT.text = russiaG;
	}
	public void ChinaChange(){
		CountryText.text = china;
		populationTXT.text = population [2].ToString () + " человек";
		governmentTXT.text = chinaG;
	}
	public void MongoliaChange(){
		CountryText.text = mongolia;
		populationTXT.text = population [3].ToString () + " человек";
		governmentTXT.text = mongoliaG;
	}
	public void JapanChange(){
		CountryText.text = japan;
	}

	void OnMouseEnter()
	{
		
			render.sharedMaterial = material [1];

	}
	void OnMouseExit()
	{
		render.sharedMaterial = material [0];
	}
}
