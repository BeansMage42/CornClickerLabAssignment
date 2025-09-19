# CornClickerLabAssignment



Jonah Gibson 100910759



Cornclicker. a brilliant and innovative take on the idle clicker genre where instead of the joyful satisfaction of watching a number idly tick up as you do other things, you get to manually click the corn everytime and are rewarded with wonderful noises found on the internet.



the game loop is you click the corn to increase number then buy upgrades to make number increase faster.



this assignment used free corn (popped and on the cob) assets found online and a pop sound effect from a free source. These are intended to change in later releases.



sound:https://pixabay.com/users/dragon-studio-38165424

popped corn: https://freepngimg.com/png/23258-popcorn-photos

https://freepngimg.com/png/8402-corn-png-image



Implimentation pseudocode:



public static singletonclass instance

script awake

&nbsp;	if the static instance isn't null and isn't this script

&nbsp;		destroy this object

&nbsp;	if it is null

&nbsp;		set this object as the static instance

&nbsp;		do not destroy on load





I used it to set up two main systems, audio and UI. I chose to adopt the pattern for those systems because both UI and audio will be present across the games lifetime and should be quickly and easily accessible by a veriety of systems. Making them singleton ensures that not only will tehy always be easily accessible but that I know exactly what im accessing and where it is. For audio it means I can store all sound effects and their triggers in one place rather than having everything that makes a noise carry its own reference. For UI it means I can update all the UI elements and hold their references in one location. This is really beneficial for organization and encapsulation of the processes. I wont need to code the sound playing behaviour on everything and add the sound clip to dozens of different objects. 

