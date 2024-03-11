using Godot;
using System;
public partial class HUD : CanvasLayer
{
	public void UpdateScore(int score){
		GetNode<Label>("ScoreLabel").Text = "Score: "+score;
	}

	public void ShowMessage(string message)
	{
		GetNode<Label>("Title").Text = message;
	}

	public void TitleScreen()
	{
		ShowMessage("Retrieve The Gems");
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Label>("FinalScore").Hide();
		GetNode<Label>("Title").Show();
	}

	public void StartGame()
	{
		UpdateScore(0);
		GetNode<Label>("ScoreLabel").Show();
		GetNode<Label>("Title").Hide();
		GetNode<Label>("FinalScore").Hide();
	}

	public void FinalScore(int score)
	{
		GetNode<Label>("FinalScore").Show();
		GetNode<Label>("FinalScore").Text = "Final Score\n"+score;
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Label>("Title").Hide();
	}
}
