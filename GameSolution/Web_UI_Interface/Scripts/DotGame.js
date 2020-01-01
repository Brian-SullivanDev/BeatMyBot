let currentSpeedSetting = 3;

let const_cols = 9;
let const_rows = 9;

ƒ(document)[0].addEventListener("DOMContentLoaded", function () {

    ƒ(".speedInput").each(function () {

        this.addEventListener("click", setActiveSpeedInput);

    });

    ƒ(".simulateButton")[0].addEventListener("click", performSimulate);

    setupGrid();

}, false);

let setupGrid = function () {

    let newHTML = [];

    for (let row = 0; row < const_rows; ++row) {

        newHTML.push('<div class="renderingRow" data-row="' + row + '">');

        for (let col = 0; col < const_cols; ++col) {

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

    ƒ(".scoreValue").html("0");

};

let performSimulate = async function () {

    let player1ID = ƒ(".firstPlayerInputContainer .playerInput")[0].value;
    let player2ID = ƒ(".secondPlayerInputContainer .playerInput")[0].value;

    if (player1ID !== "1" && player1ID !== "2" && player1ID !== "3" && player1ID !== "4" && player1ID !== "5" && player1ID !== "6") {
        alert("first player ID must be a valid value (currently 1, 2, 3, 4, 5, or 6)");
        return;
    }

    if (player2ID !== "1" && player2ID !== "2" && player2ID !== "3" && player2ID !== "4" && player2ID !== "5" && player2ID !== "6") {
        alert("second player ID must be a valid value (currently 1, 2, 3, 4, 5, or 6)");
        return;
    }

    let renderInstructions = await ƒ.ajax({

        url: "DotGameAPI?PID1=" + player1ID + "&PID2=" + player2ID

    });

    setupGrid();

    renderSimulation(JSON.parse(renderInstructions));

    //console.log(renderInstructions);

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

        let nextPlayerID = -1;

        if (index < renderInstructions.length - 1) {
            nextPlayerID = renderInstructions[index + 1].PlayerID;
        }

        drawLine(x1, y1, x2, y2, color);

        if (currentPlayerID === nextPlayerID || nextPlayerID === -1) {
            fillAllBoxes(x1, y1, x2, y2, color, currentPlayerID);
        }

        lastPlayerID = currentPlayerID;

        if (index < renderInstructions.length - 1) {
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

let fillBox = function (col, row, color, id) {

    if (col >= const_cols || row >= const_rows) {
        return false;
    }

    let cell = ƒ(".renderingBox[data-row='" + row + "'][data-col='" + col + "']");

    let bottom = (getComputedStyle(cell[0]).borderBottomStyle !== "dotted");
        

    let right = (cell[0].style.borderRightStyle !== "dotted");

    let top = false;

    let left = false;

    if (row === 0) {

        top = (getComputedStyle(cell[0]).borderTopStyle !== "dotted");

    }
    else {

        let topCell = ƒ(".renderingBox[data-row='" + (row - 1) + "'][data-col='" + col + "']");

        top = (getComputedStyle(topCell[0]).borderBottomStyle !== "dotted");

    }

    if (col === 0) {

        left = (getComputedStyle(cell[0]).borderLeftStyle !== "dotted");

    }
    else {

        let leftCell = ƒ(".renderingBox[data-row='" + row + "'][data-col='" + (col - 1) + "']");

        left = (getComputedStyle(leftCell[0]).borderLeftStyle !== "dotted");

    }

    if (bottom && right && top && left) {

        if (getComputedStyle(cell[0]).backgroundColor === "rgb(255, 255, 255)") {

            cell[0].style.backgroundColor = color;
            let scoreElem = null;
            if (id.toString() === ƒ(".firstPlayerInputContainer .playerInput")[0].value) {

                scoreElem = ƒ(".playerScoreLeft .scoreValue");

            }
            else {

                scoreElem = ƒ(".playerScoreRight .scoreValue");

            }

            let currentScore = scoreElem[0].innerText;
            let newScore = 1 + parseInt(currentScore);
            scoreElem.html(newScore);

        }

    }

};

let fillHorizontalBoxes = function (col, row, color, id) {

    fillBox(col, row, color, id);

    if (row > 0) {

        fillBox(col, row - 1, color, id);

    }

};

let fillVerticalBoxes = function (col, row, color, id) {

    fillBox(col, row, color, id);

    if (col > 0) {

        fillBox(col - 1, row, color, id);

    }

};

let fillAllBoxes = function (x1, y1, x2, y2, color, id) {

    if (x1 !== x2) {
        if (x1 > x2) {
            fillHorizontalBoxes(x2, y1, color, id);
        }
        else {
            fillHorizontalBoxes(x1, y1, color, id);
        }
    }
    else {
        if (y1 > y2) {
            fillVerticalBoxes(x1, y2, color, id);
        }
        else {
            fillVerticalBoxes(x1, y1, color, id);
        }
    }

};