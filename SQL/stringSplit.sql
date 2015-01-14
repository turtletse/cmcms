DROP FUNCTION IF EXISTS stringSplit;
DROP FUNCTION IF EXISTS substrCount;
DROP PROCEDURE IF EXISTS split;

CREATE FUNCTION stringSplit(
x VARCHAR(255),
delim VARCHAR(12),
pos INT)
RETURNS VARCHAR(255)
RETURN REPLACE(SUBSTRING(SUBSTRING_INDEX(x, delim, pos),
CHAR_LENGTH(SUBSTRING_INDEX(x, delim, pos -1)) + 1), delim, '');

DELIMITER $$
CREATE FUNCTION substrCount(s VARCHAR(255), ss VARCHAR(255)) RETURNS tinyint(3) unsigned
READS SQL DATA
BEGIN
DECLARE count TINYINT(3) UNSIGNED;
DECLARE offset TINYINT(3) UNSIGNED;
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET s = NULL;
SET count = 0;
SET offset = 1;
REPEAT
IF NOT ISNULL(s) AND offset > 0 THEN
SET offset = LOCATE(ss, s, offset);
IF offset > 0 THEN
SET count = count + 1;
SET offset = offset + 1;
END IF;
END IF;
UNTIL ISNULL(s) OR offset = 0 END REPEAT;
RETURN count;
END $$

CREATE PROCEDURE split (x varchar(255), delim varchar(12))
BEGIN
SET @Valcount = substrCount(x,delim)+1;
SET @v1=0;
drop table if exists splitResult;
create temporary
table splitResult (split_value varchar(255));
WHILE (@v1 < @Valcount) DO
set @val = stringSplit(x,delim,@v1+1);
INSERT INTO splitResult (split_value) VALUES (@val);
SET @v1 = @v1 + 1;
END WHILE;
END $$

DELIMITER ;

-- call split('A,B,C', ',');