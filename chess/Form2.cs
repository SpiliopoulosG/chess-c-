using System;
using System.Drawing;
using System.Windows.Forms;

namespace chess
{
    public partial class Form2 : Form
    {
        private bool isDragging = false;
        private PictureBox selectedPiece;
        private Point originalPosition;
        private PictureBox[,] chessboard;
        private int squareSize = 75; // Adjust the square size as needed
        private Chess chessGame;
        int xOffset = 25;    // Adjust based on the starting X position
        int yOffset = 38;    // Adjust based on the starting Y position
        private Player currentPlayer = Player.White; // Start with White player


        bool gameOn = true;

        string[] whitePawns = { };
        string[] blackPawns = { };
        string[] whiteCapturedPawns = { };
        string[] blackCapturedPawns = { };
        string[] startingPawns = { "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Knight", "Knight","Bishop", "Bishop", "King", " Queen", " Rook" , " Rook" };

        public static Form2 instance;
        public Label lab1;
        public Label lab2;
        public TextBox tb1;
        public TextBox tb2;       
        /////////////////////////////////////////////
        ////////////////// main /////////////////////
        /////////////////////////////////////////////
        public Form2()
        {
            chessGame = new Chess();
            chessGame.Chessboard = chessboard; // Assuming chessboard is properly initialized

            InitializeComponent();
            InitializeChessboard();
            instance = this;
            lab1 = Player1_Name;
            lab2 = Player2_Name;
         
            tb1 = Timer1;
            tb2 = Timer2;
            timer3.Start();
            blackTimer.Tick += blackTimer_Tick;
            whiteTimer.Tick += whiteTimer_Tick;
            whiteTimer.Start(); 
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
        private void SwitchPlayerTurn()
        {
            // Stop the timer for the current player
            if (currentPlayer == Player.White)
            {
                whiteTimer.Stop();  // Stop the timer for the white player
                blackTimer.Start(); // Start the timer for the black player
            }
            else
            {
                blackTimer.Stop();  // Stop the timer for the black player
                whiteTimer.Start(); // Start the timer for the white player
            }

            // Switch the player's turn
            currentPlayer = (currentPlayer == Player.White) ? Player.Black : Player.White;

            // Update the label to show the current player
            label2.Text = $"Current player: {(currentPlayer == Player.White ? "White" : "Black")}";
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
    

    private void InitializeChessboard()
        {
            chessboard = new PictureBox[8, 8];


            // Initialize chessboard PictureBox controls and add them to the form
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    chessboard[row, col] = new PictureBox();
                    chessboard[row, col].Size = new Size(squareSize, squareSize);
                    chessboard[row, col].Location = new Point(col * squareSize + xOffset, row * squareSize + yOffset);
                    chessboard[row, col].BorderStyle = BorderStyle.FixedSingle; // Optional


                    SetInitialTags(row, col);

                    this.Controls.Add(chessboard[row, col]);
                    
                }
            }


            // Black Pawns
            AddChessPiece(Piece.PawnB, 1, 0, Player.Black, 1, 0, false, false);
            AddChessPiece(Piece.PawnB, 1, 1, Player.Black, 1, 1, false, false);
            AddChessPiece(Piece.PawnB, 1, 2, Player.Black, 1, 2, false, false);
            AddChessPiece(Piece.PawnB, 1, 3, Player.Black, 1, 3, false, false);
            AddChessPiece(Piece.PawnB, 1, 4, Player.Black, 1, 4, false, false);
            AddChessPiece(Piece.PawnB, 1, 5, Player.Black, 1, 5, false, false);
            AddChessPiece(Piece.PawnB, 1, 6, Player.Black, 1, 6, false, false);
            AddChessPiece(Piece.PawnB, 1, 7, Player.Black, 1, 7, false, false);

            // Black Rooks
            AddChessPiece(Piece.RookB, 0, 0, Player.Black, 0, 0, false, false);
            AddChessPiece(Piece.RookB, 0, 7, Player.Black, 0, 7, false, false);

            // Black Knights
            AddChessPiece(Piece.KnightB, 0, 1, Player.Black, 0, 1, false, false);
            AddChessPiece(Piece.KnightB, 0, 6, Player.Black, 0, 6, false, false);

            // Black Bishops
            AddChessPiece(Piece.BishopB, 0, 2, Player.Black, 0, 2, false, false);
            AddChessPiece(Piece.BishopB, 0, 5, Player.Black, 0, 5, false, false);

            // Black Queen
            AddChessPiece(Piece.QueenB, 0, 3, Player.Black, 0, 3, false, false);

            // Black King
            AddChessPiece(Piece.KingB, 0, 4, Player.Black, 0, 4, false, false);

            // White Pawns
            AddChessPiece(Piece.PawnW, 6, 0, Player.White, 6, 0, false, false);
            AddChessPiece(Piece.PawnW, 6, 1, Player.White, 6, 1, false, false);
            AddChessPiece(Piece.PawnW, 6, 2, Player.White, 6, 2, false, false);
            AddChessPiece(Piece.PawnW, 6, 3, Player.White, 6, 3, false, false);
            AddChessPiece(Piece.PawnW, 6, 4, Player.White, 6, 4, false, false);
            AddChessPiece(Piece.PawnW, 6, 5, Player.White, 6, 5, false, false);
            AddChessPiece(Piece.PawnW, 6, 6, Player.White, 6, 6, false, false);
            AddChessPiece(Piece.PawnW, 6, 7, Player.White, 6, 7, false, false);

            // White Rooks
            AddChessPiece(Piece.RookW, 7, 0, Player.White, 7, 0, false, false);
            AddChessPiece(Piece.RookW, 7, 7, Player.White, 7, 7, false, false);

            // White Knights
            AddChessPiece(Piece.KnightW, 7, 1, Player.White, 7, 1, false, false);
            AddChessPiece(Piece.KnightW, 7, 6, Player.White, 7, 6, false, false);

            // White Bishops
            AddChessPiece(Piece.BishopW, 7, 2, Player.White, 7, 2, false, false);
            AddChessPiece(Piece.BishopW, 7, 5, Player.White, 7, 5, false, false);

            // White Queen
            AddChessPiece(Piece.QueenW, 7, 3, Player.White, 7, 3, false, false);

            // White King
            AddChessPiece(Piece.KingW, 7, 4, Player.White, 7, 4, false, false);

        }
        private void SetInitialTags(int row, int col)
        {
            // Set the initial tags for each square based on the starting positions
            if (row == 1)
            {
                // Black Pawns
                chessboard[row, col].Tag = GetChessPieceTag(Piece.PawnB, Player.Black, row, col, row, col, false, false);
            }
            else if (row == 6)
            {
                // White Pawns
                chessboard[row, col].Tag = GetChessPieceTag(Piece.PawnW, Player.White, row, col, row, col, false, false);
            }
            else if (row == 0)
            {
                // Black pieces (Rooks, Knights, Bishops, Queen, King)
                chessboard[row, col].Tag = GetBlackPieceTag(row, col);
            }
            else if (row == 7)
            {
                // White pieces (Rooks, Knights, Bishops, Queen, King)
                chessboard[row, col].Tag = GetWhitePieceTag(row, col);
            }
        }

