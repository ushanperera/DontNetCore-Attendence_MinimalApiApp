

select * from `shiftmanagement`.`shiftdata`
SET SQL_SAFE_UPDATES = 0;

DELETE FROM `shiftmanagement`.`shiftdata` 
where `ShiftId` ='8'




INSERT INTO `shiftmanagement`.`shiftdata` (`ShiftId`, `ShiftDate`) VALUES ('02', '2025-07-10 00:00:00');


UPDATE `shiftmanagement`.`shiftdata` SET `ShiftDate` = '2025-07-10 00:00:00' WHERE (`ID` = '1');


