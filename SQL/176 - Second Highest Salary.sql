-- Write a solution to find the second highest salary from the Employee table.
-- If there is no second highest salary, return null.
-- NOTE: The column should be 'SecondHighestSalary'

-- Isn't accepted, as we get no rows here when there's only one distinct salary
SELECT TOP 1 salary AS SecondHighestSalary
FROM Employee
WHERE salary < (
    SELECT MAX(salary)
    FROM Employee
)
ORDER BY salary DESC;

-- MAX will return null if there's no possible values
-- So the solution was to just chain these together
SELECT MAX(salary) AS SecondHighestSalary
FROM Employee
WHERE salary < (
    SELECT MAX(salary)
    FROM Employee
);
