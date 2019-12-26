<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DotGame.aspx.cs" Inherits="Web_UI_Interface.DotGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/core.js"></script>
</head>
<body>
    <div class="pageContainer">

        <div class="inputsContainer">

            <div class="playerInputsContainer">

                <div class="firstPlayerInputContainer">

                    <input class="playerInput" id="PID1" type="text" placeholder="first player ID" />

                </div>

                <div class="secondPlayerInputContainer">

                    <input class="playerInput" id="PID2" type="text" placeholder="second player ID" />

                </div>

            </div>

            <div class="speedInputsContainer">

                <div class="speedInputContainer">

                    <div class="speedInput" data-speed="1">Slow</div>

                    <div class="speedInput" data-speed="2">Average</div>

                    <div class="speedInput" data-speed="3">Fast</div>

                </div>

            </div>

        </div>

        <div class="gameRenderContainer">

            rendered game goes here

        </div>

    </div>
</body>
</html>
