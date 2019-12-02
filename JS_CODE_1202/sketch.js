const connection = new Connection(

    "BeatMatchingProject",
    "player",
    "https://www.bigscreens.live"

    // "Balls",
    // "player",
    // "https://bigscreens.herokuapp.com"
    // "https://bigscreens.herokuapp.com"
);

connection.onConnect(() => {
    console.log("CONNECTED");
});

connection.onDisconnect(() => {
    console.log("DISCONNECTED");
});

connection.onError(err => {
    console.error("CONNECTION ERROR:", err);
});

connection.onOtherConnect((id, type) => {
    console.log(`OTHER CONNECTED: ${id}, ${type}`);
});

connection.onOtherDisconnect((id, type) => {
    console.log(`OTHER DISCONNECTED: ${id}, ${type}`);
});



var color_left = 100;
var color_right = 100;
var color_both = 100;
var color_ocean = 100;
var mouseIsPressed = false;

function setup() {
    createCanvas(windowWidth, windowHeight);
}

function draw() {
    background(220);
    fill(color_left, 100, 100);
    rect(0, 0, windowWidth / 2, windowHeight / 2);

    fill(100, color_right, 100);
    rect(windowWidth / 2, 0, windowWidth / 2, windowHeight / 2);

    fill(100, 100, color_both);
    rect(0, windowHeight / 2, windowWidth, windowHeight / 4);

    fill(color_ocean, color_ocean, color_ocean);
    rect(0, windowHeight / 4 * 3, windowWidth, windowHeight / 4);


    textSize(10);
    fill(255);
    text('LEFT:A KEY', windowWidth / 4, windowHeight / 4);
    text('RIGHT:D KEY', windowWidth / 4 * 3, windowHeight / 4);
    text('BOTH:W KEY', windowWidth / 2, windowHeight / 4 * 2.5);
    text('SWITCH:O KEY', windowWidth / 2, windowHeight / 4 * 3.5);

    // Plan A: cellphone control
    // if (mouseX < (windowWidth / 2) && mouseX > 0 && mouseY < windowHeight / 2) {
    //     if (mouseIsPressed) {
    //         color_left = 255;
    //         color_right = 100;
    //         connection.send("create-left");
    //     } else if (!mouseIsPressed) {
    //         color_left = 100;
    //         color_right = 100;
    //         connection.send("down-left");
    //     }
    // } else if (mouseX > (windowWidth / 2) && mouseX < windowWidth && mouseY < windowHeight / 2) {
    //     if (mouseIsPressed) {
    //         color_right = 255;
    //         color_left = 100;
    //         connection.send("create-right");
    //     } else if (!mouseIsPressed) {
    //         color_right = 100;
    //         color_left = 100;
    //         connection.send("down-right");
    //     }
    // } else if (0 < mouseX < windowWidth && ((windowHeight / 2) < mouseY < (windowHeight / 2 * 3))) {
    //     if (mouseIsPressed) {
    //         color_both = 255;
    //         connection.send("create-both");
    //     } else if (!mouseIsPressed) {
    //         color_both = 100;
    //         connection.send("down-both");
    //     }
    // }





}

// function mousePressed() {
//     mouseIsPressed = true;
//     console.log(mouseIsPressed);
// }
//
// function mouseReleased() {
//     mouseIsPressed = false;
//     console.log(mouseIsPressed);
// }

// Plan B: computer keyboard control

document.addEventListener("keydown", keydown);
document.addEventListener("keyup", keyup);

function keydown(event) {
    var x = event.key;
    if (x == "a" || x == "A") {
        color_left = 255;
        connection.send("create-left");
        console.log("create-left");
    }

    if (x == "d" || x == "D") {
        color_right = 255;
        connection.send("create-right");
        console.log("create-right");
    }

    if (x == "w" || x == "W") {
        color_both = 255;
        connection.send("create-both");
        console.log("create-both");
    }

    if (x == "O" || x == "o") {
        color_ocean = 200;
        console.log("switch to ocean!");
        connection.send("switch-scene");
    }

}

function keyup(event) {
    var x = event.key;
    if (x == "a" || x == "A") {
        color_left = 100;
        connection.send("down-left");
        console.log("down-left");
    }
    if (x == "d" || x == "D") {
        color_right = 100;
        connection.send("down-right");
        console.log("down-right");
    }

    if (x == "w" || x == "W") {
        color_both = 100;
        connection.send("down-both");
        console.log("down-both");
    }

}