        private ChessPiece GetBlackPieceTag(int row, int col)
        {
            // Set the initial tags for each black piece based on the starting positions
            switch (col)
            {
                case 0:
                    return GetChessPieceTag(Piece.RookB, Player.Black, row, col, row, col, false, false);
                case 1:
                    return GetChessPieceTag(Piece.KnightB, Player.Black, row, col, row, col, false, false);
                case 2:
                    return GetChessPieceTag(Piece.BishopB, Player.Black, row, col, row, col, false, false);
                case 3:
                    return GetChessPieceTag(Piece.QueenB, Player.Black, row, col, row, col, false, false);
                case 4:
                    return GetChessPieceTag(Piece.KingB, Player.Black, row, col, row, col, false, false);
                case 5:
                    return GetChessPieceTag(Piece.BishopB, Player.Black, row, col, row, col, false, false);
                case 6:
                    return GetChessPieceTag(Piece.KnightB, Player.Black, row, col, row, col, false, false);
                case 7:
                    return GetChessPieceTag(Piece.RookB, Player.Black, row, col, row, col, false, false);
                default:
                    return null;
            }
        }

        private ChessPiece GetWhitePieceTag(int row, int col)
        {
            // Set the initial tags for each white piece based on the starting positions
            switch (col)
            {
                case 0:
                    return GetChessPieceTag(Piece.RookW, Player.White, row, col, row, col, false, false);
                case 1:
                    return GetChessPieceTag(Piece.KnightW, Player.White, row, col, row, col, false, false);
                case 2:
                    return GetChessPieceTag(Piece.BishopW, Player.White, row, col, row, col, false, false);
                case 3:
                    return GetChessPieceTag(Piece.QueenW, Player.White, row, col, row, col, false, false);
                case 4:
                    return GetChessPieceTag(Piece.KingW, Player.White, row, col, row, col, false, false);
                case 5:
                    return GetChessPieceTag(Piece.BishopW, Player.White, row, col, row, col, false, false);
                case 6:
                    return GetChessPieceTag(Piece.KnightW, Player.White, row, col, row, col, false, false);
                case 7:
                    return GetChessPieceTag(Piece.RookW, Player.White, row, col, row, col, false, false);
                default:
                    return null;
            }
        }
        private void AddChessPiece(Piece pieceType, int row, int col, Player player, int endRow, int endCol, bool isCapture, bool isPromotion)
        {
            // Adjust the size of the chess pieces
            int pieceSize = 40; // Adjust the size as needed
            int spacing = 35;    // Adjust the spacing as needed
            Image pieceImage = GetChessPieceImage(pieceType); // Pass the Piece enum
            ChessPiece chessPiece = GetChessPieceTag(pieceType, player, row, col, endRow, endCol, isCapture, isPromotion);
            PictureBox piece = new PictureBox
            {
                Size = new Size(pieceSize, pieceSize),
                Location = new Point(col * (pieceSize + spacing) + xOffset + (spacing / 2), row * (pieceSize + spacing) + yOffset + (spacing / 2)),
                Image = pieceImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = chessPiece,
                BackColor = Color.Transparent
            };

            // Attach mouse events for dragging
            piece.MouseDown += ChessPiece_MouseDown;
            piece.MouseMove += ChessPiece_MouseMove;
            piece.MouseUp += ChessPiece_MouseUp;

            Controls.Add(piece);
            piece.BringToFront();
        }

