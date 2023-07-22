## Description
The "Hover" script is a Unity component that allows you to get visual feedback while you are hovering over GameObjects in your with mouse. When the mouse cursor hovers over a GameObject with the "Hover" script attached, the script triggers various visual effects, such as changing the emission color of the GameObject's materials, playing an animation, and activating a particle system. Additionally, it can display a UI object associated with the hovered GameObject.


https://github.com/mozankatip/unity-mouse-hover/assets/47041584/a95c8645-d464-42b2-95a6-7c31e8b8c5a2


## How to Use
1. Attach the "Hover" script to any GameObject you want to apply the hover effect to.
2. Configure the script in the Inspector:

- **Renderers**: Add all the renderers associated with the GameObject that should change emission color when hovered over. These renderers should have materials with an "_EmissionColor" property.
- **Animator**: If you want to play an animation when the GameObject is hovered over, assign the Animator component here.
- **Hover Particle**: If you want a particle system to be activated when the GameObject is hovered over, assign it here.
- **UI Object**: If you want to display a UI element when the GameObject is hovered over, assign the UI GameObject here.
  
![Properties](https://github.com/mozankatip/unity-mouse-hover/assets/47041584/af0a8104-3e78-4a27-9944-62cc3d95979c)

3. Optionally, change the hover effect's emission color by modifying the SetHoverEmissionColor method's hoverEmissionColor variable inside the script.
4. Save the script changes and return to the Unity Editor.
5. Make sure you have a working camera in your scene, as the script uses the main camera to cast a ray to detect the hover.
6. If you want to hide the UI object initially, make sure to disable it in the Inspector. The script will automatically enable it when the GameObject is hovered over.
7. Run your Unity scene. When you move the mouse cursor over the GameObject with the "Hover" script attached, it should trigger the hover effect with the associated visual changes, animation, and particle system.

## Important Notes
- The script checks for UI elements to avoid triggering the hover effect when the mouse cursor is over them. This ensures that UI interactions are not affected by the hover effect.
- The script uses raycasting to detect when the mouse cursor hovers over the GameObject. Ensure that the GameObject has a collider component to detect the raycast properly.
- The script assumes that the emission property of the materials on the GameObject's renderers is named "_EmissionColor". If your materials use a different property name for emission, adjust the script accordingly.
