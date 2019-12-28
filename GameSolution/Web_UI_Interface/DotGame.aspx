<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DotGame.aspx.cs" Inherits="Web_UI_Interface.DotGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/core.js"></script>
    <link href="Content/DotGame.css" rel="stylesheet" />
    <script src="Scripts/DotGame.js"></script>
</head>
<body>
    <div class="pageContainer">

        <div class="inputsContainer">

            <div class="playerInputsOuterContainer">

                <div class="playerInputsInnerContainer">

                    <div class="firstPlayerInputContainer playerInputContainer">
                        
                        <div class="inputComponent">Input player ID for player 1: </div>
                        <div class="inputComponent">
                            <input class="playerInput" id="PID1" type="text" placeholder="first player ID" />
                        </div>

                    </div>

                    <div class="secondPlayerInputContainer playerInputContainer">

                        <div class="inputComponent">Input player ID for player 2: </div>
                        <div class="inputComponent">
                            <input class="playerInput" id="PID2" type="text" placeholder="second player ID" />
                        </div>

                    </div>

                </div>

            </div>

            <div class="speedInputsOuterContainer">

                <div class="speedInputsInnerContainer">

                    <div class="speedInput active" data-speed="3">Slow</div>

                    <div class="speedInput" data-speed="2">Average</div>

                    <div class="speedInput" data-speed="1">Fast</div>

                </div>

            </div>

        </div>

        <div class="simulateButtonContainer">

            <div class="simulateButton">
                Simulate
            </div>

        </div>

        <div class="gameRenderContainer">

            

        </div>

        <div class="scoreOverlayContainer">

            <div class="scoreOverlay">

                <div class="playerScoreLeft playerScore">
                    <div class="scoreLabel">
                        Player 1 Score: 
                    </div>
                    <div class="scoreValue">
                        0
                    </div>
                </div>

                <div class="playerScoreRight playerScore">
                    <div class="scoreLabel">
                        Player 2 Score: 
                    </div>
                    <div class="scoreValue">
                        0
                    </div>
                </div>

            </div>

        </div>

    </div>
</body>
</html>
