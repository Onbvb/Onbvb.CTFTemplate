## This is a basic example of a CTF system.

CTF Systems have a couple required objects:

Two Nomai Scroll Walls, each named "Red Base" and "Blue Base" respectively.\n
Two Nomai Scrolls childed to those walls, named "Red/Blue Flag".\n
Signals childed to all of the above. (the base mod will kill you if you dont.)\n
A portion in the system 'extras' property,
```
    "extras": {
        "CTFInfo" : {
            "isCaptureTheFlagSystem" : true
        }
    }
```
And whatever is in the CS file dont touch that.
