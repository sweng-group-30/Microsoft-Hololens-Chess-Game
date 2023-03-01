using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayer 
{

    public TeamColor team { get; set; }
	public Board board { get; set; }
	public List<Piece> activePieces { get; private set; }
    public List<Piece> takenPieces { get; private set; } // pieces the player has taken from other team

	public King king{get;set;}

	public ChessPlayer(TeamColor team, Board board)
	{
		activePieces = new List<Piece>();
		this.board = board;
		this.team = team;
		this.king = null;
	}
    public void AddPiece(Piece piece)
	{
		if (!activePieces.Contains(piece))
			activePieces.Add(piece);
	}

	public void RemovePiece(Piece piece)
	{
		if (activePieces.Contains(piece))
			activePieces.Remove(piece);
	}

	public King getKing() {
		return this.king;
	}

	public void setKing(King k) {
		this.king = k;
	}

    public TeamColor getTeam() {
        return this.team;
    }

    public void AddToTakenPieces(Piece piece) {
        takenPieces.Add(piece);
    }
}
