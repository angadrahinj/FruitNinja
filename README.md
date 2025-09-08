# FruitNinja

NOTE : 
- I did not make this project myself since this is a project I followed from Youtube - https://www.youtube.com/watch?v=xTT1Ae_ifhM&ab_channel=Zigurous

WHAT I ADDED TO THE PROJECT:
- Reworked Phyics
    - Added custom gravity, i wanted the chopped fruits to fall faster/ more violently

- Blade combo (just like the original Fruit Ninja, that can go upto 10)
    - Blade combo resides on the main Blade GameObject
    - Once the combo is finished, it spawns a ComboText prefab

- Combo Text
    - Each combo is a SO that holds color data for what the outlines and gradient color should be 
    
    - (any combo above 10 has the same colors as 10, although you can setup more if you so choose) => 
        - just add a new SO, decide the colors, and make sure the number 'Slice Combo Int' is correct
        - add your SO to the ComboText prefab, there is a list that holds all the SOs

    - The combo text prefab decides the color when it spawns and handles the setup of the colors
    - It destroys itself automatically after a few seconds

- Score Manager
    - Pretty primitive and self explanatory, calculates scoring everytime you cut a fruit
    - Getting a combo of 3 gives you a total of 6 points, just like the original game
    - Added a primitive Best Score using Unity's PlayerPrefs

Timer Manager
    - Primitive timer, gets reset when you cut a bomb


To anyone reading this, ENJOY :). This project was really fun to work on. Thanks Adam, aka Zigurous, I learnt a lot from following this tutorial.