        private Image GetChessPieceImage(Piece pieceType)
        {
            //einai mia switch gia na pernei appo to resource file tin katalili fotografia kai na tin epistrefei sto addpiece fun
            switch (pieceType)
            {
                case Piece.PawnB:
                    return Properties.Resources.PawnB;
                case Piece.RookB:
                    return Properties.Resources.RookB;
                case Piece.KnightB:
                    return Properties.Resources.KnightB;
                case Piece.BishopB:
                    return Properties.Resources.BishopB;
                case Piece.QueenB:
                    return Properties.Resources.QueenB;
                case Piece.KingB:
                    return Properties.Resources.KingB;
                case Piece.PawnW:
                    return Properties.Resources.PawnW;
                case Piece.RookW:
                    return Properties.Resources.RookW;
                case Piece.KnightW:
                    return Properties.Resources.KnightW;
                case Piece.BishopW:
                    return Properties.Resources.BishopW;
                case Piece.QueenW:
                    return Properties.Resources.QueenW;
                case Piece.KingW:
                    return Properties.Resources.KingW;
                default:
                    return null;
            }

        }
        private ChessPiece GetChessPieceTag(Piece pieceType, Player player, int startRow, int startCol, int endRow, int endCol, bool isCapture, bool isPromotion)
        {
            switch (pieceType)
            {
                case Piece.PawnB:
                case Piece.PawnW:
                    return new PawnMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                case Piece.RookB:
                case Piece.RookW:
                    return new RookMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                case Piece.KnightB:
                case Piece.KnightW:
                    return new KnightMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                case Piece.BishopB:
                case Piece.BishopW:
                    return new BishopMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                case Piece.QueenB:
                case Piece.QueenW:
                    return new QueenMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                case Piece.KingB:
                case Piece.KingW:
                    return new KingMove
                    {
                        Player = player,
                        StartRow = startRow,
                        StartCol = startCol,
                        EndRow = endRow,
                        EndCol = endCol,
                        IsCapture = isCapture,
                        IsPromotion = isPromotion
                    };
                default:
                    return null;
            }
        }

        private void ChessPiece_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPiece = sender as PictureBox;

