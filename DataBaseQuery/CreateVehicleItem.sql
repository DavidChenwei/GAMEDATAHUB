CREATE TABLE VehicleItem (
  VehicleItemId INT IDENTITY(1,1) PRIMARY KEY,
  VehicleID INT,
  HeroId INT,
  Kills INT,
  Damage INT,
  Roadkills INT,
  Spawns INT,
  DriverAssists INT,
  PassengerAssists INT,
  Multikills INT,
  DistanceTraveled INT,
  KillsPerMinute DECIMAL(10,2),
  VehiclesDestroyedWith INT,
  Assists INT,
  Callins INT,
  DamageTo INT,
  Destroyed INT,
  Timeln INT,
  FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID),
  FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
