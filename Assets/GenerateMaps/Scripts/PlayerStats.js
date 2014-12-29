static var curHealth : float = 100;
static var maxHealth : float = 100;

static var curExp : float = 0;
static var maxExp : float = 100;
static var level : int = 1;

static var intellect : int = 0;

function Start () {
	
}

function Update () {
	if (curHealth <= 0) {
		curHealth = 0;
		Death();
	}
	if (curExp >= maxExp) {
		level++;
		curExp = 0;
		maxExp += maxExp/10 - level*intellect;
	}
	
	// For testing
	if(Input.GetKeyDown("h")) {
		curHealth -= 1;
	}
	if(Input.GetKeyDown("j")) {
		curExp += 1;
	}
}

function Death () {

}

function GetCurHealth() {
	return curHealth;
}

function GetMaxHealth() {
	return maxHealth;
}

function GetCurExp() {
	return curExp;
}

function GetMaxExp() {
	return maxExp;
}