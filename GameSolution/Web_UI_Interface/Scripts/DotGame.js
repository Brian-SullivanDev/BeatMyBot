let currentSpeedSetting = 3;

ƒ(document)[0].addEventListener("DOMContentLoaded", function () {

    ƒ(".speedInput").each(function () {

        this.addEventListener("click", setActiveSpeedInput);

    });

    ƒ(".simulateButton")[0].addEventListener("click", performSimulate);

    setupGrid();

}, false);

let setupGrid = function () {

    let newHTML = [];

    for (let row = 0; row < 9; ++row) {

        newHTML.push('<div class="renderingRow" data-row="' + row + '">');

        for (let col = 0; col < 9; ++col) {

            let additionalClasses = "";
            if (row === 0) {
                additionalClasses = "firstRow";
            }
            else if (row === 8) {
                additionalClasses = "lastRow";
            }
            if (col === 0) {
                additionalClasses += " firstCol";
            }
            else if (col === 8) {
                additionalClasses += " lastCol";
            }
            newHTML.push('<div class="renderingBox ' + additionalClasses + '" data-row="' + row + '" data-col="' + col + '">');
            newHTML.push('</div>');

        }

        newHTML.push("</div>");

    }

    let finalHTML = newHTML.join("");

    ƒ(".gameRenderContainer").html(finalHTML);

    let width = ƒ(".gameRenderContainer").width();
    let height = ƒ(".gameRenderContainer").height();

    if (width > height) {
        ƒ(".gameRenderContainer").width(height.toString() + "px");
    }
    else if (height > width) {
        ƒ(".gameRenderContainer").height(width.toString() + "px");
    }

};

let performSimulate = async function () {

    let player1ID = ƒ(".firstPlayerInputContainer .playerInput")[0].value;
    let player2ID = ƒ(".secondPlayerInputContainer .playerInput")[0].value;

    if (player1ID !== "1" && player1ID !== "2") {
        alert("first player ID must be a valid value (currently 1 or 2)");
        return;
    }

    if (player2ID !== "1" && player2ID !== "2") {
        alert("second player ID must be a valid value (currently 1 or 2)");
        return;
    }

    let renderInstructions = await ƒ.ajax({

        url: "DotGameAPI?PID1=" + player1ID + "&PID2=" + player2ID

    });

    renderSimulation(JSON.parse(renderInstructions));

    console.log(renderInstructions);

};

let setActiveSpeedInput = function (e) {

    let target = e.target;

    var className = " " + target.className + " ";
    if (ƒ(target).hasClass("active") === false) {
        ƒ(".speedInput.active").each(function () {

            ƒ(this).removeClass("active");

        });
        ƒ(target).addClass("active");
        currentSpeedSetting = ƒ(target)[0].getAttribute("data-speed");
        console.log(currentSpeedSetting);
    }

};

let takeRenderStep = function (renderInstructions, index, lastPlayerID) {

    let color = null;

    let x1 = 0;
    let y1 = 0;
    let x2 = 0;
    let y2 = 0;

    let player1ID = ƒ(".firstPlayerInputContainer .playerInput")[0].value;
    let player2ID = ƒ(".secondPlayerInputContainer .playerInput")[0].value;

    let delay = (25 * currentSpeedSetting);

    let nextInstruction = renderInstructions[index];

    let currentPlayerID = nextInstruction.PlayerID;

    x1 = nextInstruction.Start.X;
    y1 = nextInstruction.Start.Y;
    x2 = nextInstruction.End.X;
    y2 = nextInstruction.End.Y;

    if (currentPlayerID.toString() === player1ID) {
        color = "red";
    }
    else if (currentPlayerID.toString() === player2ID) {
        color = "blue";
    }
    else {
        color = "grey";
    }

    setTimeout(function () {

        drawLine(x1, y1, x2, y2, color);

        if (currentPlayerID === lastPlayerID) {
            fillAllBoxes(x1, y1, x2, y2, color);
        }

        lastPlayerID = currentPlayerID;

        if (index < renderInstructions.length) {
            takeRenderStep(renderInstructions, index + 1, lastPlayerID);
        }

    }, delay);

};

let renderSimulation = function (renderInstructions) {

    console.log(renderInstructions);

    takeRenderStep(renderInstructions, 0, -1);

};



let drawLine = function (x1, y1, x2, y2, color) {

    if (x1 !== x2) {
        if (x1 > x2) {
            drawHorizontalLine(x2, x1, y1, color);
        }
        else {
            drawHorizontalLine(x1, x2, y1, color);
        }
    }
    else {
        if (y1 > y2) {
            drawVerticalLine(x1, y2, y1, color);
        }
        else {
            drawVerticalLine(x1, y1, y2, color);
        }
    }

};

let drawHorizontalLine = function (x1, x2, y, color) {

    let col = x1;
    let row = y;

    let cell = null;

    if (row === 0 || row === 1) {

        cell = ƒ(".renderingBox[data-row='0'][data-col='" + col + "']");

    }
    else {

        cell = ƒ(".renderingBox[data-row='" + (row - 1) + "'][data-col='" + col + "']");

    }

    if (row === 0) {

        cell[0].style.borderTopStyle = "solid";
        cell[0].style.borderTopColor = color;

    }
    else {

        cell[0].style.borderBottomStyle = "solid";
        cell[0].style.borderBottomColor = color;

    }

};

let drawVerticalLine = function (x, y1, y2, color) {

    let col = x;
    let row = y1;

    let cell = null;

    if (col === 0 || col === 1) {

        cell = ƒ(".renderingBox[data-row='" + row + "'][data-col='0']");

    }
    else {

        cell = ƒ(".renderingBox[data-row='" + row + "'][data-col='" + (col - 1) + "']");

    }

    if (col === 0) {

        cell[0].style.borderLeftStyle = "solid";
        cell[0].style.borderLeftColor = color;

    }
    else {

        cell[0].style.borderRightStyle = "solid";
        cell[0].style.borderRightColor = color;

    }

};

let fillBox = function (row, col, color) {



};

let fillAllBoxes = function (x1, y1, x2, y2, color) {

    

};