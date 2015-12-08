PURPOSE

Create zones on the map that, upon entering, will make the world appear much darker and spookier (eventually to be accompanied by a transition to darker music)


SETTING UP

Before doing anything, you must set fog to active in the scene. To do this, go to Edit->Render Settings->Fog and make sure the box is checked. You can make the fog whatever color you like, but ideally make it light enough that you will notice it transition to black as you enter the dark zone. I recommend setting the Fog Mode to Linear and having it start at 0 and end at 300, but you can do whatever feels right to you.

Afterwards, simply drag the Dark Zone prefab onto the map to get a sphere of diameter 300 that will act as your dark zone. You are free to resize this zone to your liking. When you are satisfied with the size and positioning, uncheck the Mesh Renderer box in the Inspector to make the sphere mesh invisible (however, you may want it visible for testing). You can drag as many of these onto the map as you like.


TRANSITION TYPES

There are two different "transition types" (the way that the zone transitions from light to dark and vice versa). These can be accessed from the Transition Type dropdown in the Dark Zone component of the prefab.

Darken Over Duration will cause the transition to occur over a set number of seconds, indicated by the Duration variable below the dropdown. With this setting, once you enter the dark zone, the map will begin to darken automatically over time.

Darken With Depth causes the darkness level to be proportional with how deep you have traveled into the zone. When you switch the dropdown to this option, a variable called Dark Radius will appear. This variable indicates the extent of the "maximum darkness" region within the zone. The default Dark Radius is set to 140, which means, since we have a 300 meter sphere, that once you travel 10 meters into the dark zone, you will have reached the maximum darkness region. Make sure to increase this variable when you increase the size of the sphere and decrease it when you decrease the sphere's size. Adjust it to your liking.
Note: Make sure the radius is never more than one half the diameter of the sphere.


DESIGN RECOMMENDATIONS

In the forest world, I recommend using dark zones in dense patches of forest. This can either be in the static section of the world or in randomly loaded levels (in that case, you would make the dark zone part of the level prefab). Another possible use for dark zones is surrounding the world's Temple (main dungeon), which is one of the static locations on the map (unless you choose to design world maps with randomly-placed Temples). In this case, the Temple wouldn't necessarily have to be surrounded by dense forest, but even so the dark zone would give a forboding atmosphere about the Temple and indicate to the player that they have found an important location. You may use dark zones for these purposes or any you think of. Use them as frequently or as sparingly as you like, but make sure to use them meaningfully.