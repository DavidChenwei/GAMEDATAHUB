CREATE TABLE RibbonItem (
    RibbonItemID INT IDENTITY(1,1) PRIMARY KEY,
    RibbonID INT,
    HeroId INT,
    Amount INT,
	CONSTRAINT fk_RibbonItem_RibbonID FOREIGN KEY (RibbonID) REFERENCES Ribbon(RibbonID),
	CONSTRAINT fk_RibbonItem_HeroId FOREIGN KEY (HeroId) REFERENCES Hero(HeroId)
);