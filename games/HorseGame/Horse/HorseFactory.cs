using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace miniGames.games.HorseGame.Horses {
	public static class HorseFactory {

		public static Horse MakeHorse() {

			var rnd = new Random();

			var name = CreateName(rnd.Next(0, 100));
			var breed = CreateBreed(rnd.Next(0, 100));
			var color = CreateColor(rnd.Next(0, 100));
			var age = rnd.Next(2, 5);
			var gender = CreateGender(rnd.Next(0, 100), age);
			var racingQuality = CreateRacingQuality(rnd.Next(0, 100));

			var horse = new Horse(name, breed, color, gender, age, racingQuality);
			return horse;
		}

		private static string CreateName(int rnd) {
			var name = "";

			if (rnd == 100) { name = "Lucky"; }
			else if (rnd > 90) { name = "Rosie"; }
			else if (rnd > 60) { name = "Mac"; }
			else if (rnd > 30) { name = "Charlie"; }
			else if (rnd > 0) { name = "Ruby"; }
			else if (rnd == 0) { name = "Unlucky"; }

			return name;
		}

		private static string CreateBreed(int rnd) {
			var breed = "";

			if (rnd == 100) { breed = "Akhal Teke Horse"; }
			else if (rnd > 90) { breed = "Andalusian Horse"; }
			else if (rnd > 60) { breed = "Appaloosa Horse"; }
			else if (rnd > 30) { breed = "Arabian Horse"; }
			else if (rnd > 0) { breed = "Black Forest Horse"; }
			else if (rnd == 0) { breed = "Tennessee Walker"; }

			return breed;
		}

		public static string CreateColor(int rnd) {
			var color = "";

			if (rnd == 100) { color = "White"; }
			else if (rnd > 90) { color = "Black"; }
			else if (rnd > 60) { color = "Brown"; }
			else if (rnd > 30) { color = "Beige"; }
			else if (rnd > 0) { color = "Spotted"; }
			else if (rnd == 0) { color = "Metallic"; }

			return color;
		}

		private static string CreateGender(int rnd, int age) {
			var gender = "";

			if(rnd > 40) 
			{
				if(age > 4) { gender = "Stalion"; } 
				else { gender = "Colt"; }
			}
			else 
			{ 
				if(age > 4) { gender = "Mare"; } 
				else { gender = "Filly"; }
			}

			return gender;
		}

		private static int CreateRacingQuality(int rnd) {
			return 2;
		}
	}
}
