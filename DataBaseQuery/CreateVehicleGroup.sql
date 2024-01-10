CREATE TABLE VehicleGroup (
VehicleGroupID INT IDENTITY(1,1) PRIMARY KEY,
HeroId INT,
Type VARCHAR(50),
VehicleName VARCHAR(50),
Image VARCHAR(50),
Id VARCHAR(50),
Kills INT,
Damage INT,
Roadkills INT,
Spawns INT,
DriverAssists INT,
PassengerAssists INT,
MultiKills INT,
DistanceTraveled DECIMAL,
KillsPerMinute INT,
VehiclesDestroyedWith INT,
Assists INT,
CallIns INT,
DamageTo INT,
Destroyed INT,
Timeln INT
CONSTRAINT fk_VehicleGroup_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
