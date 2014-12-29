using UnityEngine;
using System.Collections;

public class HUDElements : MonoBehaviour {
	
	public Texture2D bgBarTex;
	public Texture2D hpBarTex;
	public Texture2D expBarTex;

	private PlayerStats stats;

	private const float HP_BAR_X = 10;
	private const float HP_BAR_Y = 10;
	private float HP_BAR_WIDTH = 200; // Not a const because HP bar can become longer if player levels up
	private const float HP_BAR_HEIGHT = 20;

	private const float EXP_BAR_X = 10;
	private const float EXP_BAR_Y = 40;
	private const float EXP_BAR_WIDTH = 200;
	private const float EXP_BAR_HEIGHT = 20;

	private double hpBarPercent = 100.0;
	private double expBarPercent = 100.0;

	// Use this for initialization
	void Start () {
		stats = this.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		hpBarPercent = (float)stats.GetCurHp() / (float)stats.GetMaxHp();
		expBarPercent = (float)stats.GetCurExp() / (float)stats.GetMaxExp();
	}

	void OnGUI () {
		GUI.DrawTexture(new Rect(HP_BAR_X, HP_BAR_Y, HP_BAR_WIDTH, HP_BAR_HEIGHT), bgBarTex);
		GUI.DrawTexture(new Rect(EXP_BAR_X, EXP_BAR_Y, EXP_BAR_WIDTH, EXP_BAR_HEIGHT), bgBarTex);
		if (stats.GetCurHp() > 0) {
			GUI.DrawTexture(new Rect(HP_BAR_X, HP_BAR_Y, HP_BAR_WIDTH * (float)hpBarPercent, HP_BAR_HEIGHT), hpBarTex);
		}
		
		if (stats.GetCurExp() > 0) {
			GUI.DrawTexture(new Rect(EXP_BAR_X, EXP_BAR_Y, EXP_BAR_WIDTH * (float)expBarPercent, EXP_BAR_HEIGHT), expBarTex);
		}
	}
}
