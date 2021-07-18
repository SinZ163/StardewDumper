# Stardew Dumper
This is intended for helping maintain ocmmunity wiki's for Stardew Valley

## Usage
1. Compile and build the StardewDumper mod
2. Launch Stardew Valley and load a save
3. Once your character has woken up you can close Stardew Valley.
4. Copy the newly made gift_tastes.json file to the input folder of PostProcessing
5. Navigate to the `PostProcessing` folder and run `yarn` in command line
6. run `yarn start` and now you should have output/gift_tastes.json updated to match your modded installation.

## Maintenance
* PostProcessing/reference/vanilla_gift_tastes.json is just running StardewDumper on a installation with no mods that add NPC's or items
* PostProcessing/reference/universal_gift_tastes.json is a manually curated file originally based off Marnie or Alex and then removing items that aren't actually universal and correcting their exceptions