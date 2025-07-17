USE `shiftmanagement`;
DELIMITER $$

DROP PROCEDURE IF EXISTS `ManageShiftData`$$

CREATE PROCEDURE `ManageShiftData`(
    IN p_ShiftId VARCHAR(30),
    IN p_ShiftDate VARCHAR(30),
    
    IN p_WorkStartTime VARCHAR(30),
    IN p_WorkEndTime VARCHAR(30),
    IN p_MealBreakStartTime VARCHAR(30),
    IN p_MealBreakEndTime VARCHAR(30),
    
	IN p_IsPublicHoliday VARCHAR(30),
    IN p_ShiftRemarks VARCHAR(30)

    
) 
BEGIN
    -- Check if record exists
    IF EXISTS (SELECT 1 FROM shiftdata WHERE date(ShiftDate) = date(p_ShiftDate)
			   AND ShiftId = p_ShiftId ) THEN
        -- Update existing record
        UPDATE shiftdata 
        SET 
            -- Add fields to update here
            -- Example: LastUpdated = NOW()
            ShiftId = p_ShiftId,  -- At least update one field
            ShiftDate = p_ShiftDate,
            WorkStartTime = p_WorkStartTime,
            WorkEndTime = p_WorkEndTime,
            MealBreakStartTime = p_MealBreakStartTime,
            MealBreakEndTime = p_MealBreakEndTime,
            
            IsPublicHoliday = p_IsPublicHoliday,
            ShiftRemarks = p_ShiftRemarks
        WHERE 
            ShiftId = p_ShiftId 
            AND ShiftDate = p_ShiftDate;
        
        SELECT 'Existing shift updated' AS Result;
    ELSE
        -- Insert new record
        INSERT INTO shiftdata (
        ShiftId,
        ShiftDate,
        WorkStartTime,
        WorkEndTime,
        MealBreakStartTime,
        MealBreakEndTime,
        
        IsPublicHoliday,
        ShiftRemarks
        )
        VALUES (
        p_ShiftId, 
        p_ShiftDate,
        p_WorkStartTime,
        p_WorkEndTime,
        p_MealBreakStartTime,
        p_MealBreakEndTime,
        
        p_IsPublicHoliday,
        p_ShiftRemarks
        );
        
        SELECT 'New shift created' AS Result;
    END IF;
END$$

DELIMITER ;