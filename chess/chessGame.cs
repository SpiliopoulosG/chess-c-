using chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace chess
{
    public partial class ChessGame : Form
    {
        private Chess chessGame;
        int xOffset = 32;
        int yOffset = 64;

        // Chess Variables
        bool gameOn = true;
        static int tileSize = 75;
        static int pieceSize = 55;
        List<string> whitePawns = new List<string>
        {
            "rook", "knight", "bishop", "king", "queen", "bishop", "knight", "rook",
            "pawn", "pawn", "pawn", "pawn", "pawn", "pawn", "pawn", "pawn",
        };
        List<(int, int)> whiteLocations = new List<(int, int)>
        {
            (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0),
            (0, 1), (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1)
        };
        List<string> blackPawns = new List<string>
        {
            "rook", "knight", "bishop", "queen", "king", "bishop", "knight", "rook",
            "pawn", "pawn", "pawn", "pawn", "pawn", "pawn", "pawn", "pawn",
        };
        List<(int, int)> blackLocations = new List<(int, int)>
        {
            (0, 7), (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7),
            (0, 6), (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6)
        };
        List<List<(int, int)>> whiteOptions = new List<List<(int, int)>> { };
        List<List<(int, int)>> blackOptions = new List<List<(int, int)>> { };

        List<string> whiteCapturedPawns = new List<string> { };
        List<string> blackCapturedPawns = new List<string> { };
        List<(int, int)> validMoves = new List<(int, int)> { };
        (int, int) whiteEp = (10, 10);
        (int, int) blackEp = (10, 10);
        int selection = 100;
        // 0 --> White Turn no selection
        // 1 --> White Turn Piece Selected
        // 2 --> Black Turn no selection
        // 3 --> Black Turn Piece Selected
        int currentTurnStep = 0;
        static Image queenBlack = Resources.queenblack;
        static Image kingBlack = Resources.kingblack;
        static Image rookBlack = Resources.rookblack;
        static Image bishopBlack = Resources.bishopblack;
        static Image knightBlack = Resources.knightblack;
        static Image pawnBlack = Resources.pawnblack;

        static Image queenWhite = Resources.queenwhite;
        static Image kingWhite = Resources.kingwhite;
        static Image rookWhite = Resources.rookwhite;
        static Image bishopWhite = Resources.bishopwhite;
        static Image knightWhite = Resources.knightwhite;
        static Image pawnWhite = Resources.pawnwhite;
        static Image[] whiteImages = { pawnWhite, queenWhite, kingWhite, knightWhite, rookWhite, bishopWhite };
        static Image[] blackImages = { pawnBlack, queenBlack, kingBlack, knightBlack, rookBlack, bishopBlack };
        string[] piecesList = { "pawn", "queen", "king", "knight", "rook", "bishop" };

        int counter = 0;
        string winner = "";

        // Timer Varieables
        public static ChessGame instance;
        public Label player1Label;
        public Label player2Label;
        public TextBox tb1;
        public TextBox tb2;

        /////////////////////////////////////////////
        ////////////////// main /////////////////////
        /////////////////////////////////////////////
        public ChessGame()
        {
            chessGame = new Chess();
            InitializeComponent();
            instance = this;
            this.Select();
            player1Label = Player2_Name;
            player2Label = Player1_Name;

            tb1 = Timer1;
            tb2 = Timer2;
            timer3.Start();
            blackTimer.Tick += blackTimer_Tick;
            whiteTimer.Tick += whiteTimer_Tick;
            whiteTimer.Start();


            blackOptions = CheckOptions(blackPawns, blackLocations, "black");
            whiteOptions = CheckOptions(whitePawns, whiteLocations, "white");

            // Counter
            if (counter < 30) {
                counter += 1;
            } else {
                counter = 0;
            }

            // Paints the Chessboard when the Form is painted
            this.Paint += ChessGame_Paint;

            // Set up a timer for continuous painting
            System.Windows.Forms.Timer paintTimer = new System.Windows.Forms.Timer();
            paintTimer.Interval = 16; // FPS 1000ms / 60 frames = 16.6
            paintTimer.Tick += PaintTimer_Tick;
            paintTimer.Start();

            this.MouseClick += Handle_Click;

            DoubleBuffered = true;
        }
        private void PaintTimer_Tick(object sender, EventArgs e)
        {
            if (gameOn) {
                Refresh(); // This will trigger the Paint event and repaint the form
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            history.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void SwitchPlayerTurn()
        {
            if (currentTurnStep <= 1){
                whiteTimer.Stop();  
                blackTimer.Start(); 
            } else {
                blackTimer.Stop();
                whiteTimer.Start();
            }

            // Update the label to show the current player
            currentPlayerLabel.Text = $"{(currentTurnStep <= 1 ? "WHITE" : "BLACK")}";
            currentPlayerLabel.ForeColor = currentTurnStep <= 1 ? Color.White : Color.Black;
        }

        private void blackTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer(blackTimer, Timer1); // Pass blackTimer for player 1 (black

        }

        private void whiteTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer(whiteTimer, Timer2); // Pass Timer2 for player 2 (white)
        }

        private void UpdateTimer(Timer timer, TextBox timerTextBox)
        {
            try
            {
                // Assuming the timer value is in the format "mm:ss"
                string[] timeParts = timerTextBox.Text.Split(':');
                int minutes = int.Parse(timeParts[0]);
                int seconds = int.Parse(timeParts[1]);

                if (seconds > 0)
                {
                    seconds--;
                }
                else
                {
                    if (minutes > 0)
                    {
                        minutes--;
                        seconds = 59;
                    }
                    else
                    {
                        // The timer has reached 0, handle the end of the game or reset the timer
                        timer.Stop(); // Stop the timer
                        gameOn = false;          // You can add additional logic here for game over or resetting the timer
                    }
                }

                timerTextBox.Text = $"{minutes:D2}:{seconds:D2}";
            }
            catch (FormatException ex)
            {
                // Handle the exception (e.g., log or display an error message)
                Console.WriteLine($"Error updating timer: {ex.Message}");
            }
        }


        // Constantly Updated The Screen
        private void ChessGame_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
            DrawCheck(e.Graphics);
            if (selection != 100) {
                validMoves = CheckValidMoves();
                DrawValid(e.Graphics, validMoves);
            }
        }

        // Draws Main Game Board
        private void DrawBoard(Graphics screen)
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x = xOffset + j * tileSize;
                    int y = yOffset + i * tileSize;

                    // Alternate colors for the chessboard
                    Brush brush = (i + j) % 2 == 0 ? Brushes.LightGray : Brushes.Gray;

                    screen.FillRectangle(brush, x, y, tileSize, tileSize);
                }
            }

            // Adjust the starting and ending points of the lines
            for (int j = 0; j < 9; j++)
            {
                screen.DrawLine(Pens.Black, xOffset, yOffset + tileSize * j, xOffset + 8 * tileSize, yOffset + tileSize * j);
                screen.DrawLine(Pens.Black, xOffset + tileSize * j, yOffset, xOffset + tileSize * j, yOffset + 8 * tileSize);
            }

        }
        
        // Draws Chess Pieces
        private void DrawPieces(Graphics screen)
        {
            for (int i = 0; i < whitePawns.Count; i++) {
                int index = Array.IndexOf(piecesList, whitePawns[i]);
                int x = whiteLocations[i].Item1 * tileSize + 10 + xOffset;
                int y = whiteLocations[i].Item2 * tileSize + 10 + yOffset;

                if (whitePawns[i] == "pawn") {
                    screen.DrawImage(pawnWhite, new Rectangle(x, y, pieceSize, pieceSize));
                }
                else {
                    screen.DrawImage(whiteImages[index], new Rectangle(x, y, pieceSize, pieceSize));
                }

                if (currentTurnStep < 2 && selection == i) {
                    using (Pen pen = new Pen(Color.Red, 2)) {
                        screen.DrawRectangle(pen, x - 10, y - 10, tileSize, tileSize);
                    }
                }
            }

            for (int i = 0; i < blackPawns.Count; i++) {
                int index = Array.IndexOf(piecesList, blackPawns[i]);
                int x = blackLocations[i].Item1 * tileSize + 10 + xOffset;
                int y = blackLocations[i].Item2 * tileSize + 10 + yOffset;

                if (blackPawns[i] == "pawn") {
                    screen.DrawImage(pawnBlack, new Rectangle(x, y, pieceSize, pieceSize));
                }
                else {
                    screen.DrawImage(blackImages[index], new Rectangle(x, y, pieceSize, pieceSize));
                }

                if (currentTurnStep >= 2 && selection == i) {
                    using (Pen pen = new Pen(Color.Blue, 2)) {
                        screen.DrawRectangle(pen, x - 10, y - 10, tileSize, tileSize);
                    }
                }
            }
        }

        // Draw Kings Check Indicator
        private void DrawCheck(Graphics screen) {
            if (currentTurnStep < 2) {
                if (whitePawns.Contains("king")) {
                    int kingIndex = whitePawns.IndexOf("king");
                    (int, int) kingLocation = whiteLocations[kingIndex];
                    for (int i = 0; i < blackOptions.Count; i++) {
                        if (blackOptions[i].Contains(kingLocation)) {
                            if (counter < 15) {
                                screen.DrawRectangle(new Pen(Color.DarkRed, 5), kingLocation.Item1 * tileSize + xOffset, kingLocation.Item2 * tileSize + yOffset, tileSize, tileSize);
                            }
                        }
                    }
                }
            } else {
                if (blackPawns.Contains("king")) {
                    int kingIndex = blackPawns.IndexOf("king");
                    (int, int) kingLocation = blackLocations[kingIndex];
                    for (int i = 0; i < whiteOptions.Count; i++) {
                        if (whiteOptions[i].Contains(kingLocation)) {
                            if (counter < 15) {
                                screen.DrawRectangle(new Pen(Color.DarkBlue, 5), kingLocation.Item1 * tileSize + xOffset, kingLocation.Item2 * tileSize + yOffset, tileSize, tileSize);
                            }
                        }
                    }
                }
            }
        }

        // Draws all Valid Moves
        public void DrawValid(Graphics screen, List<(int, int)> moves) {
            string color;

            if (currentTurnStep < 2) {
                color = "red";
            } else {
                color = "blue";
            }

            int ballSize = 8;
            for (int i = 0; i < moves.Count; i++)
            {
                int x = moves[i].Item1 * 75 + (tileSize / 2) + xOffset - ballSize / 2;
                int y = moves[i].Item2 * 75 + (tileSize / 2) + yOffset - ballSize / 2;
                screen.FillEllipse(new SolidBrush(Color.FromName(color)), x, y, ballSize, ballSize);
            }
        }


        // Checks for Valid Moves
        public List<(int, int)> CheckValidMoves() {
            List<List<(int, int)>> optionsList;
            if (currentTurnStep < 2) {
                optionsList = whiteOptions;
            } else {
                optionsList = blackOptions;
            }
            List<(int, int)> validOptions =  optionsList[selection];
            return validOptions;
        }

        public List<List<(int, int)>> CheckOptions(List<string> pieces, List<(int, int)> locations, string turn) {
            List<List<(int, int)>> allMovesList = new List<List<(int, int)>>();

            for (int i = 0; i < pieces.Count; i++) {
                (int, int) location = locations[i];
                string piece = pieces[i];
                List<(int, int)> movesList = new List<(int, int)>();

                if (piece == "pawn") {
                    movesList = CheckPawn(location, turn);
                } else if (piece == "rook") {
                    movesList = CheckRook(location, turn);
                } else if (piece == "knight") {
                    movesList = CheckKnight(location, turn);
                } else if (piece == "bishop") {
                    movesList = CheckBishop(location, turn);
                } else if (piece == "queen") {
                    movesList = CheckQueen(location, turn);
                } else if (piece == "king") {
                    movesList = CheckKing(location, turn);
                }

                allMovesList.Add(movesList);
            }

            return allMovesList;
        }

        // Check King Moves
        public List<(int, int)> CheckKing((int, int) position, string color) {
            List<(int, int)> movesList = new List<(int, int) > ();
            List<(int, int)> enemiesList;
            List<(int, int)> friendsList;

            if (color == "white") {
                enemiesList = blackLocations;
                friendsList = whiteLocations;
            } else {
                friendsList = blackLocations;
                enemiesList = whiteLocations;
            }

            // 8 squares to check for kings, they can go one square in any direction
            List<(int, int)> targets = new List<(int, int)> { (1, 0), (1, 1), (1, -1), (-1, 0), (-1, 1), (-1, -1), (0, 1), (0, -1) };

            for (int i = 0; i < 8; i++) {
                (int, int) target = (position.Item1 + targets[i].Item1, position.Item2 + targets[i].Item2);

                if (!friendsList.Contains(target) && target.Item1 >= 0 && target.Item1 <= 7 && target.Item2 >= 0 && target.Item2 <= 7) {
                    movesList.Add(target);
                }
            }

            return movesList;
        }

        // Check Queen Moves
        public List<(int, int)> CheckQueen((int, int) position, string color) {
            List<(int, int)> movesList = CheckBishop(position, color);
            List<(int, int)> secondList = CheckRook(position, color);

            foreach (var move in secondList) {
               movesList.Add(move);
            }

            return movesList;
        }
        
        // Checks Bishop Moves
        public List<(int, int)> CheckBishop((int, int) position, string color) {
            List<(int, int)> movesList = new List<(int, int)>();

            List<(int, int)> enemiesList;
            List<(int, int)> friendsList;

            if (color == "white") {
                enemiesList = blackLocations;
                friendsList = whiteLocations;
            } else {
                friendsList = blackLocations;
                enemiesList = whiteLocations;
            }

            // up-right, up-left, down-right, down-left
            for (int i = 0; i < 4; i++) {
                bool path = true;
                int chain = 1;
                int x, y;

                if (i == 0) {
                    x = 1;
                    y = -1;
                } else if (i == 1) {
                    x = -1;
                    y = -1;
                } else if (i == 2) {
                    x = 1;
                    y = 1;
                } else {
                    x = -1;
                    y = 1;
                }

                while (path) {
                    int newX = position.Item1 + (chain * x);
                    int newY = position.Item2 + (chain * y);

                    if (!friendsList.Contains((newX, newY)) && newX >= 0 && newX <= 7 && newY >= 0 && newY <= 7) {
                        movesList.Add((newX, newY));

                        if (enemiesList.Contains((newX, newY))) {
                            path = false;
                        }

                        chain += 1;
                    } else {
                        path = false;
                    }
                }
            }

            return movesList;
        }

        // Checks Rook Moves
        public List<(int, int)> CheckRook((int, int) position, string color)
        {
            List<(int, int)> movesList = new List<(int, int)>();

            List<(int, int)> enemiesList;
            List<(int, int)> friendsList;

            if (color == "white") {
                enemiesList = blackLocations;
                friendsList = whiteLocations;
            } else {
                friendsList = blackLocations;
                enemiesList = whiteLocations;
            }

            for (int i = 0; i < 4; i++) {
                bool path = true;
                int chain = 1;
                int x, y;
                if (i == 0) {
                    x = 0;
                    y = 1;
                } else if (i == 1) {
                    x = 0;
                    y = -1;
                } else if (i == 2) {
                    x = 1;
                    y = 0;
                } else {
                    x = -1;
                    y = 0;
                }

                while (path) {
                    int newX = position.Item1 + (chain * x);
                    int newY = position.Item2 + (chain * y);

                    if (!friendsList.Contains((newX, newY)) && newX >= 0 && newX <= 7 && newY >= 0 && newY <= 7) {
                        movesList.Add((newX, newY));

                        if (enemiesList.Contains((newX, newY))) {
                            path = false;
                        }

                        chain += 1;
                    } else {
                        path = false;
                    }
                }
            }

            return movesList;
        }

        // Check Pawn Moves
        public List<(int, int)> CheckPawn((int, int) position, string color)
        {
            List<(int, int)> movesList = new List<(int, int)> ();

            if (color == "white") {
                if (!whiteLocations.Contains((position.Item1, position.Item2 + 1)) &&
                    !blackLocations.Contains((position.Item1, position.Item2 + 1)) && position.Item2 < 7)
                {
                    movesList.Add((position.Item1, position.Item2 + 1));
                }
                if (!whiteLocations.Contains((position.Item1, position.Item2 + 2)) &&
                    !blackLocations.Contains((position.Item1, position.Item2 + 2)) && position.Item2 == 1)
                {
                    movesList.Add((position.Item1, position.Item2 + 2));
                }
                if (blackLocations.Contains((position.Item1 + 1, position.Item2 + 1)))
                {
                    movesList.Add((position.Item1 + 1, position.Item2 + 1));
                }
                if (blackLocations.Contains((position.Item1 - 1, position.Item2 + 1)))
                {
                    movesList.Add((position.Item1 - 1, position.Item2 + 1));
                }
                if ((position.Item1 + 1, position.Item2 + 1) == blackEp) {
                    movesList.Add((position.Item1 + 1, position.Item2 + 1));
                }
                if ((position.Item1 - 1, position.Item2 + 1) == blackEp) {
                    movesList.Add((position.Item1 - 1, position.Item2 + 1));
                }
            } else {
                if (!whiteLocations.Contains((position.Item1, position.Item2 - 1)) &&
                    !blackLocations.Contains((position.Item1, position.Item2 - 1)) && position.Item2 > 0)
                {
                    movesList.Add((position.Item1, position.Item2 - 1));
                }
                if (!whiteLocations.Contains((position.Item1, position.Item2 - 2)) &&
                    !blackLocations.Contains((position.Item1, position.Item2 - 2)) && position.Item2 == 6)
                {
                    movesList.Add((position.Item1, position.Item2 - 2));
                }
                if (whiteLocations.Contains((position.Item1 + 1, position.Item2 - 1)))
                {
                    movesList.Add((position.Item1 + 1, position.Item2 - 1));
                }
                if (whiteLocations.Contains((position.Item1 - 1, position.Item2 - 1)))
                {
                    movesList.Add((position.Item1 - 1, position.Item2 - 1));
                }
                if ((position.Item1 + 1, position.Item2 - 1) == whiteEp) {
                    movesList.Add((position.Item1 + 1, position.Item2 - 1));
                }
                if ((position.Item1 - 1, position.Item2 - 1) == whiteEp) {
                    movesList.Add((position.Item1 - 1, position.Item2 - 1));
                }
            }
            return movesList;
        }

        // Check Knight Moves
        public List<(int, int)> CheckKnight((int, int) position, string color) {
            List<(int, int)> movesList = new List<(int, int)>();

            List<(int, int)> enemiesList;
            List<(int, int)> friendsList;

            if (color == "white") {
                enemiesList = blackLocations;
                friendsList = whiteLocations;
            } else {
                friendsList = blackLocations;
                enemiesList = whiteLocations;
            }

            List<(int, int)> targets = new List<(int, int)> { (1, 2), (1, -2), (2, 1), (2, -1), (-1, 2), (-1, -2), (-2, 1), (-2, -1) };

            for (int i = 0; i < 8; i++) {
                (int, int) target = (position.Item1 + targets[i].Item1, position.Item2 + targets[i].Item2);

                if (!friendsList.Contains(target) && target.Item1 >= 0 && target.Item1 <= 7 && target.Item2 >= 0 && target.Item2 <= 7) {
                    movesList.Add(target);
                }
            }

            return movesList;
        }

        public (int, int) CheckEP((int, int) oldCoords, (int, int) newCoords)
        {
            (int, int) epCoords;
            string piece;
            if (currentTurnStep <= 1) {
                int index = whiteLocations.IndexOf(oldCoords);
                epCoords = (newCoords.Item1, newCoords.Item2 - 1);
                piece = whitePawns[index];
            } else {
                int index = blackLocations.IndexOf(oldCoords);
                epCoords = (newCoords.Item1, newCoords.Item2 + 1);
                piece = blackPawns[index];
            }
            if (piece == "pawn" && Math.Abs(oldCoords.Item2 - newCoords.Item2) > 1) {} 
            else {
                epCoords = (100, 100);
            }
            return epCoords;
        }

        private void Handle_Click(object sender, MouseEventArgs e)
        {
            int yCord = ( e.Y - yOffset ) / 75;
            int xCord= ( e.X - xOffset ) / 75 ;
            (int, int) clickCords = (xCord, yCord);
            Console.WriteLine($"{clickCords}");
            Console.WriteLine($"{currentTurnStep}");

            if (currentTurnStep <= 1) {
                if (whiteLocations.Contains(clickCords)) {
                    selection = whiteLocations.IndexOf(clickCords);
                    if (currentTurnStep == 0) {
                        currentTurnStep = 1;
                    }
                }

                if (validMoves.Contains(clickCords) && selection != 100) {
                    whiteEp = CheckEP(whiteLocations[selection], clickCords);
                    whiteLocations[selection] = clickCords;
                    if (blackLocations.Contains(clickCords)) {
                        int blackPiece = blackLocations.IndexOf(clickCords);
                        whiteCapturedPawns.Append(blackPawns[blackPiece]);
                        if (blackPawns[blackPiece] == "king") {
                            winner = "white";
                        }
                        blackPawns.RemoveAt(blackPiece);
                        blackLocations.RemoveAt(blackPiece);
                    }

                    if (clickCords == blackEp) {
                        int blackPiece = blackLocations.IndexOf((blackEp.Item1, blackEp.Item2 - 1));
                        whiteCapturedPawns.Append(blackPawns[blackPiece]);
                        blackPawns.RemoveAt(blackPiece);
                        blackLocations.RemoveAt(blackPiece);
                        // blackMoved.RemoveAt(blackPiece);
                    }
                    blackOptions = CheckOptions(blackPawns, blackLocations, "black");
                    whiteOptions = CheckOptions(whitePawns, whiteLocations, "white");
                    SwitchPlayerTurn();
                    currentTurnStep = 2;
                    selection = 100;
                    validMoves = new List<(int, int)>{};
                }
            }

            if (currentTurnStep > 1) {
                if (blackLocations.Contains(clickCords)) {
                    selection = blackLocations.IndexOf(clickCords);
                    if (currentTurnStep == 2)
                    {
                        currentTurnStep = 3;
                    }
                }

                if (validMoves.Contains(clickCords) && selection != 100) {
                    blackEp = CheckEP(blackLocations[selection], clickCords);
                    blackLocations[selection] = clickCords;
                    if (whiteLocations.Contains(clickCords)) {
                        int whitePiece = whiteLocations.IndexOf(clickCords);
                        blackCapturedPawns.Append(whitePawns[whitePiece]);
                        if (whitePawns[whitePiece] == "king") {
                            winner = "black";
                        }
                        whitePawns.RemoveAt(whitePiece);
                        whiteLocations.RemoveAt(whitePiece);
                    }

                    if (clickCords == whiteEp) {
                        int whitePiece = whiteLocations.IndexOf((whiteEp.Item1, whiteEp.Item2 + 1));
                        blackCapturedPawns.Append(whitePawns[whitePiece]);
                        whitePawns.RemoveAt(whitePiece);
                        whiteLocations.RemoveAt(whitePiece);
                        // whiteMoved.RemoveAt(whitePiece);
                    }

                    blackOptions = CheckOptions(blackPawns, blackLocations, "black");
                    whiteOptions = CheckOptions(whitePawns, whiteLocations, "white");
                    SwitchPlayerTurn();
                    currentTurnStep = 0;
                    selection = 100;
                    validMoves = new List<(int, int)> { };
                }
            }

            // Handle the click based on the row and column
            // MessageBox.Show($"({xCord}, {yCord})");
        }

        private void cross_Click(object sender, EventArgs e) {
                gameOn = false;
                Application.Exit();
            }
    }
}