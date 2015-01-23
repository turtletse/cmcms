DROP TABLE IF EXISTS debug_log;
CREATE TABLE debug_log (
	log_dtm datetime(3),
    log_msg VARCHAR(255)
);
CREATE INDEX debug_log_x1 on debug_log(log_dtm);

DROP PROCEDURE IF EXISTS debug_logger;

DELIMITER $$

CREATE PROCEDURE debug_logger (IN msg varchar(255))
BEGIN
	INSERT INTO debug_log VALUES (sysdate(3), msg);
END $$

DELIMITER ;