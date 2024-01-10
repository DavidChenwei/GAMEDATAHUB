CREATE TABLE SpecialistItem (
    SpecialistItemID INT IDENTITY(1,1) PRIMARY KEY,
    SpecialistID INT,
    HeroId INT,
    Kills INT,
    Deaths INT,
    KMP DECIMAL,
    Spawns INT,
    KillDeath DECIMAL,
    Revives INT,
    Assists INT,
    HazardZoneStreaks INT,
    SecondsPlayed INT,
	CONSTRAINT fk_SpecialistItem_GamemodeID FOREIGN KEY (SpecialistID) REFERENCES Specialist(SpecialistID),
	CONSTRAINT fk_SpecialistItem_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
