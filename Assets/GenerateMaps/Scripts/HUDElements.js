var player : GameObject;

var bgBar : Texture2D;
var healthBar : Texture2D;
var expBar : Texture2D;

var healthBarX : int = 10;
var healthBarY : int = 10;
var healthBarWidth : int = 200;
var healthBarHeight : int = 20;

var expBarX : int = 10;
var expBarY : int = 40;
var expBarWidth : int = 200;
var expBarHeight : int = 20;

private var healthBarPercent : float = 100.0;
private var expBarPercent : float = 100.0;


function Start () {
	
}

function Update () {
	healthBarPercent = player.GetComponent("PlayerStats").GetCurHealth() / player.GetComponent("PlayerStats").GetMaxHealth();
	expBarPercent = player.GetComponent("PlayerStats").GetCurExp() / player.GetComponent("PlayerStats").GetMaxExp();
	
	
}

function OnGUI () {
	GUI.DrawTexture(Rect(healthBarX, healthBarY, healthBarWidth, healthBarHeight), bgBar);
	GUI.DrawTexture(Rect(expBarX, expBarY, expBarWidth, expBarHeight), bgBar);
	if (player.GetComponent("PlayerStats").GetCurHealth() > 0) {
		GUI.DrawTexture(Rect(healthBarX, healthBarY, healthBarWidth * healthBarPercent, healthBarHeight), healthBar);
	}
	
	if (player.GetComponent("PlayerStats").GetCurExp() > 0) {
		GUI.DrawTexture(Rect(expBarX, expBarY, expBarWidth * expBarPercent, expBarHeight), expBar);
	}
}