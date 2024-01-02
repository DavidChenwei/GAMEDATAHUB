CREATE TABLE GadgetItem (
  GadgetItemId INT PRIMARY KEY,
  GadgetId INT,
  HeroId INT,
  Kills INT,
  Spawns INT,
  Damage INT,
  Uses INT,
  Multikills INT,
  VehiclesDestroyedWith INT,
  KPM DECIMAL,
  DPM DECIMAL,
  SecondsPlayed INT,
  CONSTRAINT fk_GadgetItem_GadgetId FOREIGN KEY (GadgetId) REFERENCES Gadget(GadgetID),
  CONSTRAINT fk_GadgetItem_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
