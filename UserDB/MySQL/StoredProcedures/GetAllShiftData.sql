
-- CALL `shiftmanagement`.`GetAllShiftData`();

-- USE `shiftmanagement`;
-- DROP procedure IF EXISTS `shiftmanagement`.`GetAllShiftData`;
-- ;

DELIMITER $$
USE `shiftmanagement`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllShiftData`()
select Id,ShiftId,ShiftDate 
WorkStartTime, WorkEndTime, MealBreakStartTime, MealBreakEndTime

from shiftdata$$
DELIMITER ;
;