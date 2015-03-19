SHOW PROCESSLIST;
SET GLOBAL event_scheduler = ON;

DROP EVENT IF EXISTS cmcms_pres_clean_up;
DELIMITER $$
CREATE EVENT cmcms_pres_clean_up 
ON SCHEDULE EVERY 1 DAY STARTS '2015-03-18 00:00:00' 
DO BEGIN
	CALL cmcms.sp_prescription_clean_up();
END $$

DELIMITER ;