# Timeline Market Demo Enhanced  

An updated version of the project files from the 'Unite Europe 2017 - Use Timeline and Cinemachine to mix gameplay & cutscenes' talk. It has been updated from the original to use the latest version of cinemachine, textmesh pro, URP, and has enhanced playables such as one that allows for you to use NavMesh paths on timeline with scrubbing and dynamic adjustments.   

![market demo screenshot](.github/market_demo_screenshot.png?raw=true "market demo screenshot")  

## Background  

The original 'timeline market demo' with all of the playables used in the talk isn't available anymore from Unity - probably because it's so old now that it won't work without overhaul. I found the assets elsewhere on github and fix/reorganized/enhanced it.  

Repo where I found the assets (with some useful playables!):  

[https://github.com/PlayApple/UnityTimelineExample](https://github.com/PlayApple/UnityTimelineExample)    

Repo where I found the beautiful URP toon shader:  

[https://github.com/ardahamamcioglu/ToonShader_URP](https://github.com/ardahamamcioglu/ToonShader_URP)  

Other excellent repo with cinemachine demonstrations and adventure game assets:  

[https://github.com/ciro-unity/cinemachine-market](https://github.com/ciro-unity/cinemachine-market)  

I fixed everything that was broken so it can continue to be used for learning about timeline, cinemachine and the playables demonstrated in the talk.  

## Steps to Follow to Run the Project  

-- Create a new URP project  
-- Install Cinemachine from the package manager (click window -> package manager -> unity registry -> find cinemachine and click 'install'  
-- Install TextMeshPro using the integrated unity menu (click window -> textmesh pro -> import TMP Essential Resources  
-- clone or download this repo and put everything into your project's Asset folder  
-- find Scenes/demo and open it, click play button  
-- press 'V' key while in playmode to spawn some collectables to see how they work  
-- enable the DayAndNightCycle and StormTimeline GameObjects in the scene to see how what they do  

## Notes on Contents and NavMeshAgentProgress playable  

Find the Unite Europe 2017 talk by Andy Touch on youtube for an explanation of the playables in the project.    
   
The conversations playable has been enhanced to use TMP_Text and TMP_FontAsset instead of the older UI elements. It was also enhanced by PlayApple to display character images.  

The GuardTimeline is using a custom NavMeshAgentProgress playable which is different from the older NavMeshAgentControl playable available with the free default playables and included in this repo. The original playable allows for you to set a destination and only works in play mode. The NavMeshAgentProgress playable does a lot more than that.  

The NavMeshAgentProgress playable has preview/scrubbing in the timeline window. It does this by converting the timeline clip progress to a position on a NavMeshAgent's path. You are intended to have a separate animation track with the walking animation and others as shown in the example.  

One thing to be aware of is that root motion curves in the animations can interfere with the path movement. I discovered a workaround to this that's mentioned here  

[Scripts/Playables/NavMeshAgentProgress/NavMeshAgentProgressPlayableBehaviour.cs#L123](Scripts/Playables/NavMeshAgentProgress/NavMeshAgentProgressPlayableBehaviour.cs#L123)    

The playable adds a component to the NavMeshAgent's GameObject that's has an empty OnAnimatorMoved callback and removes it when the timeline is done. No clue why that fixes the problem but if you remove that part you'll see the issue I'm talking about.    

Like it says in the comment, this has something to do with what's described in this forum thread.  

[https://forum.unity.com/threads/how-to-properly-use-onanimatormove-without-breaking-timeline.600199/](https://forum.unity.com/threads/how-to-properly-use-onanimatormove-without-breaking-timeline.600199/)  

I hope this NavMesh path progression playable is useful to people who clone this project!  
