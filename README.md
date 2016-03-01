# Thief

[Unity doc](http://docs.unity3d.com/Manual/index.html)


###Grid/Node System
1. Realtime, not turn-based
2. x-y corrdinate. (0,0) starts at top left
2. Each node has 4 `bool`(C#): `isNorthWalkable`, `isSouthWalkable`, `isWestWalkable`, `isEastWalkable`
3. Every node has the same, fixed size(aka `private`)
4. TBD spacing

###Input / Movement
1. Swipe up/down/left/right with 1 finger = move up/down/left/right by 1 node
2. Swipe up/down/left/right with 2 fingers = move continuously until stop by `Collider`
3. 1 finger overrides 2 fingers' movement

###Powerups
1. Speed
2. Freeze
3. Lock picker
4. Cell phone
5. Tranquilizer gun
