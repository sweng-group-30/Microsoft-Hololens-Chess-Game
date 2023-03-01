using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public bool isInCheck{ get; set; }
    public override List<Vector2Int> SelectAvaliableSquares()
    {
        throw new NotImplementedException();
    }

    public bool getInCheck() {
        return this.isInCheck;
    }

    public void setInCheck(bool val) {
        this.isInCheck = val;
    }

    public bool canMoveThere(Vector2Int coords) {
        if (isInCheckAtCoords(coords)) {
            return false;
        }
		Piece temp = board.getPiece(coords);
        if (temp && temp != this) {
            if (temp.IsFromSameTeam(this)) {
                return false;
            }
            return true;
        }
        return true;
	}

    public override bool isAttackingSquare(Vector2Int coords) {
        if (coords.x - this.occupiedSquare.x <= 1 && coords.x - this.occupiedSquare.x >= -1 &&
             coords.y - this.occupiedSquare.y <= 1 && coords.y - this.occupiedSquare.y >= -1) {
                return true;
        }
            return false;
    }

    public bool isInCheckAtCoords(Vector2Int coords){
        foreach (Piece p in this.controller.getOpposingPlayer(this.team).activePieces) {
            if (p.isAttackingSquare(coords)) {
                return true;
            }
        }
        return false;
    }

    public override void MovePiece(Vector2Int coords)
    {
        if (this.getTeam() == controller.getActivePlayer().getTeam())
        {
            if ((coords.x - this.occupiedSquare.x <= 1 & coords.x - this.occupiedSquare.x >= -1 &
             coords.y - this.occupiedSquare.y <= 1 & coords.y - this.occupiedSquare.y >= -1) && canMoveThere(coords))
            {
                Piece pieceCheck = board.getPiece(coords);
                if (pieceCheck)
                {
                    board.takePiece(this, coords);
                }
                this.occupiedSquare = coords;
                transform.position = this.board.CalculatePositionFromCoords(coords);
                controller.endTurn();
            }
            else
            {
                transform.position = this.board.CalculatePositionFromCoords(this.occupiedSquare);
            }
        } else
        {
            // If not this team's turn, snap back to occupied square
            transform.position = this.board.CalculatePositionFromCoords(this.occupiedSquare);
            Debug.Log("NoMoving!");
        }
    }

    public override void PossibleMoves()
    {
        avaliableMoves.Clear();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Vector2Int square = new Vector2Int(i, j); // this is to go through all the squares checking which are safe to move to
                if (squareIsMoveable(square) && canMoveThere(square) && square != this.occupiedSquare) // this should be implemented when the obj is picked up to highlight the possible squares. 
                {
                    avaliableMoves.Add(square);
                }
            }
        }
    }

    private bool squareIsMoveable(Vector2Int square)
    {
        if ((square.x - this.occupiedSquare.x <= 1 & square.x - this.occupiedSquare.x >= -1 &
        square.y - this.occupiedSquare.y <= 1 & square.y - this.occupiedSquare.y >= -1))
        {
            Debug.Log("Turn Green");
            return true;
        }


        return false;
    }

}