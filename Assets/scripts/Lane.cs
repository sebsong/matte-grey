using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public interface Lane {

	/* Keys in the lane */
	List<GameObject> Keys { get; set; }

	/* Whether keys are typable in this lane */
	bool IsActive { get; set; }

	/* Speed of the keys in the lane */
	float Speed { get; set; }

	/* Adds KEY to the list of keys */
	void AddKey (GameObject key, string text);

	/* Checks if the input matches the first key text, if so, cast key spell, else, do nothing */
	void CheckKey (string input);

}
