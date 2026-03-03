# Custom Avatar Loader Mod for Desktop Mate (Sound Edition)
⚠ The original repository by [YusufOzmen01](https://github.com/YusufOzmen01) has been archived.
This fork continues development and introduces new features,
including an animation-based reactive sound system.
## 🔊 Sound Edition – Animation-Based Reactive Audio (Maintained Fork)

Maintained Fork
This version adds an animation-based reactive sound system.
This fork adds a reactive sound system that plays audio based on specific animation events in Desktop Mate.

When supported animations are triggered (click, lift, rub, peek, etc.), corresponding sound effects are played automatically.

---

## 🎯 Supported Animation Events

| Animation | Event Description | Sound Triggered |
|------------|------------------|----------------|
| **E1** | Click (Stand) | `anime-ahh.wav` |
| **E2** | Click (Sit – Hands on Mouth) | `yamete-kudasai.wav` |
| **F1** | Going Out | `bye-bye.wav` |
| **F2** | Coming In | `tuturu_1.wav` |
| **C1** | Back Lifting | `oh-my-god.wav` |
| **C2** | Hand Lifting | `onich.wav` |
| **G2_R** | Side Peek (Right) | `girl-uwu.wav` |
| **G2_L** | Side Peek (Left) | `nya.wav` |
| **D1** | Rubbing (Standing Love) | `uwu.wav` |
| **D2** | Rubbing (Sitting Love) | `yamete-kudasai.wav` |

---

## 📦 Installation (Sound Edition)

1. Extract the release ZIP.
2. Copy the `Mods` folder into your: Desktop Mate/

## 🔊 Audio Requirements

All sound files must be:

- WAV format  
- 44100 Hz  
- 16-bit  
- Mono  

Other formats may cause distortion or playback artifacts.

---

## ⚙ Technical Notes

- Uses Animator state detection to trigger audio.
- Uses `AudioSource.PlayOneShot()` for stable playback.
- End-of-clip trimming is applied to prevent popping artifacts.
- Idle animations (A/B states) do not trigger sound.

---

## 🛠 Customization

To modify animation-to-sound mapping, edit: TouchSoundWatcher.cs


# Custom Avatar Loader Mod for Desktop Mate

#### [Русский](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_RU.md) / [日本語](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_JP.md) / [简体中文](https://github.com/yuhan2680/desktopmate-custom-avatar-loader/blob/main/README_ZH.md) / [Türkçe](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_TR.md) / [Vietnamese](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_VN.md) / [한국어](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_KR.md) / [Français](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/blob/main/README_FR.md)

<div align="center">
You can support me and my work from Buy Me a Coffee!<br>
Also, don't forget to join the Discord Server!<br>
<a href="https://buymeacoffee.com/sergiomarquina">
<img src="https://i.imgur.com/l7NBjqk.png" alt="drawing" width="150" height="45" align="center">
</a>
<a href="https://discord.gg/cS5nTz82Pe">
<img src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/dfb00471-ff2a-408e-a085-5e722a9a0cc0/db0lvt8-6d2a5cb1-3a30-4371-8bab-c97b8a69df98.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2RmYjAwNDcxLWZmMmEtNDA4ZS1hMDg1LTVlNzIyYTlhMGNjMFwvZGIwbHZ0OC02ZDJhNWNiMS0zYTMwLTQzNzEtOGJhYi1jOTdiOGE2OWRmOTgucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.DwCBSmipmF_tFvDSx_nTIk7m5LzQ8pipxUsJMdOvwII" alt="drawing" width="150" height="45" align="center">
</a>
  <br><br>
</div>
This mod lets you use any .VRM file model you want inside of Desktop Mate!

## Installation

-   Install the latest [MelonLoader](https://github.com/LavaGang/MelonLoader/releases/download/v0.6.6/MelonLoader.Installer.exe) version to DesktopMate (v0.6.6 is the recommended one)
-   Install .NET Runtime 6.0 from [Microsoft](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.36-windows-x64-installer)
-   Download [Custom Avatar Loader.zip](https://github.com/YusufOzmen01/desktopmate-custom-avatar-loader/releases/latest/download/CustomAvatarLoader.zip) from here or Releases section on the right
-   Extract the contents **in the Desktop Mate folder**

## Usage

-   Initial startup of Desktop Mate will take a while as IL2CPP needs to decompile the game binary
-   After that, click on your character and press F4
-   A file dialog will open. Choose any VRM file that you want (make sure it's in a folder that you have permission)
-   And your model should immediately appear!

### You can also access a video tutorial from [here](https://youtu.be/CqjfT6QzRLM)

## Notes for Development

-   Make sure you have .NET Runtime 6.0 and .NET Desktop Support installed for Visual Studio
-   Install [MelonLoader's VSIX](https://github.com/TrevTV/MelonLoader.VSWizard/releases) for developing mods
-   Also, you might need to install Desktop Mate into C drive as it might behave a bit unexpected

# License

Check the [LICENSE.md](LICENSE.md) file for details.
