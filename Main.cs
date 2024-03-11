using Godot;
using System;

public partial class Main : Node2D
{
	[Export]
	public Label label { get; set; }

	Player player;
	Map map;
	HUD hud;
	bool hasGem = false;
	int score = 0;
	int gemGathered = 0;
	bool gameRunning = false;
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		map = GetNode<Map>("Map");
		hud = GetNode<HUD>("HUD");

		hud.TitleScreen();
	}

	public void StartGame()
	{
		hasGem = false;
		score = 0;
		gemGathered = 0;
		gameRunning = true;
		player.currentPos[0] = 0;
		player.currentPos[1] = 0;
		player.UpdatePos();

		hud.StartGame();
		map.Initialize();
	}

	public void EndGame()
	{
		hud.FinalScore(score);
		hasGem = false;
		score = 0;
		gameRunning = false;

		
	}

	public void UpdateGame(int[] previousPos, int[] newPos)
	{
		if (gameRunning)
		{
			GD.Print("Update Game");
			score -= 1;
			GD.Print(previousPos[0], " ", previousPos[1], " - ", newPos[0], " ", newPos[1]);


			if (newPos[0] >= map.sizeX || newPos[0] < 0 || newPos[1] >= map.sizeY || newPos[1] < 0)
			{
				player.currentPos = previousPos;
				player.UpdatePos();
				newPos = previousPos;
			}

			if (map.mapValue[newPos[0]][newPos[1]] == 1)
			{
				newPos = previousPos;
				player.currentPos = previousPos;
				player.UpdatePos();
			}

			if (map.mapValue[newPos[0]][newPos[1]] == 2)
			{
				if (hasGem)
				{
					newPos = previousPos;
					player.currentPos = previousPos;
					player.UpdatePos();
				}
				else
				{
					score += 26;
					hasGem = true;
					player.sprite.Texture = (Texture2D)ResourceLoader.Load("res://Sprites/playerGem.png");
					map.DestroyWall(newPos[0], newPos[1]);

				}

			}

			if (newPos[0] == 0 && newPos[1] == 0)
			{
				if (hasGem)
				{
					score += 26;
					hasGem = false;
					player.sprite.Texture = (Texture2D)ResourceLoader.Load("res://Sprites/player.png");
					gemGathered++;
				}
				if (gemGathered >= map.gemNumber)
				{
					EndGame();
				}
			}
			hud.UpdateScore(score);
		}
		

	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("start_game"))
		{
			if (!gameRunning)
			{
				StartGame();
			}
		}
	}
}

