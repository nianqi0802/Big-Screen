const fs = require("fs");
const csvFile = fs.readFileSync("RBeats.csv").toString();
const array = csvFile.split(",");
const beats = [];
for (let i = 0; i < array.length; i += 2) {
    beats.push(parseFloat(array[i]) + "f");
}
console.log(beats.toString());