                if (selectedPiece != null)
                {
                    isDragging = true;
                    originalPosition = selectedPiece.Location;
                    selectedPiece.BringToFront();
                }
            }
        }

        private void ChessPiece_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPiece != null)
            {
                selectedPiece.Left += e.X - (selectedPiece.Width / 2);
                selectedPiece.Top += e.Y - (selectedPiece.Height / 2);
            }
        }

        private void ChessPiece_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPiece != null)
            {
                isDragging = false;

                int row = -1;
                int col = -1;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chessboard[i, j].Bounds.IntersectsWith(selectedPiece.Bounds))
                        {
                            row = i;
                            col = j;
                            break;
                        }
                    }
                }

                if (row != -1 && col != -1)
                {
                    ChessPiece selectedChessPiece = (ChessPiece)selectedPiece.Tag;

                    // Check if the selected piece belongs to the current player
                    if (selectedChessPiece.Player == currentPlayer)
                    {
                        Console.WriteLine($"Player: {currentPlayer}, Piece Player: {selectedChessPiece.Player}, Row: {row}, Col: {col}");

                        if (ValidateMove(selectedPiece, row, col))
                        {
                            Console.WriteLine("Move is valid");
                            selectedChessPiece.StartRow = row;
                            selectedChessPiece.StartCol = col;
                           
                            chessboard[(int)(originalPosition.Y - yOffset) / squareSize, (int)(originalPosition.X - xOffset) / squareSize].Tag = null;
                            // Update Tag property of both source and destination PictureBox
                            selectedPiece.Tag = selectedChessPiece;
                            chessboard[row, col].Tag = selectedChessPiece;
                             

                            selectedPiece.Location = new Point(col * squareSize + xOffset + (squareSize - selectedPiece.Width) / 2, row * squareSize + yOffset + (squareSize - selectedPiece.Height) / 2);
                            SwitchPlayerTurn();
                            label2.Text = $"Current player: {(currentPlayer == Player.White ? "White" : "Black")}";
                        }
                        else
                        {
                            Console.WriteLine("Move is NOT valid");
                            selectedPiece.Location = originalPosition;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. It's not your turn.");
                        selectedPiece.Location = originalPosition;
                    }
                }
                else
                {
                    // Piece is outside the chessboard bounds, revert it to its original position
                    selectedPiece.Location = originalPosition;
                }
            }
        }
        private bool ValidateMove(PictureBox piece, int newRow, int newCol)
        {

            Console.WriteLine($"Checking move for piece at ({piece.Location.X}, {piece.Location.Y}) to ({newRow}, {newCol})");
            // Perform move validation based on the type of piece
            if (piece.Tag is PawnMove)
            {
                return ValidatePawnMove(piece, newRow, newCol);
  

            }
            else if (piece.Tag is KnightMove)
            {
                return ValidateKnightMove(piece, newRow, newCol);
            }
            else if (piece.Tag is BishopMove)
            {
                return ValidateBishopMove(piece, newRow, newCol);
            }
            else if (piece.Tag is RookMove)
            {
                return ValidateRookMove(piece, newRow, newCol);
            }
            else if (piece.Tag is QueenMove)
            {
                return ValidateQueenMove(piece, newRow, newCol);
            }
            else if (piece.Tag is KingMove)
            {
                return ValidateKingMove(piece, newRow, newCol);
            }
            

            // If no specific validation, consider the move as valid
            return true;
        }
        private void CapturePiece(int row, int col)
        {
            // Remove the captured piece from the chessboard
            // Remove the captured piece from the chessboard
            Console.WriteLine($"Capturing piece at ({row}, {col})");
            Console.WriteLine($"({chessboard[row, col]})");
            System.Windows.Forms.PictureBox piece = chessboard[row, col];
           
            piece.Image = null;
            this.Controls.Remove(piece);
            piece.Dispose();
            piece.Invalidate();
            this.Refresh();
           
           bool pictureboxincontrols = this.Controls.Contains(piece);
            Console.WriteLine($"({pictureboxincontrols})");

        }

        private bool ValidatePawnMove(PictureBox pawn, int newRow, int newCol)
        {
            PawnMove pawnMove = pawn.Tag as PawnMove;

            // Basic validation for pawn move
            int rowDiff = newRow - pawnMove.StartRow;
            int colDiff = Math.Abs(newCol - pawnMove.StartCol);

            // Validate based on player's turn
            if ((currentPlayer == Player.White && pawnMove.Player == Player.White) ||
                (currentPlayer == Player.Black && pawnMove.Player == Player.Black))
            {
                // Check if the destination square is occupied by a piece of the same player
                if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
                {
                    // Square is occupied by a piece of the same player
                    return false;
                }

                if (pawnMove.Player == Player.White)
                {
                    // White pawns move only forward
                    if (rowDiff == -1 && colDiff == 0 && chessboard[newRow, newCol].Tag == null)
                    {
                        if (newRow == 0)
                        {
                            HandlePromotion(pawnMove);
                            return true;
                        }
                        // Valid forward move
                        return true;
                    }

                    if (rowDiff == -1 && colDiff == 1 && chessboard[newRow, newCol].Tag != null)
                    {
                        ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                        
                        CapturePiece(newRow, newCol);
                        return true;
                    }

                    if (pawnMove.StartRow == 6 && rowDiff == -2 && colDiff == 0 && chessboard[newRow, newCol].Tag == null)
                    {
                        // Valid double forward move for the first move
                        return true;
                    }
                }
                else if (pawnMove.Player == Player.Black)
                {
                    // Black pawns move only forward
                    if (rowDiff == 1 && colDiff == 0 && chessboard[newRow, newCol].Tag == null)
                    {
                        if (newRow == 0)
                        {
                            HandlePromotion(pawnMove);
                            return true;
                        }
                        // Valid forward move
                        return true;
                    }

                    if (rowDiff == 1 && colDiff == 1 && chessboard[newRow, newCol].Tag != null)
                    {
                        // Valid diagonal capture
                        return true;
                    }

                    if (pawnMove.StartRow == 1 && rowDiff == 2 && colDiff == 0 && chessboard[newRow, newCol].Tag == null)
                    {
                        // Valid double forward move for the first move
                        return true;
                    }
                }
            }

            // Invalid move for the current player's turn
            return false;
        }
        private void HandlePromotion(PawnMove pawnMove)
        {
            // Show a dialog to let the user choose a piece type for promotion
            PromotionDialog promotionDialog = new PromotionDialog();
            if (promotionDialog.ShowDialog() == DialogResult.OK)
            {
                PieceType selectedPromotionPiece = promotionDialog.SelectedPieceType;
                // Update chessboard and pawn with the newly promoted piece
                chessGame.PromotePawn(pawnMove, selectedPromotionPiece);
                chessGame.UpdateChessboardUI(); // Update the UI after the promotion
            }
        }
        

        private bool ValidateKnightMove(PictureBox knight, int newRow, int newCol)
        {
            KnightMove knightMove = knight.Tag as KnightMove;
            // Check if the destination square is occupied by a piece of the same player


            if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
            {
                // Square is occupied by a piece of the same player
                return false;
            }

            if (chessboard[newRow, newCol].Tag != null)
            {
                // Square is occupied by an opponent!
                ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                return true;
            }
            int rowDiff = Math.Abs(newRow - knightMove.StartRow);
            int colDiff = Math.Abs(newCol - knightMove.StartCol);

            // Knights move in an "L" shape: two squares in one direction and one square perpendicular to that direction.
            return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
        }
        private bool ValidateBishopMove(PictureBox bishop, int newRow, int newCol)
        {
            BishopMove bishopMove = bishop.Tag as BishopMove;
            // Check if the destination square is occupied by a piece of the same player
            if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
            {
                // Square is occupied by a piece of the same player
                return false;
            }

            if (chessboard[newRow, newCol].Tag != null)
            {
                // Square is occupied by an opponent!
                ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                return true;
            }
            // Basic validation for bishop move
            int rowDiff = Math.Abs(newRow - bishopMove.StartRow);
            int colDiff = Math.Abs(newCol - bishopMove.StartCol);

            if (rowDiff != colDiff)
            {
                // Invalid diagonal move
                return false;
            }

            // Check for pieces in the bishop's path
            int rowDirection = Math.Sign(newRow - bishopMove.StartRow);
            int colDirection = Math.Sign(newCol - bishopMove.StartCol);

            for (int i = 1; i < rowDiff; i++)
            {
                int checkRow = bishopMove.StartRow + i * rowDirection;
                int checkCol = bishopMove.StartCol + i * colDirection;

                if (chessboard[checkRow, checkCol].Tag != null)
                {
                    // There is an obstacle in the path
                    return false;
                }

            }

            return true;
        }

        private bool ValidateRookMove(PictureBox rook, int newRow, int newCol)
        {
            RookMove rookMove = rook.Tag as RookMove;
            // Check if the destination square is occupied by a piece of the same player
            if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
            {
                // Square is occupied by a piece of the same player
                return false;
            }
            if (chessboard[newRow, newCol].Tag != null)
            {
                // Square is occupied by an opponent!
                ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                return true;
            }

            // Basic validation for rook move
            if (newRow != rookMove.StartRow && newCol != rookMove.StartCol)
            {
                // Rook can only move vertically or horizontally
                return false;
            }

            int rowDiff = Math.Abs(newRow - rookMove.StartRow);
            int colDiff = Math.Abs(newCol - rookMove.StartCol);

            // Check if there are any pieces in the path
            if (newRow != rookMove.StartRow)
            {
                // Moving vertically
                int start = Math.Min(newRow, rookMove.StartRow);
                int end = Math.Max(newRow, rookMove.StartRow);

                for (int i = start + 1; i < end; i++)
                {
                    if (chessboard[i, newCol].Tag != null)
                    {
                        // There is an obstacle in the path
                        return false;
                    }
                }
            }
            else if (newCol != rookMove.StartCol)
            {
                // Moving horizontally
                int start = Math.Min(newCol, rookMove.StartCol);
                int end = Math.Max(newCol, rookMove.StartCol);

                for (int i = start + 1; i < end; i++)
                {
                    if (chessboard[newRow, i].Tag != null)
                    {
                        // There is an obstacle in the path
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidateQueenMove(PictureBox queen, int newRow, int newCol)
        {
            QueenMove queenMove = queen.Tag as QueenMove;
            // Check if the destination square is occupied by a piece of the same player
            if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
            {
                // Square is occupied by a piece of the same player
                return false;
            }

            if (chessboard[newRow, newCol].Tag != null)
            {
                // Square is occupied by an opponent!
                ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                return true;
            }
            // Basic validation for queen move
            int rowDiff = Math.Abs(newRow - queenMove.StartRow);
            int colDiff = Math.Abs(newCol - queenMove.StartCol);

            if (rowDiff == colDiff || newRow == queenMove.StartRow || newCol == queenMove.StartCol)
            {
                // Queen can move diagonally or vertically/horizontally

                // Check for pieces in the queen's path
                int rowDirection = (newRow - queenMove.StartRow) / Math.Max(1, rowDiff);
                int colDirection = (newCol - queenMove.StartCol) / Math.Max(1, colDiff);

                for (int i = 1; i < Math.Max(rowDiff, colDiff); i++)
                {
                    int checkRow = queenMove.StartRow + i * rowDirection;
                    int checkCol = queenMove.StartCol + i * colDirection;

                    if (chessboard[checkRow, checkCol].Tag != null)
                    {
                        // There is an obstacle in the path
                        return false;
                    }
                }

                return true;
            }

            // Invalid move
            return false;
        
        }

        private bool ValidateKingMove(PictureBox king, int newRow, int newCol)
        {
            KingMove kingMove = king.Tag as KingMove;
            // Check if the destination square is occupied by a piece of the same player
            if (chessboard[newRow, newCol].Tag != null && ((ChessPiece)chessboard[newRow, newCol].Tag).Player == currentPlayer)
            {
                // Square is occupied by a piece of the same player
                return false;
            }

            if (chessboard[newRow, newCol].Tag != null)
            {

                // Square is occupied by an opponent!
                ((ChessPiece)chessboard[newRow, newCol].Tag).Capture();
                return true;
            }
            // Basic validation for king move (1 square in any direction)
            int rowDiff = Math.Abs(newRow - kingMove.StartRow);
            int colDiff = Math.Abs(newCol - kingMove.StartCol);

            return rowDiff <= 1 && colDiff <= 1;
        }
            
        public enum Player
        {
            White,
            Black
        }
        public enum Piece
        {
            PawnB,
            PawnW,
            KnightB,
            KnightW,
            BishopB,
            BishopW,
            KingB,
            KingW,
            QueenB,
            QueenW,
            RookB,
            RookW,
            None
        }
      
       
        public class ChessPiece
        {
            public void Capture()
            {
                IsCapture = true;
            }
            public Piece piece { get; set; }
            public Player Player { get; set; }
            public int StartRow { get; set; }
            public int StartCol { get; set; }
            public int EndRow { get; set; }
            public int EndCol { get; set; }
            public bool IsCapture { get; set; }
            public bool IsPromotion { get; set; }

        }
        public class PawnMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public PawnMove()
            {
                IsCapture = false;
            }
        }

        public class KnightMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public KnightMove()
            {
                IsCapture = false;
            }
        }

        public class BishopMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public BishopMove()
            {
                IsCapture = false;
            }
        }

        public class RookMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public RookMove()
            {
                IsCapture = false;
            }
        }

        public class QueenMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public QueenMove()
            {
                IsCapture = false;
            }
        }

        public class KingMove : ChessPiece
        {
            // Add this constructor to initialize IsCapture
            public KingMove()
            {
                IsCapture = false;
            }
        }

    }
}