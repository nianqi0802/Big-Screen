const fs = require("fs");
const csvFile = fs.readFileSync("LBeats.csv").toString();
const array = csvFile.split(",");
const beats = [];
for (let i = 1; i < array.length; i += 2) {
    beats.push(parseFloat(array[i]) + "f");
}
console.log(beats.toString());