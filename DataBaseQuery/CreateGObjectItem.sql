CREATE TABLE GObjectItem (
    GObjectItemId INT PRIMARY KEY,
    HeroId INT,
    GObjectID INT,
    Total INT,
    Attacked INT,
    Defended INT,
    CONSTRAINT fk_GObjectItem_GObjectID FOREIGN KEY (GObjectID) REFERENCES GObject(GObjectID),
    CONSTRAINT fk_GObjectItem_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);
