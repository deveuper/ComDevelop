----------------------------------------------
            FBX Exporter
 Copyright © 2011-2016 We.R.Play Pvt. Ltd.
            Version 1.0
      http://www.werplay.com
       unitysupport@werplay.com
----------------------------------------------

Thank you for buying FBX Exporter!

2 free demo scenes also included for testing

--------------------
 Using FBX Exporter
--------------------

1. Using menu bar
	a) Select objects(s) in the scene view
	b) Goto menu bar We.R.Play->FBX Exporter. A small window will appear
	c) Choose whether to include objects in hierarchy from the selection or not.
	d) Change path and fbx name, if needed
	e) Hit Export button

2. Through code
	Call the following function

	void FBXExporter.ExportFBX(string folderPathForFBX, string fbxName, Gameobject[] selectedObjects, bool addObjectsInHierarchy)
 