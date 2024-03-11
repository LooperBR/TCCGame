using Godot;
using System;
using System.Collections.Generic;

public partial class Map : TileMap
{
	public int sizeX=16;
	public int sizeY=16;
	public int gemNumber = 2;
	public List<List<int>> mapValue = new List<List<int>>();
	public List<(int,int)> floors = new List<(int, int)>();
	public override void _Ready()
	{
		//Initialize();
	}

	public void Initialize()
	{
		GD.Randomize();

		int[] list1 = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list2 = new int[16] { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list3 = new int[16] { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list4 = new int[16] { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list5 = new int[16] { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list6 = new int[16] { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 };
		int[] list7 = new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 };
		int[] list8 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		int[] list9 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list10 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list11 = new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
		int[] list12 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list13 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list14 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list15 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
		int[] list16 = new int[16] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };

		int[][] lists = new int[][] { list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16 };

		for (int x = 0; x < sizeX; x++)
		{
			mapValue.Add(new List<int>());
			for (int y = 0; y < sizeY; y++)
			{
				mapValue[x].Add(lists[x][y]);
				if (lists[x][y] == 0 && (x != 0 || y != 0))
				{
					floors.Add((x, y));
				}
			}
		}


		//for (int x = 0; x < sizeX; x++)
		//{
		//	mapValue.Add(new List<int>());
		//}
		//for (int x = 0; x < sizeX; x++)
		//{
		//	for (int y = 0; y < sizeY; y++)
		//	{
		//		int valor = (int)(GD.Randi() % 2);
		//		mapValue[x].Add(valor);
		//		if (valor == 0)
		//		{
		//			floors.Add((x, y));

		//		}
		//	}
		//}

		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
			{
				if (mapValue[x][y] == 0)
				{
					SetCell(1, new Vector2I(x, y), 0, new Vector2I(4, 5));
				}
				else if (mapValue[x][y] == 1)
				{
					SetCell(0, new Vector2I(x, y), 0, new Vector2I(1, 1));
					SetCell(1, new Vector2I(x, y), 0, new Vector2I(3, 5));
				}

			}
		}

		for (int i = 0; i < gemNumber; i++)
		{
			int randomFloorNumber = (int)(GD.Randi() % floors.Count);
			(int, int) randomFloor = floors[randomFloorNumber];
			mapValue[randomFloor.Item1][randomFloor.Item2] = 2;
			SetCell(0, new Vector2I(randomFloor.Item1, randomFloor.Item2), 0, new Vector2I(5, 1));
			floors.RemoveAt(randomFloorNumber);
		}

		SetCell(0, new Vector2I(0, 0), 0, new Vector2I(5, 5));

	}

	public void DestroyWall(int x,int y)
	{
		EraseCell(0, new Vector2I(x, y));
		mapValue[x][y] = 0;
	}
}
