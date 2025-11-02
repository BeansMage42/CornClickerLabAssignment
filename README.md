# CornClickerLabAssignment



Jonah Gibson 100910759



Cornclicker. a brilliant and innovative take on the idle clicker genre where instead of the joyful satisfaction of watching a number idly tick up as you do other things, you get to manually click the corn everytime and are rewarded with wonderful noises found on the internet.



the game loop is you click the corn to increase number then buy upgrades to make number increase faster.



this assignment used free corn (popped and on the cob) assets found online and a pop sound effect from a free source. These are intended to change in later releases.



sound:https://pixabay.com/users/dragon-studio-38165424

popped corn: https://freepngimg.com/png/23258-popcorn-photos

https://freepngimg.com/png/8402-corn-png-image

caramel corn: https://www.pngall.com/caramel-popcorn-png/download/23926/

chocolate popcorn: https://citypopdenver.com/products/chocolate-popcorn



Singleton:



Implimentation pseudocode:



public static singletonclass instance

script awake

 	if the static instance isn't null and isn't this script

 		destroy this object

 	if it is null

 		set this object as the static instance

 		do not destroy on load





I used it to set up two main systems, audio and UI. I chose to adopt the pattern for those systems because both UI and audio will be present across the games lifetime and should be quickly and easily accessible by a veriety of systems. Making them singleton ensures that not only will tehy always be easily accessible but that I know exactly what im accessing and where it is. For audio it means I can store all sound effects and their triggers in one place rather than having everything that makes a noise carry its own reference. For UI it means I can update all the UI elements and hold their references in one location. This is really beneficial for organization and encapsulation of the processes. I wont need to code the sound playing behaviour on everything and add the sound clip to dozens of different objects.



Factory pattern:

diagram: https://drive.google.com/file/d/1kUuz5LKL0l-6giWUelgwHgFTJ1cIUk\_M/view?usp=sharing



I created a system that allows the game to spawn multiple different types of popcorn background assets as a way to add some dynamics to the visuals of the game. using the factory pattern for this allows the developer (me) to easily expand the types of popcorn spawned and modify the ways the popcorn is spawned to the behaviour it has on spawn. Such as popcorn that always spawns in pairs rather than singularly. This is achieved through the ICornSpawner (named like an interface because it was an interface until I switched to an abstract class so I could ahve some basic inheritable behaviours). the IcornSpawner has a spawn function, stores the spawnable object and has a function for the spawner being set active, which adds it to the list of spawners the PopcornMaker class activates. the popcornmaker class handles all the object spawning. It has a list of active spawner. the update function counts up to the spawn time then triggers all the spawn events. 



when the corn is clicked it triggers the Popcornmakers normalclick function which activates the normal popcorn spawner which spawns a random popcorn at a random point and rotation within a radius.

Observer:
 Refer to ObserverPatternDiagram.PNG for diagram

 Observer pattern was harder to impliment than the previous two in this game because there arent many places where I need multiple scripts to react to a singular event. My solution was to change a few of the singleton pattern implimentations into observer. Specifically, when the corn is clicked, I need a sound to play, UI to update and popcorn effects to spawn. Rather than have the cornclicker call each of those, I created an event on the corn clicker called OnClickAction that is invoked when the corn is clicked and then the audio script, UI script and the spawner script all subscribe to this event. This allowed me to remove the singleton pattern from the audiomanager and simplified the cornclicker code. Using the pattern like this will allow me to eventually tie more effects to clicking the corn much more easily and allow me to even create situations where the kind of effects are switched out if I so desired. 

