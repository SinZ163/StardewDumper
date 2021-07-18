import * as fs from "fs"

interface GiftTastesFile {
    [npcName: string] : GiftTastes
}
interface GiftTastes {
    [itemName: string]: "Love"|"Like"|"Neutral"|"Dislike"|"Hate"
}


var inputGifts: GiftTastesFile = require("./input/gift_tastes.json");
var referenceGifts: GiftTastesFile = require("./reference/vanilla_gift_tastes.json");
var universalGifts: GiftTastes = require("./reference/universal_gift_tastes.json");


let output: GiftTastesFile = {};

for (const [npc, items] of Object.entries(inputGifts)) {
        let filteredItems = {};
        let referenceItems = referenceGifts[npc];
        for ( const [id, taste] of Object.entries(items)) {
            // if the current NPC is falsey in the vanilla dataset or had nothing originally (Gunther)
            if (!referenceGifts[npc] || Object.keys(referenceGifts[npc]).length === 0) {
                if (universalGifts[id] !== taste) {
                    filteredItems[id] = taste;
                }
            }
            else if (referenceItems[id] !== taste) {
                filteredItems[id] = taste;
            }
        }
        output[npc] = filteredItems;
}

fs.writeFileSync("./output/gift_tastes.json", JSON.stringify(output, undefined, 4));