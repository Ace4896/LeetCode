-- Write a solution to find the nth highest salary from the Employee table. If there is no nth highest salary, return null.
CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    -- Determine salary rankings
    -- DENSE_RANK uses distinct ranking values, unlike ROW_NUMBER which would go over all rows
    DECLARE @Salaries TABLE(Rank INT, Salary INT);
    DECLARE @Result INT = NULL;

    INSERT INTO @Salaries (Rank, Salary)
    SELECT
        DENSE_RANK() OVER(ORDER BY Salary DESC) AS Rank,
        Salary
    FROM Employee;

    SELECT @Result = Salary
    FROM @Salaries
    WHERE Rank = @N;

    RETURN @Result;
END

-- This is a shorter version, which runs faster since we're not saving intermediate results
CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        SELECT MAX(Salary)
        FROM (
            SELECT
                DENSE_RANK() OVER(ORDER BY SALARY DESC) AS Rank,
                Salary
            FROM Employee
        ) Salaries
        WHERE Salaries.Rank = @N
    );
END
