////////////////////////////////////////
// CONNECTION
////////////////////////////////////////
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


const button_left = document.getElementById("button_left");
button_left.onpointerdown = () => {
    console.log("LEFT IN!");
    connection.send("create-left");
};

button_left.onpointerup = () => {
    console.log("LEFT OUT!");
    connection.send("down-left");
};


const button_right = document.getElementById("button_right");
button_right.onmousedown = () => {
    console.log("RIGHT IN!");
    connection.send("create-right");
};

button_right.onmouseup = () => {
    console.log("RIGHT OUT!");
    connection.send("down-right");
};

const button_both = document.getElementById("button_both");
button_both.onmousedown = () => {
    console.log("BOTH IN!");
    connection.send("create-both");
};

button_both.onmouseup = () => {
    console.log("BOTH OUT!");
    connection.send("down-both");
};

const button_switch = document.getElementById("button_switch");
button_switch.onmousedown = () => {
    console.log("switch IN!");
    connection.send("switch-scene");
};