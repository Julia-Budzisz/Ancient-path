# 🌿 Ancient-path
Anciet path is a 3D, FPP, adventure, puzzle game, which you play as a scientist, who needs to escape from an azteck temple. Game is still in a development level, this is a showcase of my work on the demo.  
# 🔧 Technologies
- Unity
- Visual Studio 2022
- C#
# ⚡Features
- Traps as a obstacles, which make moving through maze difficult.
- AI as azteck masks, which are patrolling whole maze and chase the player if they spot him.
- Artefact puzzle, which enables an escape from a temple.
- Respawn point mechanic with a visual
# 📍 The Process
Ancient path is a game made for my university course. The demo was developed by a five-person team, over the course of 3 months. I was the solo programmer on the team, responsible for implementing gameplay systems and turning the designers’ ideas into working mechanics.

I started simple with a player and main camera movement, along with a pickup ability. Then I focused on traps. The demo includes two types of traps. The first one is an arrow trap that, after the player enters the trigger box, spawns arrows which slow the player's movement for 3 seconds. The second one is a vanishing floor trap which disappears if the player steps on it and causes the player to die. 

Later, I started developing the AI and the artefact puzzle system simultaneously. The enemies use Unity’s NavMesh Agent and NavMesh Surface for navigation. For the puzzle mechanic, I implemented a rotating segment system and added an outline to make it clear which segment the player is currently manipulating. 

In the final stage of development, I implemented the main menu, pause menu, cutscenes, credits, and prepared the final game build.

# 📚 What I Learned
- How to use NavMesh Surface and Agent
- How to make an outline for objects
- I improved my skills in working with coroutines
- I discovered the video player component
- I learned how to work with color parameters
- Creating animations in Unity

# 💭 How can it be improved?
- The enemy masks could be improved by using raycasting for player detection
- Increase the difficulty of the artefact puzzle
- Add the expedition journal to the gameplay instead of showing it only in a cutscene
- Add additional options to the main menu
- Add audio system


