CREATE TABLE MapItem (
  MapItemId INT IDENTITY(1,1) PRIMARY KEY,
  MapId INT NOT NULL,
  HeroId INT NOT NULL,
  Wins INT,
  Losses INT,
  Matches INT,
  WinPercent DECIMAL,
  SecondsPlayed INT,
  FOREIGN KEY (MapId) REFERENCES Map(MapId),
  FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
