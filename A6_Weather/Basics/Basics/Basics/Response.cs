using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Basics
{
	public class FiveDays 
	{
	[XmlRoot(ElementName="location")]
	public class Location {
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
		[XmlElement(ElementName="country")]
		public string Country { get; set; }
		[XmlElement(ElementName="timezone")]
		public string Timezone { get; set; }
	}

	[XmlRoot(ElementName="meta")]
	public class Meta {
		[XmlElement(ElementName="lastupdate")]
		public string Lastupdate { get; set; }
		[XmlElement(ElementName="calctime")]
		public string Calctime { get; set; }
		[XmlElement(ElementName="nextupdate")]
		public string Nextupdate { get; set; }
	}

	[XmlRoot(ElementName="sun")]
	public class Sun {
		[XmlAttribute(AttributeName="rise")]
		public string Rise { get; set; }
		[XmlAttribute(AttributeName="set")]
		public string Set { get; set; }
	}

	[XmlRoot(ElementName="symbol")]
	public class Symbol {
		[XmlAttribute(AttributeName="number")]
		public string Number { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="var")]
		public string Var { get; set; }
	}

	[XmlRoot(ElementName="windDirection")]
	public class WindDirection {
		[XmlAttribute(AttributeName="deg")]
		public string Deg { get; set; }
		[XmlAttribute(AttributeName="code")]
		public string Code { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="windSpeed")]
	public class WindSpeed {
		[XmlAttribute(AttributeName="mps")]
		public string Mps { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="temperature")]
	public class Temperature {
		[XmlAttribute(AttributeName="day")]
		public string Day { get; set; }
		[XmlAttribute(AttributeName="min")]
		public string Min { get; set; }
		[XmlAttribute(AttributeName="max")]
		public string Max { get; set; }
		[XmlAttribute(AttributeName="night")]
		public string Night { get; set; }
		[XmlAttribute(AttributeName="eve")]
		public string Eve { get; set; }
		[XmlAttribute(AttributeName="morn")]
		public string Morn { get; set; }
	}

	[XmlRoot(ElementName="pressure")]
	public class Pressure {
		[XmlAttribute(AttributeName="unit")]
		public string Unit { get; set; }
		[XmlAttribute(AttributeName="value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName="humidity")]
	public class Humidity {
		[XmlAttribute(AttributeName="value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName="unit")]
		public string Unit { get; set; }
	}

	[XmlRoot(ElementName="clouds")]
	public class Clouds {
		[XmlAttribute(AttributeName="value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName="all")]
		public string All { get; set; }
		[XmlAttribute(AttributeName="unit")]
		public string Unit { get; set; }
	}

	[XmlRoot(ElementName="time")]
	public class Time {
		[XmlElement(ElementName="symbol")]
		public Symbol Symbol { get; set; }
		[XmlElement(ElementName="windDirection")]
		public WindDirection WindDirection { get; set; }
		[XmlElement(ElementName="windSpeed")]
		public WindSpeed WindSpeed { get; set; }
		[XmlElement(ElementName="temperature")]
		public Temperature Temperature { get; set; }
		[XmlElement(ElementName="pressure")]
		public Pressure Pressure { get; set; }
		[XmlElement(ElementName="humidity")]
		public Humidity Humidity { get; set; }
		[XmlElement(ElementName="clouds")]
		public Clouds Clouds { get; set; }
		[XmlAttribute(AttributeName="day")]
		public string Day { get; set; }
		[XmlElement(ElementName="precipitation")]
		public Precipitation Precipitation { get; set; }
	}

	[XmlRoot(ElementName="precipitation")]
	public class Precipitation {
		[XmlAttribute(AttributeName="value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="forecast")]
	public class Forecast {
		[XmlElement(ElementName="time")]
		public List<Time> Time { get; set; }
	}

	[XmlRoot(ElementName="weatherdata")]
	public class Weatherdata {
		[XmlElement(ElementName="location")]
		public Location Location { get; set; }
		[XmlElement(ElementName="credit")]
		public string Credit { get; set; }
		[XmlElement(ElementName="meta")]
		public Meta Meta { get; set; }
		[XmlElement(ElementName="sun")]
		public Sun Sun { get; set; }
		[XmlElement(ElementName="forecast")]
		public Forecast Forecast { get; set; }
	}
	}

	public class OneDay 
	{
		[XmlRoot(ElementName="coord")]
		public class Coord {
			[XmlAttribute(AttributeName="lon")]
			public string Lon { get; set; }
			[XmlAttribute(AttributeName="lat")]
			public string Lat { get; set; }
		}

		[XmlRoot(ElementName="sun")]
		public class Sun {
			[XmlAttribute(AttributeName="rise")]
			public string Rise { get; set; }
			[XmlAttribute(AttributeName="set")]
			public string Set { get; set; }
		}

		[XmlRoot(ElementName="city")]
		public class City {
			[XmlElement(ElementName="coord")]
			public Coord Coord { get; set; }
			[XmlElement(ElementName="country")]
			public string Country { get; set; }
			[XmlElement(ElementName="sun")]
			public Sun Sun { get; set; }
			[XmlAttribute(AttributeName="id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName="name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName="temperature")]
		public class Temperature {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="min")]
			public string Min { get; set; }
			[XmlAttribute(AttributeName="max")]
			public string Max { get; set; }
			[XmlAttribute(AttributeName="unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName="humidity")]
		public class Humidity {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName="pressure")]
		public class Pressure {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName="speed")]
		public class Speed {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName="direction")]
		public class Direction {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="code")]
			public string Code { get; set; }
			[XmlAttribute(AttributeName="name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName="wind")]
		public class Wind {
			[XmlElement(ElementName="speed")]
			public Speed Speed { get; set; }
			[XmlElement(ElementName="direction")]
			public Direction Direction { get; set; }
		}

		[XmlRoot(ElementName="clouds")]
		public class Clouds {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName="precipitation")]
		public class Precipitation {
			[XmlAttribute(AttributeName="mode")]
			public string Mode { get; set; }
		}

		[XmlRoot(ElementName="weather")]
		public class Weather {
			[XmlAttribute(AttributeName="number")]
			public string Number { get; set; }
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="icon")]
			public string Icon { get; set; }
		}

		[XmlRoot(ElementName="lastupdate")]
		public class Lastupdate {
			[XmlAttribute(AttributeName="value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName="unix")]
			public string Unix { get; set; }
		}

		[XmlRoot(ElementName="item")]
		public class Item {
			[XmlElement(ElementName="city")]
			public City City { get; set; }
			[XmlElement(ElementName="temperature")]
			public Temperature Temperature { get; set; }
			[XmlElement(ElementName="humidity")]
			public Humidity Humidity { get; set; }
			[XmlElement(ElementName="pressure")]
			public Pressure Pressure { get; set; }
			[XmlElement(ElementName="wind")]
			public Wind Wind { get; set; }
			[XmlElement(ElementName="clouds")]
			public Clouds Clouds { get; set; }
			[XmlElement(ElementName="precipitation")]
			public Precipitation Precipitation { get; set; }
			[XmlElement(ElementName="weather")]
			public Weather Weather { get; set; }
			[XmlElement(ElementName="lastupdate")]
			public Lastupdate Lastupdate { get; set; }
		}

		[XmlRoot(ElementName="list")]
		public class List {
			[XmlElement(ElementName="item")]
			public Item Item { get; set; }
		}

		[XmlRoot(ElementName="cities")]
		public class Cities {
			[XmlElement(ElementName="calctime")]
			public string Calctime { get; set; }
			[XmlElement(ElementName="count")]
			public string Count { get; set; }
			[XmlElement(ElementName="mode")]
			public string Mode { get; set; }
			[XmlElement(ElementName="list")]
			public List List { get; set; }
		}
	}
}


