----DROP TABLE `shiftmanagement`.`shiftData`
----Create Table `shiftData` in `shiftmanagement` database

CREATE TABLE `shiftmanagement`.`shiftData` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `ShiftId` VARCHAR(45) NOT NULL,
 `ShiftDate` DateTime NOT NULL,
 PRIMARY KEY (`ID`)) 



ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `WorkStartTime` Time;
ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `WorkEndTime` Time;
ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `MealBreakStartTime` Time;
ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `MealBreakEndTime` Time;

ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `IsPublicHoliday` bool;
ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `ShiftRemarks` varchar(50);


ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `RateId` INT NULL;
ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `Rate` Float;


 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `TotalWorkedDuration` Time;
 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `TotalMealBreakDuration` Time;
 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `MealBreakGapDuration` Time;
 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `MealBreakPenaltyDuration` Time;
 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `ExtraHoursWorkedDuration` Time;
 ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `WeekDayAntiSocialDuration` Time;


-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `IsWeekendShift` Time;

-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `HourlyPay` Time;
-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `ExtraHourPay` Time;
-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `MealBreakPenaltyPay` Time;
-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `PublicHolidayPenaltyPay` Time;
-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `WeekEndPenaltyPay` Time;
-- ALTER TABLE `shiftmanagement`.`shiftData` ADD COLUMN `TotalDayPay` Time;

