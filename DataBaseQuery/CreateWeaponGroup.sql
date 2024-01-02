CREATE TABLE WeaponGroup (
WeaponGroupID INT PRIMARY KEY,
HeroId INT,
Type VARCHAR(50),
GroupName VARCHAR(50),
Id VARCHAR(50),
Kills INT,
Damage INT,
BodyKills INT,
HeadshotKills INT,
HipfireKills INT,
MultiKills INT,
Accuracy DECIMAL(10,2),
KillsPerMinute DECIMAL(10,2),
DamagePerMinute DECIMAL(10,2),
Headshots DECIMAL(10,2),
HitVKills DECIMAL(10,2),
ShotsHit INT,
ShotsFired INT,
Spawns INT,
TimeEquipped INT
CONSTRAINT fk_WeaponGroup_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);