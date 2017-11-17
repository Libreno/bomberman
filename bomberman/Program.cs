using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBattleNetLibrary;

namespace bomberman
{
	internal static class Program
	{
		private static void Main()
		{
			var r = new Random();
			var gcb = new GameClientBomberman("52.232.32.105:8080", "libreno@gmail.com", "sdsgsdg13!$");
		    var bombCountDown = -1;
			gcb.Run(() =>
			{
				var done = false;
                switch (r.Next(5))
				{
					case 0:
						if (!IsBlock(gcb.Map[gcb.PlayerX, gcb.PlayerY - 1]))
						{
							gcb.Up(BombAction.BeforeTurn);
							done = true;
						}
						break;
					case 1:
						if (!IsBlock(gcb.Map[gcb.PlayerX + 1, gcb.PlayerY]))
						{
							gcb.Right(BombAction.BeforeTurn);
							done = true;
						}
						break;
					case 2:
						if (!IsBlock(gcb.Map[gcb.PlayerX, gcb.PlayerY + 1]))
						{
							gcb.Down(BombAction.BeforeTurn);
							done = true;
						}
						break;
					case 3:
						if (!IsBlock(gcb.Map[gcb.PlayerX - 1, gcb.PlayerY]))
						{
							gcb.Left(BombAction.BeforeTurn);
							done = true;
						}
						break;
					case 4:
						gcb.Act();
						done = true;
						break;
				}
				if (done == false)
					gcb.Blank();
			});

			Console.ReadKey();
		}

		private static bool IsBlock(BombermanBlocks block) =>
			block == BombermanBlocks.Wall ||
			block == BombermanBlocks.WallDestroyable ||
			block == BombermanBlocks.MeatChopper ||
			block == BombermanBlocks.BombTimer1 ||
			block == BombermanBlocks.BombTimer2 ||
			block == BombermanBlocks.BombTimer3 ||
			block == BombermanBlocks.BombTimer4 ||
			block == BombermanBlocks.BombTimer5 ||
			block == BombermanBlocks.OtherBomberman ||
			block == BombermanBlocks.BombBomberman ||
            block == BombermanBlocks.OtherBombBomberman;
	}
}
