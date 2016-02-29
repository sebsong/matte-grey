using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Lane {

	/* Keys in the lane */
	List<Transform> Keys { get; }

	/* Whether keys are typable in this lane */
	bool IsActive { get; }

	/* Speed of the keys in the lane */
	float Speed { get; }

	/* Adds KEY to the list of keys */
	void AddKey (GameObject key);

}
