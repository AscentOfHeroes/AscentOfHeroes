using UnityEngine;
using System.Collections;

public class HUDElements : MonoBehaviour {
	
	public GameObject hpBar;
	public GameObject expBar;

	private PlayerStats stats;

	private float hpBarMaxWidth;
	private float expBarMaxWidth;

	private float hpBarPercent;
	private float expBarPercent;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats>();
		hpBarMaxWidth = ((RectTransform)hpBar.transform).rect.width;
		expBarMaxWidth = ((RectTransform)expBar.transform).rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		hpBarPercent = (float)stats.GetCurHp() / (float)stats.GetMaxHp();
		expBarPercent = (float)stats.GetCurExp() / (float)stats.GetMaxExp();

		// Determine length of HP bar
		Vector2 hpBarSizeDelta = hpBar.GetComponent<RectTransform>().sizeDelta;
		hpBarSizeDelta = new Vector2(hpBarPercent * hpBarMaxWidth, hpBarSizeDelta.y);
		hpBar.GetComponent<RectTransform>().sizeDelta = hpBarSizeDelta;

		// Determine length of EXP bar
		Vector2 expBarSizeDelta = expBar.GetComponent<RectTransform>().sizeDelta;
		expBarSizeDelta = new Vector2(expBarPercent * expBarMaxWidth, expBarSizeDelta.y);
		expBar.GetComponent<RectTransform>().sizeDelta = expBarSizeDelta;
	}
}
