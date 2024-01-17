DECLARE @RowCount DECIMAL(4,2);
SELECT @RowCount = CONVERT(DECIMAL(4,2), COUNT(*)) FROM HeroOverView;

MERGE INTO Rank AS target
USING (
    SELECT
        h.HeroID,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.KillDeath DESC))/@RowCount AS KDRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.HeadShotrate DESC))/@RowCount AS HSRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.WinPercent DESC))/@RowCount AS WinPercentRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.HumanPercentage DESC))/@RowCount AS HumanKDRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.Deaths DESC))/@RowCount AS DeathsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.KillsPerMinute DESC))/@RowCount AS KPMRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.KillsPerMatch DESC))/@RowCount AS KPMatchRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.Wins DESC))/@RowCount AS WinsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.Losses ASC))/@RowCount AS LossesRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.Damage DESC))/@RowCount AS DamageRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.DamagePerMinute DESC))/@RowCount AS DPMRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY h.VehiclesDestroyed DESC))/@RowCount AS VehiclesDestroyedRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.HeadShotAmount DESC))/@RowCount AS HeadShotAmountRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.RoadKills DESC))/@RowCount AS RoadKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.MeleeKills DESC))/@RowCount AS MeleeKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.VechileKills DESC))/@RowCount AS VechileKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.ScopedKills DESC))/@RowCount AS ScopedKills,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.HipfireKills DESC))/@RowCount AS HipfireKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.HumanKills DESC))/@RowCount AS HumanKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY d.AIKills DESC))/@RowCount AS AIKillsRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.ObjectTotal DESC))/@RowCount AS ObjectTotalRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.Defused DESC))/@RowCount AS DefusedRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.Captured DESC))/@RowCount AS CapturedObjectiRankRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.Neutralized DESC))/@RowCount AS NeutralizedRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.DefendedSector DESC))/@RowCount AS DefendedSectorRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.AttackedSector DESC))/@RowCount AS AttackedSectorRanking,
        CONVERT(DECIMAL(4,2), RANK() OVER (ORDER BY g.AttackedTotal DESC))/@RowCount AS AttackedTotalRanking
    FROM HeroOverView AS h
    JOIN GObject AS g ON h.HeroID = g.HeroID
    JOIN DividedKills AS d ON h.HeroID = d.HeroID
) AS source
ON target.HeroID = source.HeroID
WHEN MATCHED THEN
    UPDATE SET
        KDRank = source.KDRanking,
        HSRank = source.HSRanking,
        WinPercentRank = source.WinPercentRanking,
        HumanKDRank = source.HumanKDRanking,
        DeathRank = source.DeathsRanking,
        KPMRank = source.KPMRanking,
        KPMatchRank = source.KPMatchRanking,
        WinRank = source.WinsRanking,
        LostRank = source.LossesRanking,
        DamageRank = source.DamageRanking,
        DPMRank = source.DPMRanking,
        VehiclesDestroyedRank = source.VehiclesDestroyedRanking,
        HSAmountRank = source.HeadShotAmountRanking,
        RoadKillRank = source.RoadKillsRanking,
        MeleeKillRank = source.MeleeKillsRanking,
        VehicleKillRank = source.VechileKillsRanking,
        ScopedKillRank = source.ScopedKills,
        HipfireKillRank = source.HipfireKillsRanking,
        HumanKillRank = source.HumanKillsRanking,
        AIKillRank = source.AIKillsRanking,
        ObjectiveTimeRank = source.ObjectTotalRanking,
        DisarmedObjectRank = source.DefusedRanking,
        CapturedObjectiRank = source.CapturedObjectiRankRanking,
        ObjectivesDeutralizeRank = source.NeutralizedRanking,
        SectorsDefendeRank = source.DefendedSectorRanking,
        SectorsCapturedRank = source.AttackedSectorRanking,
        AttackedObjectRank =source.AttackedTotalRanking
WHEN NOT MATCHED THEN
    INSERT (HeroID, KDRank, HSRank, WinPercentRank, HumanKDRank,DeathRank,KPMRank,KPMatchRank,WinRank,LostRank,DamageRank,DPMRank,VehiclesDestroyedRank,HSAmountRank,RoadKillRank,MeleeKillRank,VehicleKillRank,ScopedKillRank,HipfireKillRank,HumanKillRank,AIKillRank,ObjectiveTimeRank,DisarmedObjectRank,CapturedObjectiRank,ObjectivesDeutralizeRank,SectorsDefendeRank,SectorsCapturedRank,AttackedObjectRank)
    VALUES (source.HeroID, source.KDRanking, source.HSRanking, source.WinPercentRanking, source.HumanKDRanking,source.DeathsRanking,source.KPMRanking,source.KPMatchRanking,source.WinsRanking,source.LossesRanking,source.DamageRanking,source.DPMRanking,source.VehiclesDestroyedRanking,source.HeadShotAmountRanking,source.RoadKillsRanking,source.MeleeKillsRanking,source.VechileKillsRanking,source.ScopedKills,source.HipfireKillsRanking,source.HumanKillsRanking,source.AIKillsRanking,source.ObjectTotalRanking,source.DefusedRanking,source.CapturedObjectiRankRanking,source.NeutralizedRanking,source.DefendedSectorRanking,source.AttackedSectorRanking,source.AttackedTotalRanking);
