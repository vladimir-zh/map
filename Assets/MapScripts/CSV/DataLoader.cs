using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour {
	public Text CountryText;

	string russia, china, mongolia, japan;
	string [] countryArray;

	
	List<Quests> quests = new List<Quests>();

	// Use this for initialization
	void Start () {
		TextAsset DataCountries = Resources.Load<TextAsset> ("DataCountries");
		countryArray = new string[]{"1", "2", "3", "4", "5"};
		string[] data = DataCountries.text.Split (new char[]{ '\n' });

		//Debug.Log (data.Length);

		for (int i = 1; i < data.Length - 1; i++) {
			string[] row = data [i].Split (new char[] { ';' });

			Quests q = new Quests ();
			int.TryParse (row [0], out q.id);

			q.country = row [1];
			countryArray[i] = q.country.ToString ();

			russia = countryArray [1];
			china = countryArray [2];
			mongolia = countryArray [3];
			japan = countryArray [4];

			q.government = row [2];
			int.TryParse (row [3], out q.population);

			quests.Add (q);
		}

		foreach (Quests q in quests) {
			Debug.Log (q.country);
		}
	}
		
	void Update () {
		
	}

	public void RussiaChange(){
		CountryText.text = russia;
	}
	public void ChinaChange(){
		CountryText.text = china;
	}
	public void MongoliaChange(){
		CountryText.text = mongolia;
	}
	public void JapanChange(){
		CountryText.text = japan;
	}
}
