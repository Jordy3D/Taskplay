# Taskplay
![Screenshot](https://raw.githubusercontent.com/evilpro/Taskplay/master/Taskplay.png)

Taskplay is a small utility which adds media playback controls to the Windows System Tray, originally created by [evilpro](https://github.com/evilpro/Taskplay)

## Info
Taskplay is written in C#

It is currently targeting .NET Framework 2.0 so it should be compatible with most Windows versions. 

## Notes
The program currently always starts with the Play/Pause icon on the "Click to Play" state. If your media is already playing when you run the program, it may not function as you expect.
### >>> I will not fix this. <<<  
I don't know how to hook into the Windows playing state information.  
Even if I did, if you have two media sources open at once, one paused and one not, and you hit the Play/Pause icon, it will toggle between the two (as will all media control things, to my knowledge)

## Nice-to-haves
- Scroll over buttons to change volume (currently on Middle-Click actions)
- Media play state detection
- ~Theme-supported Settings~
- ~Options for showing/hiding icons~

## Download
To download Taskplay, please go to the Releases tab of this repository.
