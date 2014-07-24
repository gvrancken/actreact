using UnityEngine;
using System.Collections;

public class RuleBook : Singleton<RuleBook> {

	protected RuleBook() {} // further ensures singleton for constructor does nothing

	public bool usesKeys = false;
	public int numRestartClicked = 0;

}
