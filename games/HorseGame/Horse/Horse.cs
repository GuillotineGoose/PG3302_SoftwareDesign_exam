using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGames.games.HorseGame.Horses {
	public class Horse {
		private string _name;
		private string _breed;
		private string _color;
		private string _gender;
		private int _age;
		private int _racingQuality;

		public Horse(string name, string breed, string color, string gender, int age, int racingQuality) {
			_name = name;
			_breed = breed;
			_color = color;
			_gender = gender;
			_age = age;
			_racingQuality = racingQuality;
		}

		public string GetName() {
			return _name;
		}

		public bool Race() {
			//do the racing calculations
			return true;
		}

		public string ShowHorse() {
			var horse = " - NAME: " + _name + "\n" +
				" - BREED: " + _breed + "\n" +
				" - COLOR: " + _color + "\n" +
				" - AGE: " + _age + "\n" +
				" - GENDER: " + _gender + "\n" +
				" - QUALITY: " + _racingQuality + "%" + "\n";

			return horse;
		} 
	}
}
